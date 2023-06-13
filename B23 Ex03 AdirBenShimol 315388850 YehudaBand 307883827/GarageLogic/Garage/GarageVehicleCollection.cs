using System;
using System.Collections.Generic;
using System.Linq;
using GarageLogic.Exceptions;
using static GarageLogic.GarageAgent;


namespace GarageLogic
{
    internal class GarageVehicleCollection
    {
        private readonly Dictionary<eVehicelStatus, Dictionary<string, Vehicle>> r_Collection;
        private Dictionary<string, Vehicle> m_InnerPartitionPointer;

        internal GarageVehicleCollection()
        {
            r_Collection = new Dictionary<eVehicelStatus, Dictionary<string, Vehicle>>
            {
                { GarageAgent.eVehicelStatus.InRepair, new Dictionary<string, Vehicle>() },
                { GarageAgent.eVehicelStatus.Repaired, new Dictionary<string, Vehicle>() },
                { GarageAgent.eVehicelStatus.Paid, new Dictionary<string, Vehicle>() }
            };
        }
        
        internal void AddNewVehicle(Vehicle i_Vehicle, eVehicelStatus i_VehicleStatus)
        {
            string licensePlate = i_Vehicle.r_LicensePlate;
            
            if (!IsVehicleExists(licensePlate))
            {
                setInnerPartitionPointer(i_VehicleStatus);
                m_InnerPartitionPointer.Add(licensePlate, i_Vehicle);
            }
            else
            {
                throw new ArgumentException(paramName: ExceptionsMessageStrings.k_LicensePlateArg,
                                    message: ExceptionsMessageStrings.k_VehicleAlreadyExists);
            }
        }

        internal bool IsVehicleExists(string i_LicensePlate)
        {
            bool isExists = false;

            foreach(eVehicelStatus statusPartition in r_Collection.Keys)
            {
                setInnerPartitionPointer(statusPartition);
                isExists = m_InnerPartitionPointer.ContainsKey(i_LicensePlate);

                if (isExists)
                {
                    break;
                }
            }

            return isExists;
        }

        internal (Vehicle vehicle, eVehicelStatus status) GetVehicleByLicensePlate(string i_LicensePlate)
        {
            Vehicle requestedVehicle = null;
            eVehicelStatus currentStatus = GarageAgent.eVehicelStatus.Empty;

            if (IsVehicleExists(i_LicensePlate))
            {
                foreach (eVehicelStatus statusPartition in r_Collection.Keys)
                {
                    setInnerPartitionPointer(statusPartition);
                    m_InnerPartitionPointer.TryGetValue(i_LicensePlate, out requestedVehicle);

                    if (requestedVehicle != null)
                    {
                        currentStatus = statusPartition;
                        break;
                    }
                }

                requestedVehicle.VehicleStatus = currentStatus;
            }
            else
            {
                throw new ArgumentException(paramName: ExceptionsMessageStrings.k_LicensePlateArg,
                                    message: ExceptionsMessageStrings.k_VehicleDoesNotExists);
            }

            return (requestedVehicle, currentStatus);
        }

        internal Dictionary<string, Vehicle> GetVehiclesByStatus(eVehicelStatus i_VehicleStatus)
        {
            setInnerPartitionPointer(i_VehicleStatus);

            return m_InnerPartitionPointer;
        }

        internal void UpdateVehicleStaus(string i_LicensePlate, eVehicelStatus i_UpdatedStatus)
        {
            (Vehicle vehicle, eVehicelStatus status) vehicleRecord = GetVehicleByLicensePlate(i_LicensePlate);

            if (i_UpdatedStatus != GarageAgent.eVehicelStatus.Empty)
            {
                removeRecord(i_LicensePlate, vehicleRecord.status);
                addRecord(i_LicensePlate, vehicleRecord.vehicle, i_UpdatedStatus);
                vehicleRecord.vehicle.VehicleStatus = i_UpdatedStatus;
            }
        }

        internal List<string> GetAllVehicle()
        {
            List<string> allVehicles = new List<string>();

            foreach (eVehicelStatus statusPartition in r_Collection.Keys)
            {
                setInnerPartitionPointer(statusPartition);
                allVehicles.AddRange(m_InnerPartitionPointer.Keys.ToList());
            }

            return allVehicles;
        }

        private void removeRecord(string i_LicensePlate, eVehicelStatus i_InnerPartition)
        {
            setInnerPartitionPointer(i_InnerPartition);
            m_InnerPartitionPointer.Remove(i_LicensePlate);
        }

        private void addRecord(string i_LicensePlate, Vehicle i_Vehicle, eVehicelStatus i_InnerPartition)
        {
            setInnerPartitionPointer(i_InnerPartition);
            m_InnerPartitionPointer.Add(i_LicensePlate, i_Vehicle);
        }

        private void setInnerPartitionPointer(eVehicelStatus i_StatusPartition)
        {
            bool isStatusValid = r_Collection.TryGetValue(i_StatusPartition, out m_InnerPartitionPointer);
            
            if (!isStatusValid)
            {
                throw new ArgumentException(paramName: ExceptionsMessageStrings.k_VehicleStatusArg,
                                    message: ExceptionsMessageStrings.k_InvalidVehicleStatusMessage);
            }
        }

        public override string ToString()
        { 
            int inRepair = r_Collection[GarageAgent.eVehicelStatus.InRepair].Count;
            int alreadyRepaired = r_Collection[GarageAgent.eVehicelStatus.Repaired].Count; 
            int alreadyPaid = r_Collection[GarageAgent.eVehicelStatus.Paid].Count;
            int totalVehiclesStores = inRepair + alreadyRepaired + alreadyPaid;

            return string.Format(@"[ Garage Vehicles Collection ]
  [>] Total Vehicles: {0}
  [>] Vehicles in Repair: {1}
  [>] Vehicles Repaired: {2}
  [>] Vehicles Payed: {3}", totalVehiclesStores, inRepair, alreadyRepaired, alreadyPaid);
        }

        public override int GetHashCode()
        {
            return r_Collection.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            bool equals = false;
            GarageVehicleCollection collection = obj as GarageVehicleCollection;

            if (collection  != null)
            {
                equals = this.GetHashCode() == collection.GetHashCode();
            }

            return equals;
        }
    }
}
