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

        static void AddNewModelProject()
        {

        }
    }
}