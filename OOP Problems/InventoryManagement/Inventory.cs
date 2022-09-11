using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Problems.InventoryManagement
{
    internal class Inventory
    {
        List<InventoryDetail> details = new List<InventoryDetail>();
        public void ReadJsonFile(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                var json = reader.ReadToEnd();
                this.details = JsonConvert.DeserializeObject<List<InventoryDetail>>(json);
                Console.WriteLine("Name" + "\t" + "Weight" + "\t" + "Price" + "\t" + "PricePerKg");
                foreach (var data in details)
                {
                    Console.WriteLine(data.Name + "\t" + data.Weight + "\t" + data.Price + "\t" + (data.Weight+data.Price));
                }
            }
        }
    }
}
