using Newtonsoft.Json;
using OOP_Problems.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Problems.InventoryManagementSystem
{
    internal class InventoryFactory
    {
        InventoryManagement inventory = new InventoryManagement();
        public void ReadJsonFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                var json = reader.ReadToEnd();
                this.inventory = JsonConvert.DeserializeObject<InventoryManagement>(json);
                Console.WriteLine("----------------- Display Before Any Operation ----------------\n");
                Display(this.inventory.RiceList,"RiceList");
                Console.WriteLine("----------------- Display Before Any Operation ----------------\n");
                Display(this.inventory.WheatList,"WheatList");
                Console.WriteLine("----------------- Display Before Any Operation ----------------\n");
                Display(this.inventory.PulsesList,"PulsesList");
            }
        }
        public void AddInventory(string inventoryName, InventoryDetail detail)
        {
            if (inventoryName == "RiceList")
            {
                this.inventory.RiceList.Add(detail);
                Console.WriteLine("------------------------ Display After Added Inventory Management----------------------\n");
                Display(this.inventory.RiceList, "RiceList");
                return;
            }
            if (inventoryName == "WheatList")
            {
                this.inventory.WheatList.Add(detail);
                Display(this.inventory.WheatList, "WheatList");
                return;
            }
            if (inventoryName == "PulsesList")
            {
                this.inventory.PulsesList.Add(detail);
                Display(this.inventory.PulsesList, "PulsesList");
                return;
            }
        }
        public void DeleteInventory(string inventoryName, string inventoryDetailName)
        {
            if (inventoryName == "RiceList")
            {
                foreach (var data in this.inventory.RiceList)
                {
                    if (data.Name == inventoryDetailName)
                    {
                        this.inventory.RiceList.Remove(data);
                        Display(this.inventory.RiceList, "RiceList");
                        return;
                    }
                }
                Console.WriteLine("Inventory Details Does Not Exit");
            }
            if (inventoryName == "WheatList")
            {
                foreach (var data in this.inventory.WheatList)
                {
                    if (data.Name == inventoryDetailName)
                    {
                        this.inventory.WheatList.Remove(data);
                        Console.WriteLine("------------------------ Display After Deleted Inventory Management----------------------\n");
                        Display(this.inventory.WheatList, "WheatList");
                        return;
                    }
                }
                Console.WriteLine("Inventory Details Does Not Exit");
            }
            if (inventoryName == "PuleseList")
            {
                foreach (var data in this.inventory.PulsesList)
                {
                    if (data.Name == inventoryDetailName)
                    {
                        this.inventory.PulsesList.Remove(data);
                        Display(this.inventory.PulsesList, "PulsesList");
                        return;
                    }
                }
                Console.WriteLine("Inventory Details Does Not Exit");
            }
        }
        public void EditInventory(string inventoryName, string inventoryDetailName)
        {
            Console.WriteLine("Enter Any One Of State - [RiceList, WheatList, PulsesList] Which You Want To Edit:");
            string InventoryDetail = Console.ReadLine();

            if (inventoryName == "RiceList")
            {
                Console.WriteLine("enter the Rice name which you want to edit: ");
                string RiceList = Console.ReadLine();
                foreach (var data in this.inventory.RiceList)
                {
                    if (data.Name == inventoryDetailName)
                    {
                        Console.WriteLine("To Edit RiceList Enter 1.Weight 2.Price");
                        int input = Convert.ToInt32(Console.ReadLine());
                        switch (input)
                        {
                            case 1:
                                data.Weight = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 2:
                                data.Price = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Choose Valid Option");
                                break;
                        }
                    }
                }
            }
            if (inventoryName == "WheatList")
            {
                Console.WriteLine("enter the Wheat name which you want to edit");
                string Name = Console.ReadLine();
                foreach (var data in this.inventory.WheatList)
                {
                    if (data.Name == inventoryDetailName)
                    {
                        Console.WriteLine("To Edit WheatList Enter 1.Weight 2.Price");
                        int input = Convert.ToInt32(Console.ReadLine());
                        switch (input)
                        {
                            case 1:
                                data.Weight = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 2:
                                data.Price = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Choose Valid Option");
                                break;
                        }
                    }
                }
            }
            if (inventoryName == "PulsesList")
            {
                Console.WriteLine("enter the Pulses name which you want to edit: ");
                string Name = Console.ReadLine();
                foreach (var data in this.inventory.PulsesList)
                {
                    if (data.Name == inventoryDetailName)
                    {
                        Console.WriteLine("To Edit PulsesList Enter 1.Weight 2.Price");
                        int input = Convert.ToInt32(Console.ReadLine());
                        switch (input)
                        {
                            case 1:
                                data.Weight = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 2:
                                data.Price = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Choose Valid Option");
                                break;
                        }
                    }
                }
                Console.WriteLine("------------------------ Display After Edited Inventory Management----------------------\n");
                Display(this.inventory.PulsesList, "PulsesList");
            }
        }
        public void WriteToJson(string filePath)
        {
            var json = JsonConvert.SerializeObject(this.inventory);
            File.WriteAllText(filePath, json);
        }
        public void Display(List<InventoryDetail> list, string inventoryName)
        {
            Console.WriteLine("Inventory Details is :" + inventoryName);
            Console.WriteLine("Name" + "\t" + "Weight" + "\t" + "Price");
            foreach (var data in list)
            {
                Console.WriteLine(data.Name + "\t" + data.Weight + "\t" + data.Price);
            }
        }
    }
}