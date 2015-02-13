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

public partial class BusinessContractWeb : System.Web.UI.Page
{
    CarDealer cardealer = new CarDealer();
    XML persistent = new XML();
    Leasing leasing = new Leasing();
    ConnectSQL conSQL = new ConnectSQL();


    protected void Page_Load(object sender, EventArgs e)
    {

        //if not empty load data


        if (persistent.DeSerializeLeasing().Count() != 0)
        {
            for (int i = 0; i < persistent.DeSerializeLeasing().Count(); i++)
            {
                leasing.AddLeasing(persistent.DeSerializeLeasing()[i]);
            }
        }
        else
            persistent.SerializeLeasing(leasing.GetLeasingList());

        if (persistent.DeSerializeTruck().Count() != 0)
        {
            for (int i = 0; i < persistent.DeSerializeTruck().Count(); i++)
            {
                cardealer.AddTruck(persistent.DeSerializeTruck()[i]);
            }
        }
        else
            persistent.SerializeTruck(cardealer.GetTruck());

        if (persistent.DeSerializeBC().Count() != 0)
        {
            for (int i = 0; i < persistent.DeSerializeBC().Count(); i++)
            {
                cardealer.AddBusinessCustomer(persistent.DeSerializeBC()[i]);
            }
        }
        else
            persistent.SerializeBC(cardealer.GetBusinessCustomer());

    }
    protected void btnBCCreate_Click(object sender, EventArgs e)
    {
        

        if (rbSCSQL.Checked)
        {
            conSQL.OpenConnection();
            conSQL.InsertLeasing(new Leasing(DDBCVechicle.SelectedItem.ToString(), DDBCName.SelectedItem.ToString(), int.Parse(BxBCRentprMonth.Text), int.Parse(BxBCRentPeriod.Text), DateTime.Now));
            

            conSQL.UpdateBusinessStatus(DDBCVechicle.SelectedItem.ToString(), DDBCStatus.SelectedItem.ToString());
            conSQL.UpdateBusinessOwner(DDBCVechicle.SelectedItem.ToString(), DDBCName.SelectedItem.ToString());

            conSQL.CloseConnection();

        }
        if (rbSCLocalDisk.Checked)
        {
            leasing.AddLeasing(new Leasing(DDBCVechicle.SelectedItem.ToString(), DDBCName.SelectedItem.ToString(), int.Parse(BxBCRentprMonth.Text), int.Parse(BxBCRentPeriod.Text), DateTime.Now));
            persistent.SerializeLeasing(leasing.GetLeasingList());
            for (int i = 0; i < persistent.DeSerializeTruck().Count(); i++)
            {
                //Update Truckinfo and save to xml file
                if (DDBCVechicle.SelectedItem.ToString() == persistent.DeSerializeTruck()[i].model)
                {
                    cardealer.GetTruck()[i].status = DDBCStatus.SelectedItem.ToString();
                    cardealer.GetTruck()[i].buyerName = DDBCName.SelectedItem.ToString();
                    persistent.SerializeTruck(cardealer.GetTruck());
                }
            }
        }
        if (rbSCLocalDisk.Checked == false && rbSCSQL.Checked == false)
        {

        }
    }
    protected void btnBCShow_Click(object sender, EventArgs e)
    {
        //clear list
        TextBox1.Text = "";
        if (rbSCSQL.Checked)
        {
            string dp = ConfigurationManager.AppSettings["provider"];
            string cnStr = ConfigurationManager.ConnectionStrings["CarDealerSQLProvider"].ConnectionString;

            DbProviderFactory df = DbProviderFactories.GetFactory(dp);

            //Get connection object
            using (DbConnection cn = df.CreateConnection())
            {
                TextBox1.Text += "Your connection object is a: " + cn.GetType().Name + "\n";
                cn.ConnectionString = cnStr;
                cn.Open();
                if (cn is SqlConnection)
                {
                    TextBox1.Text += "SQL version: " + ((SqlConnection)cn).ServerVersion + "\n";
                }

                //Make command object
                DbCommand cmd = df.CreateCommand();
                TextBox1.Text += "Your command object is a: " + cmd.GetType().Name + "\n";
                cmd.Connection = cn;
                cmd.CommandText = "Select * From LeasingDB";

                //Print out data with data reader
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    TextBox1.Text += "Your data reader object is a: " + dr.GetType().Name + "\n";
                    TextBox1.Text += "Business Leasing:\n\n";
                    while (dr.Read())
                    {
                        TextBox1.Text += "Car Model: " + dr["CarModel"].ToString() + "\r\n" + "Owner: " + dr["BuyerName"].ToString() + "\r\n" + "Rent pro Month: " + dr["RentMonth"] + "\r\n" + "Rent Period: " + dr["RentPeriod"] + " months" + "\r\n" + "Start rent date: " + dr["StartDate"] + "\r\n\n";

                    }

                }
            }
        }

