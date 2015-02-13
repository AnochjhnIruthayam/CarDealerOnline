using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
   public class Large : Car
    {
        /// <summary>
        /// Inherts from the Car class. Contains two constructor. One non-parameter and one with 5 parameters
        /// calling a constructor from the Car class. It has a capacity parameter.
        /// </summary>

       public Large() { }

       public Large(string model, string color, float price, string status, int largeCarCapacity, string Bname):base(model,color,price,status, Bname)
       {
           _model = model;
           _color = color;
           _price = price;
           _status = status;
           _largeCarCapacity = largeCarCapacity;
           _buyerName = Bname;
       }
       private int _largeCarCapacity;

       /// <summary>
       /// Property for largeCarCapacity
       /// </summary>
       public int largeCarCapacity
       {
           get { return _largeCarCapacity; }
           set { _largeCarCapacity = value; }
       }
    }
}
