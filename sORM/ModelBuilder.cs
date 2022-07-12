using Shared;
using System.Data;
using System.Data.SqlClient;

namespace sORM
{
    public class ModelBuilder
    {
        private static readonly string ModelInstanceTemplateFileRelativePath = "ModelInstance.cs.txt";

        public static void BuildModelInstance(string dbConnectionString, string dbTableName)
        {
            // Get the column definitions from the DB table we're modeling
            DataTable dataTable_DBTableSchema;
            using (SqlConnection sqlConnection = new SqlConnection(dbConnectionString))
            {
                sqlConnection.Open();

                // You can specify the Catalog, Schema, Table Name, and/or Column Name to get the specified column(s).
                // For the array, member[0] represents Catalog; member[1] represents Schema; member[2] represents Table Name; member[3] represents Column Name.
                String[] columnRestrictions = new String[4];
                columnRestrictions[2] = dbTableName;
                dataTable_DBTableSchema = sqlConnection.GetSchema("Columns", columnRestrictions);
            }

            string modelInstanceTemplate = ModelTemplates.ModelInstanceTemplate;
            modelInstanceTemplate = modelInstanceTemplate.Replace("<<DatabaseTableName>>", dbTableName);

            // For table names, by convention we use plural names. However, for model class names, by convention
            // we use the singular form of the word
            string modelClassName;
            if (dbTableName.EndsWith("s"))
            {
                modelClassName = dbTableName.Substring(0, dbTableName.Length - "s".Length);
            }
            else
            {
                modelClassName = dbTableName;
                //throw new Exception($"Table name does not end in \"s\"; unable to guess the singular form of the table name (202207041812)");
            }
            modelInstanceTemplate = modelInstanceTemplate.Replace("<<ModelClassName>>", modelClassName);

            for (int i = 0; i < dataTable_DBTableSchema.Rows.Count; i++)
            {
                DataRow dataRow = dataTable_DBTableSchema.Rows[i];
                if (i == 0)
                {
                    if ((dataRow["COLUMN_NAME"].ToString() != Constants.DBColName__ALL__ID) && (dataRow["ORDINAL_POSITION"].ToString() != (i + 1).ToString()))
                    {
                        throw new Exception($"Column {i + 1} must be the \"{Constants.DBColName__ALL__ID}\" column; column \"{dataRow["COLUMN_NAME"]}\" was encountered instead (202207041849)");
                    }
                }
                else if (i == 1)
                {
                    if ((dataRow["COLUMN_NAME"].ToString() != Constants.DBColName__ALL__TenantID) && (dataRow["ORDINAL_POSITION"].ToString() != (i + 1).ToString()))
                    {
                        throw new Exception($"Column {i + 1} must be the \"{Constants.DBColName__ALL__TenantID}\" column; column \"{dataRow["COLUMN_NAME"]}\" was encountered instead (202207041852)");
                    }
                }
                else
                {
                }
            }

        }
    }
}