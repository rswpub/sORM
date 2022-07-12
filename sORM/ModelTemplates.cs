namespace sORM
{
    public class ModelTemplates
    {
        public static readonly string ModelInstanceTemplate = @"

using static Shared.Constants;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Shared;

namespace Model
{
    public class <<ModelClassName>> : ModelBase
    {
        protected override string DatabaseTableName { get { return DBTableName__<<DatabaseTableName>>; } }

        public override string EntityKeyFieldName_DisplayText { get { throw new NotImplementedException(); } }

        protected override List<InsertOrUpdateField> InsertAndUpdateFieldList
        {
            get
            {
                return new List<InsertOrUpdateField>()
                {
                    new InsertOrUpdateField(DBColName__ALL__TenantID, SqlDbType.Int, TenantID)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__<<DatabaseColumnName>>, SqlDbType.Int, <<DatabaseColumnName>>)

                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__OrderID, SqlDbType.Int, OrderID)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__AssetPairID, SqlDbType.Int, AssetPairID)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__OrderListID, SqlDbType.Int, OrderListID)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__ClientOrderID, SqlDbType.VarChar, ClientOrderID)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__Price, SqlDbType.Decimal, Price)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__OrigQuantity, SqlDbType.Decimal, OrigQuantity)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__ExecutedQuantity, SqlDbType.Decimal, ExecutedQuantity)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__CumulativeQuoteQuantity, SqlDbType.Decimal, CumulativeQuoteQuantity)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__OrderStatusID, SqlDbType.Int, OrderStatusID)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__TimeInForceID, SqlDbType.Int, TimeInForceID)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__OrderTypeID, SqlDbType.Int, OrderTypeID)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__OrderSideID, SqlDbType.Int, OrderSideID)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__StopPrice, SqlDbType.Decimal, StopPrice)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__IcebergQuantity, SqlDbType.Decimal, IcebergQuantity)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__TimeUnixMilliseconds, SqlDbType.BigInt, TimeUnixMilliseconds)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__UpdateTimeUnixMilliseconds, SqlDbType.BigInt, UpdateTimeUnixMilliseconds)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__IsWorking, SqlDbType.Bit, IsWorking)
                    , new InsertOrUpdateField(DBColName__<<DatabaseTableName>>__OriginalQuoteOrderQuantity, SqlDbType.Decimal, OriginalQuoteOrderQuantity)
                };
            }
        }




        // Fields in the base table
        public int? ExchangeID { get; set; }
        public int? OrderID { get; set; }
        public int? AssetPairID { get; set; }
        public int? OrderListID { get; set; }
        public string ClientOrderID { get; set; }
        public decimal? Price { get; set; }
        public decimal? OrigQuantity { get; set; }
        public decimal? ExecutedQuantity { get; set; }
        public decimal? CumulativeQuoteQuantity { get; set; }
        public int? OrderStatusID { get; set; }
        public int? TimeInForceID { get; set; }
        public int? OrderTypeID { get; set; }
        public int? OrderSideID { get; set; }
        public decimal? StopPrice { get; set; }
        public decimal? IcebergQuantity { get; set; }
        public Int64? TimeUnixMilliseconds { get; set; }
        public Int64? UpdateTimeUnixMilliseconds { get; set; }
        public bool? IsWorking { get; set; }
        public decimal? OriginalQuoteOrderQuantity { get; set; }

        // Fields from related tables
        public string AssetPairName { get; set; }




        // Constructors
        public Order(int tenantID) : base(tenantID) { }

        public Order(int tenantID, int id) : base(tenantID, id) { }




        // Methods
        protected override NumRecordsFound Fill(int tenantID)
        {
            NumRecordsFound numRecordsFound = NumRecordsFound.None;

            string sqlString = $@"" 

                SELECT 
                        ord.{DBColName__ALL__TenantID}
                        , ord.{DBColName__ALL__ID}
                        , ord.{DBColName__Orders__ExchangeID}
                        , ord.{DBColName__Orders__OrderID}
                        , ord.{DBColName__Orders__AssetPairID}
                        , ord.{DBColName__Orders__OrderListID}
                        , ord.{DBColName__Orders__ClientOrderID}
                        , ord.{DBColName__Orders__Price}
                        , ord.{DBColName__Orders__OrigQuantity}
                        , ord.{DBColName__Orders__ExecutedQuantity}
                        , ord.{DBColName__Orders__CumulativeQuoteQuantity}
                        , ord.{DBColName__Orders__OrderStatusID}
                        , ord.{DBColName__Orders__TimeInForceID}
                        , ord.{DBColName__Orders__OrderTypeID}
                        , ord.{DBColName__Orders__OrderSideID}
                        , ord.{DBColName__Orders__StopPrice}
                        , ord.{DBColName__Orders__IcebergQuantity}
                        , ord.{DBColName__Orders__TimeUnixMilliseconds}
                        , ord.{DBColName__Orders__UpdateTimeUnixMilliseconds}
                        , ord.{DBColName__Orders__IsWorking}
                        , ord.{DBColName__Orders__OriginalQuoteOrderQuantity}
                FROM 
                        {DatabaseTableName} AS ord
                WHERE 
                        ord.{DBColName__ALL__TenantID} = @{DBColName__ALL__TenantID}
                        AND ord.{DBColName__ALL__ID} = @{DBColName__ALL__ID}
                ORDER BY 
                        ord.{DBColName__ALL__ID}
                "";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[""MainConnectionString""].ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlString, connection))
            {
                command.Parameters.Add(""@"" + DBColName__ALL__TenantID, SqlDbType.Int).Value = tenantID;
                command.Parameters.Add(""@"" + DBColName__ALL__ID, SqlDbType.Int).Value = ID.Value;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    for (int i = 0; reader.Read(); i++)
                    {
                        if (i > 0)
                        {
                            numRecordsFound = NumRecordsFound.Multiple;
                            throw new NonUniqueIdFieldsException(ExceptionErrorMessage_NonUniqueIdFieldsException + "" (202102022119)"");
                        }
                        else
                        {
                            numRecordsFound = NumRecordsFound.One;

                            TenantID = (int)reader[DBColName__ALL__TenantID];
                            ID = (int)reader[DBColName__ALL__ID];
                            ExchangeID = reader[DBColName__Orders__ExchangeID] as int?;
                            OrderID = reader[DBColName__Orders__OrderID] as int?;
                            AssetPairID = reader[DBColName__Orders__AssetPairID] as int?;
                            OrderListID = reader[DBColName__Orders__OrderListID] as int?;
                            ClientOrderID = reader[DBColName__Orders__ClientOrderID] as string;
                            Price = reader[DBColName__Orders__Price] as decimal?;
                            OrigQuantity = reader[DBColName__Orders__OrigQuantity] as decimal?;
                            ExecutedQuantity = reader[DBColName__Orders__ExecutedQuantity] as decimal?;
                            CumulativeQuoteQuantity = reader[DBColName__Orders__CumulativeQuoteQuantity] as decimal?;
                            OrderStatusID = reader[DBColName__Orders__OrderStatusID] as int?;
                            TimeInForceID = reader[DBColName__Orders__TimeInForceID] as int?;
                            OrderTypeID = reader[DBColName__Orders__OrderTypeID] as int?;
                            OrderSideID = reader[DBColName__Orders__OrderSideID] as int?;
                            StopPrice = reader[DBColName__Orders__StopPrice] as decimal?;
                            IcebergQuantity = reader[DBColName__Orders__IcebergQuantity] as decimal?;
                            TimeUnixMilliseconds = reader[DBColName__Orders__TimeUnixMilliseconds] as Int64?;
                            UpdateTimeUnixMilliseconds = reader[DBColName__Orders__UpdateTimeUnixMilliseconds] as Int64?;
                            IsWorking = reader[DBColName__Orders__IsWorking] as bool?;
                            OriginalQuoteOrderQuantity = reader[DBColName__Orders__OriginalQuoteOrderQuantity] as decimal?;
                        }
                    }
                }
            }
            return numRecordsFound;
        }

        public enum OrderStatusFilter
        {
            All,
            AllOpen,
        }

        public static List<Order> GetAll(int tenantID, int? orderID, int? assetPairID, OrderStatusFilter orderStatusFilter)
        {
            List<Order> list_Order = new List<Order>();

            string sqlString = $@"" 

                SELECT 
                        ord.{DBColName__ALL__TenantID}
                        , ord.{DBColName__ALL__ID}
                        , ord.{DBColName__Orders__ExchangeID}
                        , ord.{DBColName__Orders__OrderID}
                        , ord.{DBColName__Orders__AssetPairID}
                        , ord.{DBColName__Orders__OrderListID}
                        , ord.{DBColName__Orders__ClientOrderID}
                        , ord.{DBColName__Orders__Price}
                        , ord.{DBColName__Orders__OrigQuantity}
                        , ord.{DBColName__Orders__ExecutedQuantity}
                        , ord.{DBColName__Orders__CumulativeQuoteQuantity}
                        , ord.{DBColName__Orders__OrderStatusID}
                        , ord.{DBColName__Orders__TimeInForceID}
                        , ord.{DBColName__Orders__OrderTypeID}
                        , ord.{DBColName__Orders__OrderSideID}
                        , ord.{DBColName__Orders__StopPrice}
                        , ord.{DBColName__Orders__IcebergQuantity}
                        , ord.{DBColName__Orders__TimeUnixMilliseconds}
                        , ord.{DBColName__Orders__UpdateTimeUnixMilliseconds}
                        , ord.{DBColName__Orders__IsWorking}
                        , ord.{DBColName__Orders__OriginalQuoteOrderQuantity}
                FROM 
                        {DBTableName__Orders} AS ord
                WHERE 
                        ord.{DBColName__ALL__TenantID} = @{DBColName__ALL__TenantID}
                        {(!orderID.HasValue ? @"" ""
                                : $@"" AND ord.{DBColName__Orders__OrderID} = @{DBColName__Orders__OrderID} ""
                        )}
                        {(!assetPairID.HasValue ? @"" ""
                                : $@"" AND ord.{DBColName__Orders__AssetPairID} = @{DBColName__Orders__AssetPairID} ""
                        )}
                        {(orderStatusFilter == OrderStatusFilter.All ? @"" ""
                                : orderStatusFilter == OrderStatusFilter.AllOpen ?
                                    $@"" AND ord.{DBColName__Orders__OrderStatusID} IN
                                    (
                                        {DBValue__OrderStatuses__ID__New}
                                        , {DBValue__OrderStatuses__ID__PartiallyFilled}
                                        , {DBValue__OrderStatuses__ID__PendingCancel}
                                    ) ""
                                : $"" *** ERROR - unexpected {nameof(orderStatusFilter)} ""
                        )}
                ORDER BY
                        ord.{DBColName__ALL__ID}

                "";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[""MainConnectionString""].ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlString, connection))
            {
                command.Parameters.Add(""@"" + DBColName__ALL__TenantID, SqlDbType.Int).Value = tenantID;
                if (orderID.HasValue)
                {
                    command.Parameters.Add(""@"" + DBColName__Orders__OrderID, SqlDbType.Int).Value = orderID;
                }
                if (assetPairID.HasValue)
                {
                    command.Parameters.Add(""@"" + DBColName__Orders__AssetPairID, SqlDbType.Int).Value = assetPairID;
                }
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        list_Order.Add(new Order(tenantID)
                        {
                            TenantID = (int)reader[DBColName__ALL__TenantID],
                            ID = (int)reader[DBColName__ALL__ID],
                            ExchangeID = reader[DBColName__Orders__ExchangeID] as int?,
                            OrderID = reader[DBColName__Orders__OrderID] as int?,
                            AssetPairID = reader[DBColName__Orders__AssetPairID] as int?,
                            OrderListID = reader[DBColName__Orders__OrderListID] as int?,
                            ClientOrderID = reader[DBColName__Orders__ClientOrderID] as string,
                            Price = reader[DBColName__Orders__Price] as decimal?,
                            OrigQuantity = reader[DBColName__Orders__OrigQuantity] as decimal?,
                            ExecutedQuantity = reader[DBColName__Orders__ExecutedQuantity] as decimal?,
                            CumulativeQuoteQuantity = reader[DBColName__Orders__CumulativeQuoteQuantity] as decimal?,
                            OrderStatusID = reader[DBColName__Orders__OrderStatusID] as int?,
                            TimeInForceID = reader[DBColName__Orders__TimeInForceID] as int?,
                            OrderTypeID = reader[DBColName__Orders__OrderTypeID] as int?,
                            OrderSideID = reader[DBColName__Orders__OrderSideID] as int?,
                            StopPrice = reader[DBColName__Orders__StopPrice] as decimal?,
                            IcebergQuantity = reader[DBColName__Orders__IcebergQuantity] as decimal?,
                            TimeUnixMilliseconds = reader[DBColName__Orders__TimeUnixMilliseconds] as Int64?,
                            UpdateTimeUnixMilliseconds = reader[DBColName__Orders__UpdateTimeUnixMilliseconds] as Int64?,
                            IsWorking = reader[DBColName__Orders__IsWorking] as bool?,
                            OriginalQuoteOrderQuantity = reader[DBColName__Orders__OriginalQuoteOrderQuantity] as decimal?,
                        });
                    }
                }
            }
            return list_Order;
        }

        public static int? GetMaxOrderIDForAssetPair(int tenantID, int assetPairID)
        {
            int? maxOrderID = null;

            string sqlString = $@"" 

                SELECT 
                        MAX(ord.{DBColName__Orders__OrderID}) AS {DBColName__Orders__OrderID}
                FROM 
                        {DBTableName__Orders} AS ord
                WHERE 
                        ord.{DBColName__ALL__TenantID} = @{DBColName__ALL__TenantID}
                        AND ord.{DBColName__Orders__AssetPairID} = @{DBColName__Orders__AssetPairID}
                GROUP BY
                        ord.{DBColName__Orders__AssetPairID}
                "";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[""MainConnectionString""].ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlString, connection))
            {
                command.Parameters.Add(""@"" + DBColName__ALL__TenantID, SqlDbType.Int).Value = tenantID;
                command.Parameters.Add(""@"" + DBColName__Orders__AssetPairID, SqlDbType.Int).Value = assetPairID;
                connection.Open();

                maxOrderID = command.ExecuteScalar() as int?;
            }
            return maxOrderID;
        }

    }
}
        ";




