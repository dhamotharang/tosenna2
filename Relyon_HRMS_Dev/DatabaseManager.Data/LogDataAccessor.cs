using System;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;
using System.Security.Principal;
using System.Security.Permissions;
using DatabaseManager.Data;
using System.Text.RegularExpressions;
using System.Configuration;

namespace DatabaseManager.Data
{
	public sealed class LogDataAccessor
	{
		#region Private Members
		private static	String		connectionString = "";
		#endregion

		#region Constructor
		private LogDataAccessor()
		{
		}
		#endregion

		#region Static Constructor
		static LogDataAccessor()
		{
		}
		#endregion

		// Generic methods for data update / retrieval.
		#region ExecuteDataSet
		public static DataSet ExecuteDataSet(String sproc, SqlParameter[] parameters)
		{
			SqlConnection	connection		= null;
			SqlCommand		command			= null;
			SqlDataAdapter	adapter			= null;
			DataSet			dataSet			= new DataSet();
			dataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;

			using(command = new SqlCommand())
			{

				command.CommandText		= sproc;
				command.CommandType		= CommandType.StoredProcedure;

				if(parameters != null)
				{
					for(Int32 i = 0; i < parameters.Length; i++)
					{
						if(parameters[i] != null)
						{
							command.Parameters.Add(parameters[i]);
						}
					}
				}

				using(connection = GetConnection())
				{
					command.Connection	= connection;

					connection.Open();
					
					using(adapter = new SqlDataAdapter(command))
					{
						adapter.Fill(dataSet);
					}

					connection.Close();
				}
			}

			return dataSet;
		}
		#endregion

		#region ExecuteWithResult
		public static String ExecuteWithResult(String sproc, SqlParameter[] parameters)
		{
			SqlConnection	connection		= null;
			SqlCommand		command			= null;
			SqlParameter	parameter		= null;
			String			result			= null;

			using (command = new SqlCommand())
			{
				command.CommandText		= sproc;
				command.CommandType		= CommandType.StoredProcedure;

				if(parameters != null)
				{
					for(Int32 i = 0; i < parameters.Length; i++)
					{
						if(parameters[i] != null)
						{
							command.Parameters.Add(parameters[i]);
						}
					}
				}

				parameter = new SqlParameter("@result", SqlDbType.VarChar, 100);
				parameter.Direction = ParameterDirection.Output;

				command.Parameters.Add(parameter);

				using(connection = GetConnection())
				{
					command.Connection	= connection;

					connection.Open();

					command.ExecuteNonQuery();

					result = (String)parameter.Value;

					connection.Close();
				}
	
				return result;
			}
		}
		#endregion

		#region Execute
		public static void Execute(String sproc, SqlParameter[] parameters)
		{
			SqlConnection	connection		= null;
			SqlCommand		command			= null;

			using (command = new SqlCommand())
			{
				command.CommandText		= sproc;
				command.CommandType		= CommandType.StoredProcedure;

				if(parameters != null)
				{
					for(Int32 i = 0; i < parameters.Length; i++)
					{
						if(parameters[i] != null)
						{
							command.Parameters.Add(parameters[i]);
						}
					}
				}

				using(connection = GetConnection())
				{
					command.Connection	= connection;

					connection.Open();

					command.ExecuteNonQuery();

					connection.Close();
				}
			}
		}
		#endregion

		#region GetConnection
		private static SqlConnection GetConnection()
		{
			//connectionString = "server=(local);user id=sa; pwd=sa;Database=EventManager; Persist Security Info=True";
            connectionString = System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionInfo");
			//connectionString = ConfigurationSettings.AppSettings["ConnectionInfo"];
			SqlConnection connection = new SqlConnection(connectionString);

			return connection;
		}
		#endregion
	}


}
