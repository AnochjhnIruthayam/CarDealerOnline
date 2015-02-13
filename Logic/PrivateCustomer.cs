using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class PrivateCustomer : Customer
    {
        /// <summary>
        /// Inherts after the Customer class. Contains two constructor. one non-parameter and second with
        /// 5 parameters and calling the constructor from  Customer class. It has 2 parameter, age and sex
        /// to describe a PrivateCustomer
        /// </summary>

        private int _age = 0;
        private string _sex;

        public PrivateCustomer() { }

        public PrivateCustomer(string name, string address, int phone, int age, string sex)
            : base(name, address, phone)
        {
            this._name      = name;
            this._address   = address;
            this._phone     = phone;
            this._age       = age;
            this._sex       = sex;
        }


        /// <summary>
        /// property for each parameter
        /// </summary>
        
        public int age
        { 
            get {return _age;}
            set { _age = value;}
        }
        public string sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        
       

    }
}