//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        private static readonly string ModelBaseTemplate = @"

using Shared;
using static Shared.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Model
{
    public abstract class ModelBase
    {
        // This is the name of the database table that corresponds to this model class.
        // This is used in the FROM clause of SQL queries.
        // For example, if a database table was named ""Countries"", the value ""Countries"" would be defined here.
        // In practice, this value typically comes from the Constants class, e.g., dbtablename__REF_Country 
        protected abstract string DatabaseTableName { get; }

        // This is the friendly name of this entity. 
        // This is used in messages displayed to the user.
        // For example, for a database table named ""Countries"", the Entity Name would be ""Country""
        // For most entities the name of the entity is the same as the class name, and the display
        //  version of this name may be obtained by adding a space between each word of the class name.
        //  We use a helper method to perform this function of converting a class name to the entity's
        //  display name.
        public virtual string EntityName_DisplayText { get { return Utilities.CamelCase_AddSpacesBetweenWords(this.GetType().Name); } }

        // This is the friendly name of this entity preceded by the the word ""a"" or ""an"" (whichever is appropriate).
        // This is used in messages displayed to the user.
        // For example, for an entity named ""Country"", the value ""a Country"" would be defined here.
        // Likewise, for an entity named ""Assets"", the value ""an Asset"" would be defined here.
        // Since the majority of entities will use the indefinite article ""a"" instead of ""an"", we make the base
        //  implementation using ""a"", and inheriting classes can override this to use ""an"" when needed.
        public virtual string EntityName_WithIndefiniteArticle_DisplayText { get { return ""a "" + EntityName_DisplayText; } }

        // This is the friendly name of this entity's key field.
        // This is used in messages displayed to the user, such as ""There is already a Country with this Country Name"" 
        // (where ""Country"" is the Entity Name and ""Country Name"" is the Entity's Key Field Name, since the value of
        //  Country Name must be unique for each Country)
        public abstract string EntityKeyFieldName_DisplayText { get; }

        // This is a property that lets us know whether or not this entity is ""tenant specific"".
        // Some database tables store data that is not tenant specific. In other words, the data in the table
        //  is the same for all tenants. This is often ""reference"" data that does not differ from tenant to tenant.
        //  An example would be States. The list of States in the United States is the same for everyone. Each tenant
        //  does not need to maintain a separate list of states. One master list of states can be used for all tenants.
        //  Therefore, the States database table does not need a TenantID field, and the data is considered to be
        //  not tenant specific.
        // On the other hand, some database tables do require a TenantID field. This data is considered to be tenant
        //  specific. An example of tenant-specific data would be Personnel. The personnel that work at one tenant are
        //  different from the personnel at other tenants. However, since all personnel are stored in the same Personnel
        //  database table, a TenantID field is needed in that table to identify which records belong to which tenants.
        // The following property lets us know whether or not we need to confirm the presence of the TenantID field.
        //  If the property is TRUE, we must confirm the presence of the TenantID field. If it is FALSE, we must confirm
        //  the absence of the TenantID field.
        protected virtual bool isATenantSpecificModel { get { return true; } }

        // This class is used to identify each field in a database table that will participate in
        // SQL INSERT and UPDATE statements.
        protected class InsertOrUpdateField
        {
            // This is the database field name.
            // In practice, this value typically comes from the Constants class, e.g., DBColName__ALL__TenantID
            public string FieldName { get; set; }
            // This is the SQL data type of the database field.
            // For example, SqlDbType.Int or SqlDbType.VarChar
            public SqlDbType SqlDbType { get; set; }
            // This is the value to be saved to the database for this database field.
            // For example, 29 or ""Lithuania""
            public object Value { get; set; }

            // This is the constructor for this class
            public InsertOrUpdateField(string fieldName, SqlDbType sqlDbType, object value)
            {
                FieldName = fieldName;
                SqlDbType = sqlDbType;
                Value = value;
            }
        }


        // This is an abstract method that must be implemented by all inheriting classes.
        // This method is used to define the list of all fields that will participate in 
        // SQL INSERT and UPDATE statements for this entity/model class.
        protected abstract List<InsertOrUpdateField> InsertAndUpdateFieldList { get; }



        // This is the TenantID value representing the TenantID database field that most model classes implement
        public int TenantID { get; protected set; }
        // This is the ID value representing the ID field that most model classes implement
        public int? ID { get; protected set; }



        public ModelBase(int tenantID)
        {
            if ((DatabaseTableName == null)
                || (EntityName_DisplayText == null)
                || (EntityName_WithIndefiniteArticle_DisplayText == null)
                )
            {
                throw new RequiredPropertyNotDefinedException(ExceptionErrorMessage_RequiredPropertyNotDefinedException + "" (202101310016)"");
            }

            TenantID = tenantID;
        }

        public ModelBase(int tenantID, int id) : this(tenantID)
        {
            ID = id;
            if (Fill(tenantID) == NumRecordsFound.None)
            {
                ID = null;
            }
        }

        //public ModelBase(int tenantID, string keyField) { }



        // The Fill method is used to ""fill"" an object instance with values.
        // The ID field of the object instance is assumed to be populated. 
        // The ID is then used to look for a matching entry in the database.
        // If a matching entry is found in the database, the fields of the matching database entry
        //  are used to ""fill"" the values of the corresponding fields in the object instance.
        // Classes that inherit from this base class must implement the Fill() method.
        protected abstract NumRecordsFound Fill(int tenantID);

        // The Save method is used to save an object instance's values to the database.
        // If the object instance is already defined, Save() calls the Update() method.
        // If the object instance is new and does not yet exist in the database, Save() calls
        //  the Add() method to add the new entry to the database.
        // Save() knows which one to perform based on whether or not the ID field is defined.
        //  If defined, it knows to do an Update. If not, it knows to do an Add.
        public int Save(int tenantID)
        {
            if (ID.HasValue)
                return Update(tenantID);
            else
            {
                int returnStatus = Add(tenantID);
                if (returnStatus > 0)
                {
                    ID = returnStatus;
                    returnStatus = ReturnStatus_Success;
                }
                return returnStatus;
            }
        }

        // The Add method is never called directly by outside code.
        // It is only ever called by this class's Save() method.
        private int Add(int tenantID)
        {
            if (InsertAndUpdateFieldList.Count <= 0)
            {
                throw new Exception(""Error - invalid number of INSERT fields (202101310017)"");
            }

            string insertFieldClause = null;
            string valueFieldClause = null;
            int i = 0;
            foreach (InsertOrUpdateField insertField in InsertAndUpdateFieldList)
            {
                if (i == 0)
                {
                    insertFieldClause = insertField.FieldName;
                    valueFieldClause = ""@"" + insertField.FieldName;
                }
                else
                {
                    insertFieldClause += "", "" + insertField.FieldName;
                    valueFieldClause += "", @"" + insertField.FieldName;
                }
                i++;
            }

            var sqlString = $@"" 
                INSERT INTO {DatabaseTableName}
                        ({insertFieldClause})
                OUTPUT
                        Inserted.{DBColName__ALL__ID}
                VALUES 
                        ({valueFieldClause})
                "";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[""MainConnectionString""].ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlString, connection))
            {
                foreach (InsertOrUpdateField insertField in InsertAndUpdateFieldList)
                {
                    command.Parameters.Add(CreateSqlParameterWithValue(insertField.FieldName, insertField.SqlDbType, insertField.Value));
                }
                connection.Open();
                // If the INSERT was successful, the ID of the new entry will be returned by ExecuteScalar()
                try
                {
                    int newID = (int)command.ExecuteScalar();
                    if (newID > 0)
                    {
                        return newID;
                    }
                    else
                    {
                        throw new Exception($""Error in Add() - error code = {newID} (202101310018)"");
                    }
                }
                catch (SqlException ex)
                {
                    if ((ex.Number == SQLErrorCode_UniqueConstraintViolation_AttemptedToCreateDuplicateKeyWhenUniquenessIsRequired)
                        || (ex.Number == SQLErrorCode_UniqueIndexViolation_AttemptedToCreateDuplicateKeyWhenUniquenessIsRequired))
                    {
                        throw new UniqueIndexOrConstraintViolationException($""{ExceptionErrorMessage_UniqueIndexOrConstraintViolationException} (202101310019)"");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        // The Update method is never called directly by outside code.
        // It is only ever called by this class's Save() method.
        private int Update(int tenantID)
        {
            if (InsertAndUpdateFieldList.Count <= 0)
            {
                throw new Exception(""Error - invalid number of update fields (202101310020)"");
            }

            string updateFieldClause = null;
            int i = 0;
            foreach (InsertOrUpdateField updateField in InsertAndUpdateFieldList)
            {
                if (i == 0)
                {
                    updateFieldClause = updateField.FieldName + "" = @"" + updateField.FieldName;
                }
                else
                {
                    updateFieldClause += "", "" + updateField.FieldName + "" = @"" + updateField.FieldName;
                }
                i++;
            }

            var sqlString = $@"" 
                UPDATE 
                        {DatabaseTableName}
                SET 
                        {updateFieldClause}
                WHERE
                        {DBColName__ALL__ID} = @{DBColName__ALL__ID}
                        {(isATenantSpecificModel ? $@"" AND {DBColName__ALL__TenantID} = @{DBColName__ALL__TenantID} "" : @"" "")}
                "";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[""MainConnectionString""].ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlString, connection))
            {
                command.Parameters.Add(""@"" + DBColName__ALL__ID, SqlDbType.Int).Value = ID.Value;
                bool tenantIDFieldFound = false;
                foreach (InsertOrUpdateField insertOrUpdateField in InsertAndUpdateFieldList)
                {
                    if (insertOrUpdateField.FieldName == DBColName__ALL__ID)
                    {
                        // The ID field should never be included in the InsertOrUpdateField list since it is always an IDENTITY field
                        // in the database.
                        // If it ever is included in the InsertOrUpdateField list, throw an exception.
                        throw new Exception($""ERROR: the {DBColName__ALL__ID} field was included in the {nameof(InsertOrUpdateField)} list (the {DBColName__ALL__ID} field should never be included since it is always an IDENTITY field in the database) (202101310021)"");
                    }
                    else if (insertOrUpdateField.FieldName == DBColName__ALL__TenantID)
                    {
                        // The TenantID field must be included in the InsertOrUpdateField list *if* this is a tenant-specific model,
                        // and it must not be included otherwise.
                        // When we find the TenantID field, set a flag so we can test for its presence or absence later.
                        tenantIDFieldFound = true;
                    }

                    command.Parameters.Add(CreateSqlParameterWithValue(insertOrUpdateField.FieldName, insertOrUpdateField.SqlDbType, insertOrUpdateField.Value));
                }

                if (isATenantSpecificModel && !tenantIDFieldFound)
                {
                    throw new Exception($""ERROR: the {DBColName__ALL__TenantID} field was omitted from the {nameof(InsertOrUpdateField)} list for the {DatabaseTableName} model class (the {DBColName__ALL__TenantID} field must be present) (202101310022)"");
                }
                else if (!isATenantSpecificModel && tenantIDFieldFound)
                {
                    throw new Exception($""ERROR: the {DBColName__ALL__TenantID} field was included in the {nameof(InsertOrUpdateField)} list for the {DatabaseTableName} model class (the {DBColName__ALL__TenantID} field must not be present) (202101310023)"");
                }

                connection.Open();
                // If the UPDATE was successful, the number of rows affected will be returned by ExecuteNonQuery()
                try
                {
                    int numRowsAffected = command.ExecuteNonQuery();
                    if (numRowsAffected != 1)
                    {
                        if (numRowsAffected > 1)
                        {
                            throw new Exception(""Error - duplicate ID's encountered...more than one entry updated (202101310024)"");
                        }
                        else
                        {
                            throw new Exception(""Error - data not saved (202101310025)"");
                        }
                    }
                    else
                    {
                        return ReturnStatus_Success;
                    }
                }
                catch (SqlException ex)
                {
                    if ((ex.Number == SQLErrorCode_UniqueConstraintViolation_AttemptedToCreateDuplicateKeyWhenUniquenessIsRequired)
                        || (ex.Number == SQLErrorCode_UniqueIndexViolation_AttemptedToCreateDuplicateKeyWhenUniquenessIsRequired))
                    {
                        throw new UniqueIndexOrConstraintViolationException($""{ExceptionErrorMessage_UniqueIndexOrConstraintViolationException} (202101310026)"");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        // The Delete method deletes an entry from the database based on the 
        //  value of the ID field.
        public int Delete(int tenantID)
        {
            if (!ID.HasValue)
                throw new Exception(""Delete error - ID property was NULL - ID cannot be null when attempting to perform a Delete (202101310028)"");

            var sqlString = $@"" 
                DELETE FROM 
                        {DatabaseTableName}
                WHERE
                        {DBColName__ALL__ID} = @{DBColName__ALL__ID}
                        {(isATenantSpecificModel ? $@"" AND {DBColName__ALL__TenantID} = @{DBColName__ALL__TenantID} "" : @"" "")}
                "";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[""MainConnectionString""].ConnectionString))
            using (SqlCommand command = new SqlCommand(sqlString, connection))
            {
                command.Parameters.Add(""@"" + DBColName__ALL__TenantID, SqlDbType.Int).Value = tenantID;
                command.Parameters.Add(""@"" + DBColName__ALL__ID, SqlDbType.Int).Value = ID.Value;
                connection.Open();
                try
                {
                    int numRowsAffected = command.ExecuteNonQuery();
                    if (numRowsAffected != 1)
                    {
                        if (numRowsAffected > 1)
                            throw new Exception(""Error - more than one entry deleted (202101310029)"");
                        else
                            throw new Exception(""Error - no matching entry found (202101310030)"");
                    }
                    return ReturnStatus_Success;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == SQLErrorCode_ForeignKeyViolation_AttemptedToRemoveKeyFromBaseTableThatIsInUseInForeignTable)
                    {
                        throw new ForeignKeyOrphanException($""{ExceptionErrorMessage_ForeignKeyOrphanException} (202101310031)"");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        private SqlParameter CreateSqlParameterWithValue(string fieldName, SqlDbType fieldSqlDbType, object fieldValue)
        {
            object parameterValue;
            if ((fieldValue == null)
                ||
                (
                    (
                    (fieldSqlDbType == SqlDbType.Char)
                    || (fieldSqlDbType == SqlDbType.NChar)
                    || (fieldSqlDbType == SqlDbType.NText)
                    || (fieldSqlDbType == SqlDbType.NVarChar)
                    || (fieldSqlDbType == SqlDbType.Text)
                    || (fieldSqlDbType == SqlDbType.VarChar)
                    )
                    && (string.IsNullOrWhiteSpace(fieldValue.ToString()))
                )
                )
            {
                parameterValue = DBNull.Value;
            }
            else
            {
                parameterValue = fieldValue;
            }

            SqlParameter sqlParameter = new SqlParameter(""@"" + fieldName, fieldSqlDbType);
            sqlParameter.Value = parameterValue;

            return sqlParameter;
        }

    }
}

        ";
    }

}