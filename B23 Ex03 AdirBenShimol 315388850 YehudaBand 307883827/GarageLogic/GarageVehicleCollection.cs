using GarageLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageLogic
{
    internal class GarageVehicleCollection
    {
        private readonly Dictionary<GarageAgent.eVehicelStatus, Dictionary<string, Vehicle>> r_Collection;
        private Dictionary<string, Vehicle> m_InnerPartitionPointer;

        internal GarageVehicleCollection()
        {
            r_Collection = new Dictionary<GarageAgent.eVehicelStatus, Dictionary<string, Vehicle>>
            {
                { GarageAgent.eVehicelStatus.InRepair, new Dictionary<string, Vehicle>() },
                { GarageAgent.eVehicelStatus.Repaired, new Dictionary<string, Vehicle>() },
                { GarageAgent.eVehicelStatus.Payed, new Dictionary<string, Vehicle>() }
            };
        }
        
        internal void AddNewVehicle(Vehicle i_Vehicle, GarageAgent.eVehicelStatus i_VehicleStatus)
        {
            string licensePlate = i_Vehicle.m_LicensePlate;
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

            foreach(GarageAgent.eVehicelStatus statusPartition in r_Collection.Keys)
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

        internal (Vehicle vehicle, GarageAgent.eVehicelStatus status) GetVehicleByLicensePlate(string i_LicensePlate)
        {
            Vehicle requestedVehicle = null;
            GarageAgent.eVehicelStatus currentStatus = GarageAgent.eVehicelStatus.Empty;

            if (IsVehicleExists(i_LicensePlate))
            {
                foreach (GarageAgent.eVehicelStatus statusPartition in r_Collection.Keys)
                {
                    setInnerPartitionPointer(statusPartition);
                    m_InnerPartitionPointer.TryGetValue(i_LicensePlate, out requestedVehicle);
                    if (requestedVehicle != null)
                    {
                        currentStatus = statusPartition;
                        break;
                    }
                }
            }
            else
            {
                throw new ArgumentException(paramName: ExceptionsMessageStrings.k_LicensePlateArg,
                                    message: ExceptionsMessageStrings.k_VehicleDoesNotExists);
            }

            return (requestedVehicle, currentStatus);
        }

        internal Dictionary<string, Vehicle> GetVehiclesByStatus(GarageAgent.eVehicelStatus i_VehicleStatus)
        {
            setInnerPartitionPointer(i_VehicleStatus);
            return m_InnerPartitionPointer;
        }

        internal void UpdateVehicleStaus(string i_LicensePlate, GarageAgent.eVehicelStatus i_UpdatedStatus)
        {
            (Vehicle vehicle, GarageAgent.eVehicelStatus status) vehicleRecord = GetVehicleByLicensePlate(i_LicensePlate);
            if (i_UpdatedStatus != GarageAgent.eVehicelStatus.Empty)
            {
                removeRecord(i_LicensePlate, vehicleRecord.status);
                addRecord(i_LicensePlate, vehicleRecord.vehicle, i_UpdatedStatus);
            }
        }

        internal List<string> GetAllVehicle()
        {
            List<string> allVehicles = new List<string>();

            foreach (GarageAgent.eVehicelStatus statusPartition in r_Collection.Keys)
            {
                setInnerPartitionPointer(statusPartition);
                allVehicles.AddRange(m_InnerPartitionPointer.Keys.ToList());
            }

            return allVehicles;
        }

        private void removeRecord(string i_LicensePlate, GarageAgent.eVehicelStatus i_InnerPartition)
        {
            setInnerPartitionPointer(i_InnerPartition);
            m_InnerPartitionPointer.Remove(i_LicensePlate);
        }

        private void addRecord(string i_LicensePlate, Vehicle i_Vehicle, GarageAgent.eVehicelStatus i_InnerPartition)
        {
            setInnerPartitionPointer(i_InnerPartition);
            m_InnerPartitionPointer.Add(i_LicensePlate, i_Vehicle);
        }

        private void setInnerPartitionPointer(GarageAgent.eVehicelStatus i_StatusPartition)
        {
            bool isStatusValid = r_Collection.TryGetValue(i_StatusPartition, out m_InnerPartitionPointer);
            
            if (!isStatusValid)
            {
                throw new ArgumentException(paramName: ExceptionsMessageStrings.k_InvalidVehicleStatus,
                                    message: ExceptionsMessageStrings.k_InvalidVehicleStatusMessage);
            }
        }

        public override string ToString()
        {
            /// TODO: Implement TOSTRING
            return base.ToString();
        }
    }
}
