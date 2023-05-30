using GarageLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class GarageVehicleCollection
    {
        private readonly Dictionary<GarageAgent.eVehicelStatus, Dictionary<string, Vehicle>> r_GarageVehicleStore;

        internal GarageVehicleCollection()
        {
            r_GarageVehicleStore = new Dictionary<GarageAgent.eVehicelStatus, Dictionary<string, Vehicle>>();
        }

        internal bool IsVehicleExists(string i_LicencePlate)
        {
            bool isVehicleExists = false;
            foreach (Dictionary<string, Vehicle> dict in r_GarageVehicleStore.Values)
            {
                if (isVehicleExists  = dict.TryGetValue(i_LicencePlate, out Vehicle vehicle))
                {
                    break;
                }
            }
            return isVehicleExists;
        }

        internal Vehicle FetchByLicencePlate(string i_LicencePlate)
        {
            /// maybe better to try...catch (no user of TryGetValue)
            Vehicle vehicle = null;
            bool isVehicleExists = false;
         
            foreach (Dictionary<string, Vehicle> dict in r_GarageVehicleStore.Values)
            {
                if (isVehicleExists  = dict.TryGetValue(i_LicencePlate, out vehicle))
                {
                    break;
                }
            }

            if (!isVehicleExists)
            {
                //throw new VehicleDoesNotExistsException();
                throw new ArgumentException();
            }
            return vehicle;
        }

        internal List<Vehicle> FetchByStatus(GarageAgent.eVehicelStatus i_VehicleStatus) 
        {
            Dictionary<string, Vehicle> vehicles;
            if (!r_GarageVehicleStore.TryGetValue(i_VehicleStatus, out vehicles))
            {
                throw new Exception();
            }
            return vehicles.Values.ToList();
        }
    }
}