        if (rbSCLocalDisk.Checked)
        {

            TextBox1.Text += "Truck leasing for buisness costumers:\n";
            //if not empty load data
            if (persistent.DeSerializeLeasing().Count() != 0)
            {
                for (int i = 0; i < persistent.DeSerializeLeasing().Count(); i++)
                {
                    TextBox1.Text += "Car Model: " + persistent.DeSerializeLeasing()[i].LeasingCarModel + "\r\n" + "Owner: " + persistent.DeSerializeLeasing()[i].LeasingBuyerName + "\r\n" + "Rent pro Month: " + persistent.DeSerializeLeasing()[i].LeasingrenthMonth + "\r\n" + "Rent Period: " + persistent.DeSerializeLeasing()[i].LeasingrentPeriod + " months" + "\r\n" + "Start rent date: " + persistent.DeSerializeLeasing()[i].LeasingstartDate + "\r\n\n";
                }
            }
            if (persistent.DeSerializeLeasing().Count() == 0)
            {
                TextBox1.Text += "Empty";
            }
        }
        if (rbSCLocalDisk.Checked == false && rbSCSQL.Checked == false)
        {
            TextBox1.Text = "Error! Please Select Data Source!";
        }
    }
    protected void btnLoad_Click(object sender, EventArgs e)
    {
        if (persistent.DeSerializeBC().Count() != 0)
        {
            for (int i = 0; i < persistent.DeSerializeBC().Count(); i++)
            {
                cardealer.AddBusinessCustomer(persistent.DeSerializeBC()[i]);
            }
        }
        else
            persistent.SerializeBC(cardealer.GetBusinessCustomer());

        if (persistent.DeSerializeLeasing().Count() != 0)
        {
            for (int i = 0; i < persistent.DeSerializeLeasing().Count(); i++)
            {
                leasing.AddLeasing(persistent.DeSerializeLeasing()[i]);
            }
        }
        else
            persistent.SerializeLeasing(leasing.GetLeasingList());

        if (persistent.DeSerializeTruck().Count() != 0)
        {
            for (int i = 0; i < persistent.DeSerializeTruck().Count(); i++)
            {
                cardealer.AddTruck(persistent.DeSerializeTruck()[i]);
            }
        }
        else
            persistent.SerializeTruck(cardealer.GetTruck());

        DDBCName.Items.Clear();
        DDBCVechicle.Items.Clear();
        DDBCStatus.Items.Clear();
        DDBCStatus.Items.Add("Commission");
        DDBCStatus.Items.Add("Sold");
        DDBCStatus.Items.Add("Leased");
        if (rbSCLocalDisk.Checked)
        {
            if (persistent.DeSerializeBC().Count() != 0)
            {
                for (int i = 0; i < persistent.DeSerializeBC().Count(); i++)
                {

                    DDBCName.Items.Add(persistent.DeSerializeBC()[i].name);
                }
            }
            if (persistent.DeSerializeBC().Count() == 0)
            {
                DDBCName.Items.Add("Empty");
            }
            //if not empty load data
            if (persistent.DeSerializeTruck().Count() != 0)
            {
                for (int i = 0; i < persistent.DeSerializeTruck().Count(); i++)
                {
                    if (persistent.DeSerializeTruck()[i].status == "Available")
                    {
                        DDBCVechicle.Items.Add(persistent.DeSerializeTruck()[i].model);
                    }
                }
            }
            if (persistent.DeSerializeTruck().Count() == 0)
            {
                DDBCVechicle.Items.Add("Empty");
            }
        }
        if (rbSCSQL.Checked)
        {



            string dp = ConfigurationManager.AppSettings["provider"];
            string cnStr = ConfigurationManager.ConnectionStrings["CarDealerSQLProvider"].ConnectionString;

            DbProviderFactory df = DbProviderFactories.GetFactory(dp);

            //Get connection object
            using (DbConnection cn = df.CreateConnection())
            {
                cn.ConnectionString = cnStr;
                cn.Open();
                if (cn is SqlConnection)
                {
                    //TextBox1.Text += "SQL version: " + ((SqlConnection)cn).ServerVersion + "\n";
                }

                //Make command object
                DbCommand cmd = df.CreateCommand();
                cmd.Connection = cn;
                cmd.CommandText = "Select * From BusinessCustomerDB";

                //Print out data with data reader
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DDBCName.Items.Add(dr["Name"].ToString());

                    }

                }
                cmd.CommandText = "Select * From TruckDB";
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr["Status"].ToString() == "Available")
                        {
                            DDBCVechicle.Items.Add(dr["Model"].ToString());
                        }

                    }

                }

            }
        }
    }
}