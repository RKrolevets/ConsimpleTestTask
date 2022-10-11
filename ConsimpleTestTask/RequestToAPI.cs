using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ConsimpleTestTask
{
    public class RequestToAPI
    {
        public static void Execute ()
        {
            Console.Clear();

            var request = WebRequest.Create("http://tester.consimple.pro");
            var response = request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();

            Deserializer deserializer = JsonSerializer.Deserialize<Deserializer>(json);
            
            var t = new TablePrinter("Product name", "Category name");
            foreach (var product in deserializer.Products)
            {
                string productName = product.Name;
                string categoryName = deserializer.Categories.First(x => product.CategoryId == x.Id).Name;
                t.AddRow(productName, categoryName);
            }
            t.Print();
        }
    }
}
