using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

using Logic;

namespace Serialize
{
    public class XML
    {
        /// <summary>
        /// Create path where project map is
        /// </summary>
        string ContractListPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ContractList.xml");
        string LeasingListPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LeasingList.xml");
        string SmallListPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SmallList.xml");
        string LargeListPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LargeList.xml");
        string TruckListPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TruckList.xml");
        string PrivateCustomerPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PrivateCustomer.xml");
        string BusinessCustomerPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BusinessCustomer.xml");

        /// <summary>
        /// Serialize for ContractList
        /// </summary>
        /// <param name="ContractList">Serialize for ContractList</param>
        public void SerializeContract(List<Contract> ContractList)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(List<Contract>));
            TextWriter textWriter = new StreamWriter(ContractListPath);
            serializer.Serialize(textWriter, ContractList);
            textWriter.Close();

        }

        /// <summary>
        /// Read ContractList and load to list
        /// </summary>
        /// <returns>Read ContractList</returns>
        public List<Contract> DeSerializeContract()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Contract>));
            TextReader textReader = new StreamReader(ContractListPath);
            List<Contract> ContractList;
            ContractList = (List<Contract>)deserializer.Deserialize(textReader);
            textReader.Close();

            return ContractList;
        }

        /// <summary>
        /// Serialize Leasinglist
        /// </summary>
        /// <param name="LeasingList">Serialize Leasinglist</param>
        public void SerializeLeasing(List<Leasing> LeasingList)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(List<Leasing>));
            TextWriter textWriter = new StreamWriter(LeasingListPath);
            serializer.Serialize(textWriter, LeasingList);
            textWriter.Close();

        }

        /// <summary>
        /// Read LeasingList and load to list
        /// </summary>
        /// <returns>Read LeasingList and load to list</returns>
        public List<Leasing> DeSerializeLeasing()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Leasing>));
            TextReader textReader = new StreamReader(LeasingListPath);
            List<Leasing> LeasingList;
            LeasingList = (List<Leasing>)deserializer.Deserialize(textReader);
            textReader.Close();

            return LeasingList;
        }


        /// <summary>
        ///  Serialize SmallCarList
        /// </summary>
        /// <param name="SmallList">Serialize SmallCarList</param>
        public void SerializeCarSmall(List<Small> SmallList)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(List<Small>));
            TextWriter textWriter = new StreamWriter(SmallListPath);
            serializer.Serialize(textWriter, SmallList);
            textWriter.Close();

        }

        /// <summary>
        /// Read SmallCarList and load to list
        /// </summary>
        /// <returns>Read SmallCarList and load to list</returns>
        public List<Small> DeSerializeCarSmall()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Small>));
            TextReader textReader = new StreamReader(SmallListPath);
            List<Small> CSmallList;
            CSmallList = (List<Small>)deserializer.Deserialize(textReader);
            textReader.Close();

            return CSmallList;
        }

        /// <summary>
        /// Serialize LargeCarList
        /// </summary>
        /// <param name="LargeList">Serialize LargeCarList</param>
        public void SerializeCarLarge(List<Large> LargeList)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(List<Large>));
            TextWriter textWriter = new StreamWriter(LargeListPath);
            serializer.Serialize(textWriter, LargeList);
            textWriter.Close();

        }

        /// <summary>
        /// Read LargeCarList and load to list
        /// </summary>
        /// <returns>Read LargeCarList and load to list</returns>
        public List<Large> DeSerializeCarLarge()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Large>));
            TextReader textReader = new StreamReader(LargeListPath);
            List<Large> CLargeList;
            CLargeList = (List<Large>)deserializer.Deserialize(textReader);
            textReader.Close();

            return CLargeList;
        }


        /// <summary>
        /// Serialize TruckList
        /// </summary>
        /// <param name="TruckList">Serialize TruckList</param>
        public void SerializeTruck(List<Truck> TruckList)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(List<Truck>));
            TextWriter textWriter = new StreamWriter(TruckListPath);
            serializer.Serialize(textWriter, TruckList);
            textWriter.Close();

        }

        /// <summary>
        /// Serialize PrivateCustomerList
        /// </summary>
        /// <param name="PrivateCustomerList">Serialize PrivateCustomerList</param>
        public void SerializePC(List<PrivateCustomer> PrivateCustomerList)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(List<PrivateCustomer>));
            TextWriter textWriter = new StreamWriter(PrivateCustomerPath);
            serializer.Serialize(textWriter, PrivateCustomerList);
            textWriter.Close();

        }

        /// <summary>
        /// Serialize BusinessCustomerList
        /// </summary>
        /// <param name="BusinessCustomerList">Serialize BusinessCustomerList</param>
        public void SerializeBC(List<BusinessCustomer> BusinessCustomerList)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(List<BusinessCustomer>));
            TextWriter textWriter = new StreamWriter(BusinessCustomerPath);
            serializer.Serialize(textWriter, BusinessCustomerList);
            textWriter.Close();
        }

        /// <summary>
        /// Read PrivateCustomerList and load to list
        /// </summary>
        /// <returns>Read PrivateCustomerList and load to list</returns>
        public List<PrivateCustomer> DeSerializePC()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<PrivateCustomer>));
            TextReader textReader = new StreamReader(PrivateCustomerPath);
            List<PrivateCustomer> PCList;
            PCList = (List<PrivateCustomer>)deserializer.Deserialize(textReader);
            textReader.Close();

            return PCList;
        }


        /// <summary>
        /// Read TruckList and load to list
        /// </summary>
        /// <returns>Read TruckList and load to list</returns>
        public List<Truck> DeSerializeTruck()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Truck>));
            TextReader textReader = new StreamReader(TruckListPath);
            List<Truck> TList;
            TList = (List<Truck>)deserializer.Deserialize(textReader);
            textReader.Close();

            return TList;
        }

        /// <summary>
        /// Read BusinessCustomerList and load to list
        /// </summary>
        /// <returns>Read BusinessCustomerList and load to list</returns>
        public List<BusinessCustomer> DeSerializeBC()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<BusinessCustomer>));
            TextReader textReader = new StreamReader(BusinessCustomerPath);
            List<BusinessCustomer> BCList;
            BCList = (List<BusinessCustomer>)deserializer.Deserialize(textReader);
            textReader.Close();

            return BCList;
        }
    }
    
}
