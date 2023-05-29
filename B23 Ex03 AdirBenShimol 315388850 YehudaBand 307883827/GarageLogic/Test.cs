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
            VehicleBuilder.eVehicleType vType = (VehicleBuilder.eVehicleType) typeNumber;

            Vehicle v = VehicleBuilder.GetVehicle("123", vType);
            Console.WriteLine(v);

            foreach(PropertyInfo p in  v.GetType().GetRuntimeProperties())
            {
                string i = (p.GetValue(v) == null) ? string.Empty : p.Name;
                Console.WriteLine(p.Name + ": " + p.GetValue(v) + " " + i);
            }
        }
    }
}
