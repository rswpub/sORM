namespace Shared
{
    public class Constants
    {

        public static readonly string True_String = "true";
        public static readonly int True_Int = 1;
        public static readonly string False_String = "false";
        public static readonly int False_Int = 0;

        public enum NumRecordsFound
        {
            None,
            One,
            Multiple
        }

        // Database connection string names
        public static readonly string DBConnectionStringName_MainConnectionString = "MainConnectionString";

        // Exception error messages
        public static readonly string ExceptionErrorMessage_NonUniqueIdFieldsException = "Error - more than one entry found with the same identifying fields";
        public static readonly string ExceptionErrorMessage_MoreThanOneStartStepInWorkflowException = "Error - more than one Start step found for this workflow (workflows may only have one Start step)";
        public static readonly string ExceptionErrorMessage_RequiredPropertyNotDefinedException = "Error - a required property was not defined";
        public static readonly string ExceptionErrorMessage_UniqueIndexOrConstraintViolationException = "Error - the UPDATE or INSERT that was just attempted would have resulted in a UNIQUE INDEX or UNIQUE CONSTRAINT violation.";
        public static readonly string ExceptionErrorMessage_ForeignKeyOrphanException = "Error - the DELETE that was just attempted would have resulted in an orphaned foreign key (attempted to remove record from base table whose key is in use in a foreign table).";

        // SQL Error codes
        public static readonly int SQLErrorCode_UniqueIndexViolation_AttemptedToCreateDuplicateKeyWhenUniquenessIsRequired = 2601;
        public static readonly int SQLErrorCode_UniqueConstraintViolation_AttemptedToCreateDuplicateKeyWhenUniquenessIsRequired = 2627;
        public static readonly int SQLErrorCode_ForeignKeyViolation_AttemptedToRemoveKeyFromBaseTableThatIsInUseInForeignTable = 547;

        // Return status codes
        public static readonly int ReturnStatus_Success = 0;
        public static readonly int ReturnStatus_Error = -1;
        public static readonly int ReturnStatus_Error_EntryAlreadyExistsInDatabase = -10000;
        //public static readonly int ReturnStatus_UniqueIndexViolation_AttemptedToCreateDuplicateKeyWhenUniquenessIsRequired = -2601;
        //public static readonly int ReturnStatus_UniqueConstraintViolation_AttemptedToCreateDuplicateKeyWhenUniquenessIsRequired = -2627;
        //public static readonly int ReturnStatus_ForeignKeyViolation_AttemptedToRemoveKeyFromBaseTableThatIsInUseInForeignTable = -547;

        // SQL sorting parameters
        public static readonly string SQLSortOrder_Ascending = " ASC ";
        public static readonly string SQLSortOrder_Descending = " DESC ";

        // Database Row ID values
        public static readonly int DB_RowID_Undefined = -1;

        // Relative page paths
        //public static readonly string PartialPagePath_People_General = "/People/General.aspx";
        //public static readonly string RootRelativePagePath_People_General = $"~{PartialPagePath_People_General}";
        //public static readonly string SiblingRelativePagePath_People_General = $"..{PartialPagePath_People_General}";




        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                    //
        //                  DATABASE VALUES THAT NEED TO BE REFERENCED IN THE CODE                            //
        //                                                                                                    //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////


        //////////////////////////////////////////////////
        //
        //  View:  v_MyView
        //
        //public static readonly string dbviewname__v_MyView = "v_MyView

        //////////////////////////////////////////////////
        //
        //  Table:  ALL
        //
        //          These column names are consistent across
        //          all tables that use them.
        //
        //  Column Names
        public static readonly string DBColName__ALL__ID = "ID";
        public static readonly string DBColName__ALL__TenantID = "TenantID";

        //////////////////////////////////////////////////
        //
        //  Table:  ALL Reference tables
        //
        //          These column names are consistent across
        //          all Reference tables that use them.
        //
        //  Column Names
        public static readonly string DBColName__ALLREFTABLES__Name = "Name";

        //////////////////////////////////////////////////
        //
        //  Table:  Tenants
        //
        public static readonly string DBTableName__Tenants = "Tenants";
        // Column Names
        public static readonly string DBColName__Tenants__Name = "Name";
        // Column Values
        public static readonly int DBValue__Tenants__ID__Wickham = 100;


    }
}