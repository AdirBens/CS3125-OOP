using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Test
    {
        public static void Main()
        {
            Console.WriteLine("type number:");
            int.TryParse(Console.ReadLine(), out int typeNumber);

            Vehicle v = VehicleBuilder.CreateVehicle("1234", (VehicleBuilder.eVehicleType)3);
            List<PropertyInfo> properties = v.GetType().GetRuntimeProperties().ToList();

            foreach(PropertyInfo property in properties)
            {
                try
                {
                    Console.WriteLine(property.Name + " [ " + printArr(property.PropertyType.GetEnumNames()) + " ]");    
                }
                catch(ArgumentException aex) 
                { 
                    Console.WriteLine(property.Name);                
                }
            }
        }

        private static string printArr(string[] arr)
        {
            StringBuilder s = new StringBuilder();
            foreach (string item in arr)
            {
                s.Append(" " + item + ", ");
            }

            return s.ToString();
        }
    }
}
/*         Dictionary<string, string[]> s = GarageAgent.GetRequireadDetails("123", typeNumber);
         foreach (string property in s.Keys)
         {
             Console.WriteLine(property);
             if (s[property] != null)
             {
                 printArr(s[property]);
             }

         }
     }
     */