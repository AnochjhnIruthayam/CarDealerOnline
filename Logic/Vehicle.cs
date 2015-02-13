using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
  public class Vehicle
    {
        /// <summary>
        /// Basic class which contains 4 parameters for Vehicle. The Car class is inheriting after that one.
        /// It has 2 constructors: one is no-parameter and the second is taking 4 parameters.
        /// </summary>
      public Vehicle() { }
      public Vehicle(string model, string color, string status, float price, string buyerName)
      {
          _model = model;
          _color = color;
          _price = price;
          _status = status;
          _buyerName = buyerName;
      }
        protected string _buyerName;
        protected float _price;
        protected string _color;
        protected string _model;
        protected string _status;
        

      /// <summary>
      /// Property for each parameters
      /// </summary>

      public string buyerName
      {
          get { return _buyerName; }
          set { _buyerName = value; }
      }

      public float price
      {
          get { return _price; }
          set { _price = value; }
      }

      public string color
      {
          get { return _color; }
          set { _color = value; }
      }

      public string model
      {
          get { return _model; }
          set { _model = value; }
      }
      public string status
      {
          get { return _status; }
          set { _status = value; }
      }


    }
}
