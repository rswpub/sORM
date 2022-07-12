using sORM;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter \"C\" to create a Model project, or any other key to exit: ");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
            Console.WriteLine("");
            Console.WriteLine("");

            if (consoleKeyInfo.Key == ConsoleKey.C)
            {
                // Add the Model project
                Console.WriteLine("Adding new Model project...");
                Console.WriteLine("");

                string datasourceName = @"X1-WICK\SQLEXPRESS";
                string initialCatalog = "TestDB_Deleteme";
                string dbConnectionString = $@"Data Source={datasourceName};Initial Catalog={initialCatalog};Integrated Security=true;";
                string dbTableName = "TestTable";
                ModelBuilder.BuildModelInstance(dbConnectionString, dbTableName);

                Console.WriteLine("New Model project successfully added.");
                Console.WriteLine("");

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey(false);
            }
            else
            {
                return;
            }
        }

    }
}