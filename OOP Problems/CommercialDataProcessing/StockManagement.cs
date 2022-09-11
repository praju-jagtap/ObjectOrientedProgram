using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Problems.CommercialDataProcessing
{
    internal class StockManagement
    {
        List<Stock> stockList = new List<Stock>();
        List<Company> companyList = new List<Company>();
        public void ReadJsonFileStock(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                var json = reader.ReadToEnd();
                this.stockList = JsonConvert.DeserializeObject<List<Stock>>(json);
                Console.WriteLine("----------------- Before Buy Share Stock List -------------------\n");
                Console.WriteLine("Name" + "\t" + "NoOfShare" + "\t" + "PricePerShare");
                foreach (var data in stockList)
                {
                    Console.WriteLine(data.Name + "\t\t" + data.NoOfShare + "\t\t" + data.PricePerShare);
                }
            }
        }
        public void ReadJsonFileCompany(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                var json = reader.ReadToEnd();
                this.companyList = JsonConvert.DeserializeObject<List<Company>>(json);
                Console.WriteLine("---------------- Before Buy Share Company List -------------------\n");
                Console.WriteLine("Symbol" + "\t" + "NoOfShare" + "\t" + "PricePerShare");
                foreach (var data in companyList)
                {
                    Console.WriteLine(data.Symbol + "\t\t" + data.NoOfShare + "\t\t" + data.PricePerShare);
                }
            }
        }
        public void BuyCompanyShare(Company company)
        {
            bool flag = false;
            foreach (var companyDetails in companyList)
            {
                if (companyDetails.Symbol == company.Symbol)
                {
                    companyDetails.NoOfShare -= company.NoOfShare;
                }
            }
            foreach (var stockDetails in stockList)
            {
                if (stockDetails.Name == company.Symbol)
                {
                    stockDetails.NoOfShare += company.NoOfShare;
                    flag = true;
                }
            }
            if (!flag)
            {
                Stock stock = new Stock();
                stock.Name = company.Symbol;
                stock.NoOfShare = company.NoOfShare;
                stock.PricePerShare = company.PricePerShare;
                stockList.Add(stock);
            }
        }
        public void WriteToJsonStock(string filePath)
        {
            var json = JsonConvert.SerializeObject(this.stockList);
            Console.WriteLine("------------------ After Buy Share Stock List -------------------\n");
            Console.WriteLine("Name" + "\t" + "NoOfShare" + "\t" + "PricePerShare");
            foreach (var data in stockList)
            {
                Console.WriteLine(data.Name + "\t\t" + data.NoOfShare + "\t\t" + data.PricePerShare);
            }
            File.WriteAllText(filePath, json);
        }
        public void WriteToJsonCompany(string filePath)
        {
            var json = JsonConvert.SerializeObject(this.companyList);
            Console.WriteLine("---------------- After Buy Share Company List -----------------\n");
            Console.WriteLine("Symbol" + "\t" + "NoOfShare" + "\t" + "PricePerShare");
            foreach (var data in companyList)
            {
                Console.WriteLine(data.Symbol + "\t\t" + data.NoOfShare + "\t\t" + data.PricePerShare);
            }
            File.WriteAllText(filePath, json);
            Console.WriteLine("-------------------------------------\n");
        }
    }
}
