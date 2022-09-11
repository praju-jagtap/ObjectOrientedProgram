using OOP_Problems.CommercialDataProcessing;
using OOP_Problems.InventoryManagement;
using OOP_Problems.InventoryManagementSystem;
using OOP_Problems.StockAccountManagement;

namespace OOP_Problems
{
    internal class Program
    {
        const string INVENTORY_DATA_FILE_PATH = @"C:\GitRepository\ObjectOrientedProgram\OOP Problems\InventoryManagement\Inventory.json";
        const string INVENTORY_MANAGEMENT_DATA_FILE_PATH = @"C:\GitRepository\ObjectOrientedProgram\OOP Problems\InventoryManagementSystem\InventoryDetails.json";
        const string INVENTORY_STOCK_MANAGEMENT = @"C:\GitRepository\ObjectOrientedProgram\OOP Problems\StockAccountManagement\StockDetails.json";
        const string STOCK_ACCOUNT_MANAGEMENT = @"C:\GitRepository\ObjectOrientedProgram\OOP Problems\CommercialDataProcessing\Stock.json";
        const string COMPANY_ACCOUNT_MANAGEMENT = @"C:\GitRepository\ObjectOrientedProgram\OOP Problems\CommercialDataProcessing\Company.json";

        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1.Display Inventory\n2.To Print Inventory Details Operations\n3.Stock Account Management System\n4.Buy Or Sell Company Share\n");
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

                    case 2:
                        bool flag1 = true;
                        while (flag1)
                        {
                            Console.WriteLine("1.Add List\n2.Delete List\n3.Edit List");
                            Console.WriteLine("Please Enter Your Choice");
                            Console.WriteLine("---------------------------------------------------");
                            int option1 = Convert.ToInt32(Console.ReadLine());

                            switch (option1)
                            {
                                case 1:
                                    InventoryFactory factory = new InventoryFactory();
                                    factory.ReadJsonFile(INVENTORY_MANAGEMENT_DATA_FILE_PATH);
                                    InventoryDetail detail = new InventoryDetail()
                                    {
                                        Name = "Masura",
                                        Weight = 13,
                                        Price = 240
                                    };
                                    factory.AddInventory("RiceList", detail);
                                    factory.WriteToJson(INVENTORY_MANAGEMENT_DATA_FILE_PATH);
                                    Console.WriteLine("----------------------------------------------");
                                    break;

                                case 2:
                                    InventoryFactory factory1 = new InventoryFactory();
                                    factory1.ReadJsonFile(INVENTORY_MANAGEMENT_DATA_FILE_PATH);
                                    InventoryDetail detail1 = new InventoryDetail()
                                    {
                                        Name = "Spelt",
                                        Weight = 25,
                                        Price = 200
                                    };
                                    factory1.DeleteInventory("WheatList", "Spelt");
                                    factory1.WriteToJson(INVENTORY_MANAGEMENT_DATA_FILE_PATH);
                                    Console.WriteLine("----------------------------------------------");
                                    break;

                                case 3:
                                    InventoryFactory factory2 = new InventoryFactory();
                                    factory2.ReadJsonFile(INVENTORY_MANAGEMENT_DATA_FILE_PATH); 
                                    factory2.EditInventory("PulsesList", "Pigeon");
                                    factory2.WriteToJson(INVENTORY_MANAGEMENT_DATA_FILE_PATH);
                                    Console.WriteLine("----------------------------------------------");
                                    break;

                                default:
                                    Console.WriteLine("Invalid Choice");
                                    break;
                            }
                        }
                    break;

                    case 3:
                        Console.WriteLine("------------------------Stock Account Management----------------------\n");
                        CreateStock createStock = new CreateStock();
                        createStock.ReadJsonFile(INVENTORY_STOCK_MANAGEMENT);
                        Console.WriteLine("----------------------------------------------\n");
                        break;

                    case 4:
                        StockManagement stockManagement = new StockManagement();
                        stockManagement.ReadJsonFileStock(STOCK_ACCOUNT_MANAGEMENT);
                        stockManagement.ReadJsonFileCompany(COMPANY_ACCOUNT_MANAGEMENT);
                        Company company = new Company()
                        {
                            Symbol = "Facebook",
                            NoOfShare = 5,
                            PricePerShare = 10,
                        };
                        stockManagement.BuyCompanyShare(company);
                        stockManagement.WriteToJsonStock(STOCK_ACCOUNT_MANAGEMENT);
                        stockManagement.WriteToJsonCompany(COMPANY_ACCOUNT_MANAGEMENT);
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
  
