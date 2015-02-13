using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
  public class Car : Vehicle
    {
        /// <summary>
        /// Car class inherts from Vehicle. It has 2 constructors: one non-parameter and second which takes
        /// 4 parameters and also call a constructor from Vehicle
        /// </summary>
       public Car() { }

       public Car(string model, string color, float price,string status, string Bname)
           : base(model, color, status, price, Bname)
       {
      
          _model = model;
          _color = color;
          _price = price;
          _status = status;
          _buyerName = Bname;
      
       }

       

    }
}
