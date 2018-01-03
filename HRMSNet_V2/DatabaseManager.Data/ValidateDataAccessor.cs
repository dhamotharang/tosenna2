using System;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;
using System.Security.Principal;
using System.Security.Permissions;
using System.Text.RegularExpressions;


namespace DatabaseManager.Data
{
	public sealed class ValidateDataAccessor
	{
		
		private static	Decimal		currencyMinimum	= 0m;
		private static	Decimal		currencyMaximum	= 99999999m;
		private static	Int32		yearMinimum		= 0;
		private static	Int32		yearMaximum		= DateTime.Now.Year + 1;

		#region Constructor
		private ValidateDataAccessor()
		{
		}
		#endregion

		#region Static Constructor
		static ValidateDataAccessor()
		{
		}
		#endregion

		// Validation methods.
		#region IsValidCount
		public static Boolean IsValidCount(Int32 value)
		{
			return (value >= 0) && (value <= Int32.MaxValue);
		}
		#endregion

		#region IsValidCurrency
		public static Boolean IsValidCurrency(decimal value)
		{
			return (value >= ValidateDataAccessor.currencyMinimum) && (value <= ValidateDataAccessor.currencyMaximum);
		}
		#endregion

		#region IsValidYear
		public static Boolean IsValidYear(Int32 value)
		{
			return (value >= ValidateDataAccessor.yearMinimum) && (value <= ValidateDataAccessor.yearMaximum);
		}
		#endregion

	}


}
