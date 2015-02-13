using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
   public class Leasing
    {
       /// <summary>
       /// Contains two constructors one without parameter and one with parameters. the parameters is CarModel, buyername, rentmonth, rent period and start date
       /// </summary>

       public Leasing() { }

       public Leasing(string LeasingCarModel, string LeasingBuyerName, int LeasingrentMonth, int LeasingrentPeriod, DateTime LeasingstartDate)
       {
           _LeasingCarModel = LeasingCarModel;
           _LeasingBuyerName = LeasingBuyerName;
           _LeasingrentMonth = LeasingrentMonth;
           _LeasingrentPeriod = LeasingrentPeriod;
           _LeasingstartDate = LeasingstartDate;
       }

       private string _LeasingCarModel;
       private string _LeasingBuyerName;
       private int _LeasingrentMonth;
       private int _LeasingrentPeriod;
       private DateTime _LeasingstartDate;

       /// <summary>
       /// Create List of Leasing
       /// </summary>
       private List<Leasing> LeasingList = new List<Leasing>();


       /// <summary>
       /// Add leasing to the list
       /// </summary>
       /// <param name="oLeasing"></param>

       public void AddLeasing(Leasing oLeasing)
       {
           LeasingList.Add(oLeasing);
       }

       /// <summary>
       /// Get Leasinglist
       /// </summary>
       /// <returns>Get Leasinglist</returns>
       public List<Leasing> GetLeasingList()
       {
           return LeasingList;
       }



       /// <summary>
       /// Propertys for each paramters
       /// </summary>

       public string LeasingBuyerName
       {
           get { return _LeasingBuyerName; }
           set { _LeasingBuyerName = value; }
       }

       public string LeasingCarModel
       {
           get { return _LeasingCarModel; }
           set { _LeasingCarModel = value; }
       }

       public int LeasingrenthMonth
        {
            get { return _LeasingrentMonth; }
            set { _LeasingrentMonth = value; }
        }

       public int LeasingrentPeriod
        {
            get { return _LeasingrentPeriod; }
            set { _LeasingrentPeriod = value; }
        }

       public DateTime LeasingstartDate
        {
            get { return _LeasingstartDate; }
            set { _LeasingstartDate = value; }
        }

            
    
    }
}
