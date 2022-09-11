using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Problems.StockAccountManagement
{
    internal class CreateStock
    {
        List<StockPortfolio> stock = new List<StockPortfolio>();
        public void ReadJsonFile(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                var json = reader.ReadToEnd();
                this.stock = JsonConvert.DeserializeObject<List<StockPortfolio>>(json);
                Console.WriteLine("ShareName" + "\t" + "NoOfShare" + "\t" + "SharePrice" + "\t" + "TotalShare");
                foreach (var data in stock)
                {
                    Console.WriteLine(data.ShareName + "\t" + data.NumberOfShare + "\t" + data.SharePrice + "\t" + (data.NumberOfShare * data.SharePrice));
                }
            }
        }
    }
}
