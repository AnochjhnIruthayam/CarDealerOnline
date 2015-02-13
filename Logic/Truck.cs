using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Truck : Vehicle
    {
        /// <summary>
        /// Inherts from Vehicle. Has 2 constructor one non-parameter and the second one with 5 parameters,
        /// also calling the constructor from the Vehicle. It has a capacity parameter to make it diffrent from 
        /// the car
        /// </summary>
        public Truck() { }

        public Truck(string model, string color, float price, string status, int capacity, string Bname):base(model,color,status,price,Bname)
        {
            _model = model;
            _color = color;
            _price = price;
            _status = status;
            _capacity = capacity;
            _buyerName = Bname;
        }

        private int _capacity;


        /// <summary>
        /// Property for capacity
        /// </summary>
        public int capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }
    }
}
