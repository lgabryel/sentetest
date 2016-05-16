using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
  class Program
  {
    static void Main(string[] args)
    {
      var connstr = ConfigurationManager.ConnectionStrings["Main"].ConnectionString;
      using (FbConnection connection = new FbConnection(connstr))
      {
        connection.Open();
        using (FbCommand command = connection.CreateCommand())
        {
          command.CommandText = "select * from products";
          using(var result = command.ExecuteReader()) {
             while(result.Read()) {
               var id = (int) result["ID"];
               var name = (string) result["PRODUCT_NAME"];
               var price = (decimal) result["PRODUCT_PRICE"];

               Console.WriteLine("{0}\t{1}\t{2:f}", id, name, price);
             }
          }
        }
      }
      Console.WriteLine("OK");
    }
  }
}
