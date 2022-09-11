using OOP_Problems.InventoryManagement;

namespace OOP_Problems
{
    internal class Program
    {
        const string INVENTORY_DATA_FILE_PATH = @"C:\GitRepository\ObjectOrientedProgram\OOP Problems\InventoryManagement\Inventory.json";
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1.Display Inventory\n");
                Console.WriteLine("Please Enter Your Choice");
                Console.WriteLine("---------------------------------------------------");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("----------------- Display Inventory --------------------\n");
                        Inventory inventory = new Inventory();
                        inventory.ReadJsonFile(INVENTORY_DATA_FILE_PATH);
                        Console.WriteLine("------------------------------------------------");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
  
