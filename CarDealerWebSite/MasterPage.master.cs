using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using Logic;
using Serialize;

public class ConnectSQL
{
    private SqlConnection sqlCn = null;


    public void OpenConnection()
    {
        sqlCn = new SqlConnection();
        sqlCn.ConnectionString = ConfigurationManager.ConnectionStrings["CarDealerSQLProvider"].ConnectionString;
        sqlCn.Open();
    }

    public void CloseConnection()
    {
        sqlCn.Close();
    }

    //Insert Logic for SQL
    public void InsertBusinessCustomer(BusinessCustomer newCostumer)
    {
        // Format and execute SQL statement
        string sql = string.Format("Insert Into BusinessCustomerDB" + "(Name, Address, Phone, SE, Fax, ContactPerson) Values" + "('{0}','{1}','{2}','{3}','{4}','{5}')", newCostumer.name, newCostumer.address, newCostumer.phone, newCostumer.SEnr, newCostumer.fax, newCostumer.ContactPerson);
        using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
        {
            cmd.ExecuteNonQuery();
        }
    }

    public void InsertLargeCar(Large newLargeCar)
    {
        string sql = string.Format("Insert Into LargeDB" + "(BuyerName, Price, Color, CarModel, Status, Capacity) Values" + "('{0}','{1}','{2}','{3}','{4}','{5}')", newLargeCar.buyerName, newLargeCar.price, newLargeCar.color, newLargeCar.model, newLargeCar.status, newLargeCar.largeCarCapacity);
        using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
        {
            cmd.ExecuteNonQuery();
        }
    }

    public void InsertPrivateCustomer(PrivateCustomer newCustomer)
    {
        string sql = string.Format("Insert Into PrivateCustomerDB" + "(Name, Address, Phone, Age, Sex) Values" + "('{0}','{1}','{2}','{3}','{4}')", newCustomer.name, newCustomer.address, newCustomer.phone, newCustomer.age, newCustomer.sex);
        using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
        {
            cmd.ExecuteNonQuery();
        }
    }

    public void InsertSmallCar(Small smallCar)
    {
        string sql = string.Format("Insert Into SmallDB" + "(BuyerName, CarModel, Price, Color, Status, Weight) Values" + "('{0}','{1}','{2}','{3}','{4}', '{5}')", smallCar.buyerName, smallCar.model, smallCar.price, smallCar.color, smallCar.status, smallCar.weight);
        using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
        {
            cmd.ExecuteNonQuery();
        }
    }


    public void InsertTruck(Truck truck)
    {
        string sql = string.Format("Insert Into TruckDB" + "(BuyerName, Price, Color, Model, Status, Capacity) Values" + "('{0}','{1}','{2}','{3}','{4}', '{5}')", truck.buyerName, truck.price, truck.color, truck.model, truck.status, truck.capacity);
        using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
        {
            cmd.ExecuteNonQuery();
        }
    }

    public void InsertLeasing(Leasing leasingnew)
    {
        string sql = string.Format("Insert Into LeasingDB" + "(BuyerName, CarModel, RentMonth, RentPeriod, StartDate) Values" + "('{0}','{1}','{2}','{3}','{4}')", leasingnew.LeasingBuyerName, leasingnew.LeasingCarModel, leasingnew.LeasingrenthMonth, leasingnew.LeasingrentPeriod, leasingnew.LeasingstartDate);
        using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
        {
            cmd.ExecuteNonQuery();
        }
    }

    public void InsertContract(Contract contractnew)
    {
        string sql = string.Format("Insert Into ContractDB" + "(CarModel, BuyerName, BuyDate) Values" + "('{0}','{1}','{2}')", contractnew.ContractCarModel, contractnew.ContractBuyerName, contractnew.ContractBuyDate);
        using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
        {
            cmd.ExecuteNonQuery();
        }
    }
    public void UpdateSmallCarStatus(string IDModel, string newStatus)
    {
        string sql = string.Format("Update SmallDB Set Status = '{0}' Where CarModel = '{1}'", newStatus, IDModel);
        using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
        {
            cmd.ExecuteNonQuery();
        }
    }
    public void UpdateLargeCarStatus(string IDModel, string newStatus)
    {
        string sql = string.Format("Update LargeDB Set Status = '{0}' Where CarModel = '{1}'", newStatus, IDModel);
        using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
        {
            cmd.ExecuteNonQuery();
        }
    }
    public void UpdateSmallCarOwner(string IDModel, string newOwner)
    {
        string sql = string.Format("Update SmallDB Set BuyerName = '{0}' Where CarModel = '{1}'", newOwner, IDModel);
        using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
        {
            cmd.ExecuteNonQuery();
        }
    }

