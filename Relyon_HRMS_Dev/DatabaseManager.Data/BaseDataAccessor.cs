using System;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;
using System.Security.Principal;
using System.Security.Permissions;
using System.Text.RegularExpressions;


namespace DatabaseManager.Data
{
	public sealed class BaseDataAccessor
	{
		#region Private Members
		private static	String		connectionString = "";
		#endregion

		#region Constructor
		private BaseDataAccessor()
		{
		}
		#endregion

		#region Static Constructor
		static BaseDataAccessor()
		{
//			if(Configuration.Current.CountMaximum.Length > 0)
//			{
//				countMaximum = Int32.Parse(Configuration.Current.CountMaximum, CultureInfo.InvariantCulture);
//			}

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

				parameter = new SqlParameter("@result", SqlDbType.VarChar, 200);
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

		#region RetrieveStatus
		public static NamedCollection[] RetrieveCollection(String sproc, SqlParameter[] parameters)
		{
			NamedCollection[] result = null;

			DataSet dataSet = BaseDataAccessor.ExecuteDataSet(sproc, parameters);
			DataTable	table = null;
			DataRow		row = null;

			if(dataSet.Tables.Count > 0)
			{
				table = dataSet.Tables[0];
				result = new NamedCollection[table.Rows.Count];
				
				for(Int32 i = 0; i < table.Rows.Count; i++)
				{
					row = table.Rows[i];
					result[i] = new NamedCollection((String)row["TypeID"], (String)row["TypeName"]);
				}
			}

			return result;
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
			// Currently Read  the Connection from Here. Change this later so that we can read connection from file.

			connectionString = System.Configuration.ConfigurationSettings.AppSettings.Get("ConnectionInfo");
			SqlConnection connection = new SqlConnection(connectionString);

			return connection;
		}
		#endregion
	}

	public class NamedCollection
	{
		private String id;
		private String name;

		#region Constructor
		public NamedCollection(String id, String name)
		{
			this.id = id;
			this.name = name;
		}
		#endregion

		#region Id
		public String Id
		{
			get
			{
				return this.id;
			}
		}
		#endregion

		#region Name
		public String Name
		{
			get
			{
				return this.name;
			}
		}
		#endregion
	}

}
