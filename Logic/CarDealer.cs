using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Logic
{

    /// <summary>
    /// /// It's the main class.It contains the list of Customers and Vehicles.
    ///
    /// </summary>
    public class CarDealer
    {
      private List<PrivateCustomer> PrivateCustomerList = new List<PrivateCustomer>();
      private List<BusinessCustomer> BusinessCustomerList = new List<BusinessCustomer>();
      private List<Small> CarSmallList = new List<Small>(); 
      private List<Large> CarLargeList = new List<Large>();
      private List<Truck> TruckList = new List<Truck>();
      public delegate void StatusSender(string sender);
     

        static void Main(string[] args)
        {
          
        }

        /// <summary>
        /// a method which create a LargeCar object and putting it to the list of Large Cars
        /// </summary>
        /// <param name="oLarge">create a new LargeCar object</param>
        public void AddLargeCar(Large oCarList)
        {
            CarLargeList.Add(oCarList);
        }

        /// <summary>
        /// Get LargeCar List
        /// </summary>
        /// <returns>Get LargeCar List</returns>
        public List<Large> GetLargeCar()
        {
            return CarLargeList;
        }

        /// <summary>
        // a method which create a SmallCar object and putting it to the list of Small Cars
        /// </summary>
        /// <param name="oSmall">create a new Small Car object</param>
        public void AddSmallCar(Small oCarList)
        {
            CarSmallList.Add(oCarList);
        }

        /// <summary>
        /// Get SmallCar List
        /// </summary>
        /// <returns>Get SmallCar List</returns>
        public List<Small> GetSmallCar()
        {
            return CarSmallList;
        }


        /// <summary>
        /// method to add a Truck to the TruckList
        /// </summary>
        /// <param name="oTruck">create a new Truck object</param>
        public void AddTruck(Truck oTruckList)
        {
            TruckList.Add(oTruckList);
        }

        /// <summary>
        /// Get TruckList
        /// </summary>
        /// <returns>Returns TruckList</returns>
        public List<Truck> GetTruck()
        {
            return TruckList;
        }

        /// <summary>
        ///  method to add a new Private Customer to the PrivateCustomer list
        /// </summary>
        /// <param name="oPrivateCustomer">reate a new Private Customer</param>
        public void AddPrivateCustomer(PrivateCustomer oPrivateCustomer)
        {
            PrivateCustomerList.Add(oPrivateCustomer);
        }


        /// <summary>
        /// Get PrivateCustomerList
        /// </summary>
        /// <returns>Get PrivateCustomerList</returns>
        public List<PrivateCustomer> GetPrivateCustomer()
        {
            return PrivateCustomerList;
        }

        /// <summary>
        /// method to add a new Business Customer to the BusinessCustomer list
        /// </summary>
        /// <param name="oBusinnessCustomer">create a new Business Customer </param>
        public void AddBusinessCustomer(BusinessCustomer oBusinnessCustomer)
        {
            BusinessCustomerList.Add(oBusinnessCustomer);
        }


        /// <summary>
        /// Get BuisnessCostumerlist
        /// </summary>
        /// <returns>Get BuisnessCostumerlist</returns>
        public List<BusinessCustomer> GetBusinessCustomer()
        {
            return BusinessCustomerList;
        }

    }      
    
}