    public void UpdateLargeCarOwner(string IDModel, string newOwner)
    {
        string sql = string.Format("Update LargeDB Set BuyerName = '{0}' Where CarModel = '{1}'", newOwner, IDModel);
        using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
        {
            cmd.ExecuteNonQuery();
        }
    }

    public void UpdateBusinessStatus(string IDModel, string newStatus)
    {
        string sql = string.Format("Update TruckDB Set Status = '{0}' Where Model = '{1}'", newStatus, IDModel);
        using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
        {
            cmd.ExecuteNonQuery();
        }
    }
    public void UpdateBusinessOwner(string IDModel, string newOwner)
    {
        string sql = string.Format("Update TruckDB Set BuyerName = '{0}' Where Model = '{1}'", newOwner, IDModel);
        using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
        {
            cmd.ExecuteNonQuery();
        }
    }



}


public partial class MasterPage : System.Web.UI.MasterPage
{
    CarDealer oCarDealer = new CarDealer();
    XML Persistent = new XML();
    Leasing oLeasing = new Leasing();
    Contract oContract = new Contract();



    protected void Page_Load(object sender, EventArgs e)
    {

        //Load data from Persistent layer
        try
        {
            if (Persistent.DeSerializePC().Count() != 0)
            {
                for (int i = 0; i < Persistent.DeSerializePC().Count(); i++)
                {
                    oCarDealer.AddPrivateCustomer(Persistent.DeSerializePC()[i]);
                }
            }
            else
                Persistent.SerializePC(oCarDealer.GetPrivateCustomer());


            if (Persistent.DeSerializeBC().Count() != 0)
            {
                for (int i = 0; i < Persistent.DeSerializeBC().Count(); i++)
                {
                    oCarDealer.AddBusinessCustomer(Persistent.DeSerializeBC()[i]);
                }
            }
            else
                Persistent.SerializeBC(oCarDealer.GetBusinessCustomer());



            if (Persistent.DeSerializeCarSmall().Count() != 0)
            {
                for (int i = 0; i < Persistent.DeSerializeCarSmall().Count(); i++)
                {
                    oCarDealer.AddSmallCar(Persistent.DeSerializeCarSmall()[i]);
                }
            }
            else
                Persistent.SerializeCarSmall(oCarDealer.GetSmallCar());

            if (Persistent.DeSerializeCarLarge().Count() != 0)
            {
                for (int i = 0; i < Persistent.DeSerializeCarLarge().Count(); i++)
                {
                    oCarDealer.AddLargeCar(Persistent.DeSerializeCarLarge()[i]);
                }
            }
            else
                Persistent.SerializeCarLarge(oCarDealer.GetLargeCar());



            if (Persistent.DeSerializeTruck().Count() != 0)
            {
                for (int i = 0; i < Persistent.DeSerializeTruck().Count(); i++)
                {
                    oCarDealer.AddTruck(Persistent.DeSerializeTruck()[i]);
                }
            }
            else
                Persistent.SerializeTruck(oCarDealer.GetTruck());

            if (Persistent.DeSerializeContract().Count() != 0)
            {
                for (int i = 0; i < Persistent.DeSerializeContract().Count(); i++)
                {
                    oContract.AddContract(Persistent.DeSerializeContract()[i]);
                }
            }
            else
                Persistent.SerializeContract(oContract.GetContractList());

            if (Persistent.DeSerializeLeasing().Count() != 0)
            {
                for (int i = 0; i < Persistent.DeSerializeLeasing().Count(); i++)
                {
                    oLeasing.AddLeasing(Persistent.DeSerializeLeasing()[i]);
                }
            }
            else
                Persistent.SerializeLeasing(oLeasing.GetLeasingList());
        }
        //If fail to load, create new files
        catch
        {
            //MessageBox.Show(ex.Message);
            //MessageBox.Show("XML files created!");
            Persistent.SerializePC(oCarDealer.GetPrivateCustomer());
            Persistent.SerializeBC(oCarDealer.GetBusinessCustomer());
            Persistent.SerializeCarSmall(oCarDealer.GetSmallCar());
            Persistent.SerializeCarLarge(oCarDealer.GetLargeCar());
            Persistent.SerializeTruck(oCarDealer.GetTruck());
            Persistent.SerializeContract(oContract.GetContractList());
            Persistent.SerializeLeasing(oLeasing.GetLeasingList());
        }
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {

    }
}
