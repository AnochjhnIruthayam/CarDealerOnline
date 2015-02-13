using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
   public class Customer
    {
        /// <summary>
        /// Class which contains 2 constructor. one non-parameter and one with 3 parameters. Two classes
        /// (PrivateCustomer and BusinessCustomer) inherts from that one. this class contains three parameters: name, address and phone
        /// </summary>

        protected string _name;
        protected string _address;
        protected int _phone = 0;

       public Customer() { }

       public Customer(string name, string address, int phone)
       {
           this._name       = name;
           this._address    = address;
           this._phone      = phone;
       }

       /// <summary>
       /// Property for each parameter
       /// </summary>

        public string name
        {
            get { return _name; }
            set { _name = value; }

        }

        public string address
        {
            get { return _address; }
            set {_address=value;}
        }

        public int phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
       

       
    }
}
