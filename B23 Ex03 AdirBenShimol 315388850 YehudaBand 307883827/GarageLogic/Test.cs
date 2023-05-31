using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GarageLogic
{
    public class Test
    {
        public static void Main()
        {
            Vehicle v = VehicleBuilder.CreateVehicle("1234", (VehicleBuilder.eVehicleType)3);

            foreach (FieldInfo i in v.GetType().GetRuntimeFields())
            {
                Console.WriteLine(i.Name);
            }

            Console.WriteLine();

            foreach (PropertyInfo i in v.GetType().GetRuntimeProperties())
            {
                Console.WriteLine(i.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Ve fi");
            foreach (FieldInfo i in typeof(Vehicle).GetRuntimeFields())
            {
                Console.WriteLine(i.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Ve pro");
            foreach (PropertyInfo i in typeof(Vehicle).GetRuntimeProperties())
            {
                Console.WriteLine(i.Name);
            }
            Console.WriteLine();
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
