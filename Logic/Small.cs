using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
 public class Small : Car
    {
        /// <summary>
        /// Inherts after the Car class. It has two constructor . One non-parameter and one with 5 parameters
        /// and calling the Car constructor. It has weight parameter which describes the Small cars.
        /// </summary>
     public Small(){}
     public Small(string model, string color,string status, float price,int weight, string Bname):base(model,color,price,status, Bname)
      {
          _model = model;
          _color = color;
          _price = price;
          _status = status;
          _weight = weight;
          _buyerName = Bname;
      }
     private int _weight;

     /// <summary>
     /// Property for weight
     /// </summary>
     public int weight
     {
         get { return _weight; }
         set { _weight = value; }
     }
    }
}
