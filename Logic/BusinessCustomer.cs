using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
   public class BusinessCustomer : Customer
    {
        /// <summary>
        /// Inherts after the Customer class. Has a 2 constructors, one non-parameter and one with 6 parameters
        /// It calls also a constructor from the Customer. It contains 3 parameters which describe the Business Customer
        /// </summary>
        private int _SEnr;
        private int _Fax;
        private string _ContactPerson;

        public BusinessCustomer() { }

        public BusinessCustomer(string name, string address, int phone, int SEnr, int fax, string ContactPerson)
            :base(name,address,phone)
        {
            this._name = name;
            this._address = address;
            this._phone = phone;
            this._SEnr = SEnr;
            this._Fax = fax;
            this._ContactPerson = ContactPerson;
        }



       /// <summary>
       /// Property for each parameters
       /// </summary>
        public int SEnr
        {
            get { return _SEnr; }
            set { _SEnr = value; }
        }
        public int fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        public string ContactPerson
        {
            get { return _ContactPerson; }
            set { _ContactPerson = value; }
        }


    }
}
