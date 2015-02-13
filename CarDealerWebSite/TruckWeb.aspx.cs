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

public partial class TruckWeb : System.Web.UI.Page
{
    CarDealer cardealer = new CarDealer();
    XML persistent = new XML();
    ConnectSQL conSQL = new ConnectSQL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (persistent.DeSerializeTruck().Count() != 0)
        {
            for (int i = 0; i < persistent.DeSerializeTruck().Count(); i++)
            {
                cardealer.AddTruck(persistent.DeSerializeTruck()[i]);
            }
        }
        else
            persistent.SerializeTruck(cardealer.GetTruck());
    }
    protected void btnSCCreate_Click(object sender, EventArgs e)
    {
        
        if (rbSCSQL.Checked == true)
        {
            conSQL.OpenConnection();
            conSQL.InsertTruck(new Truck(BxTModel.Text, BxTColor.Text, float.Parse(BxTPrice.Text), "Available", int.Parse(BxTCapacity.Text), "NONE"));
            conSQL.CloseConnection();
        }
        if (rbSCLocalDisk.Checked == true)
        {
            cardealer.AddTruck(new Truck(BxTModel.Text, BxTColor.Text, float.Parse(BxTPrice.Text), "Available", int.Parse(BxTCapacity.Text), "NONE"));
            persistent.SerializeTruck(cardealer.GetTruck());
        }
        if (rbSCLocalDisk.Checked == false && rbSCSQL.Checked == false)
        {
            TextBox1.Text = "Error! Please Select Data Source!";
        }

    }
    protected void btnSCShow_Click(object sender, EventArgs e)
    {
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
                cmd.CommandText = "Select * From TruckDB";

                //Print out data with data reader
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    TextBox1.Text += "Your data reader object is a: " + dr.GetType().Name + "\n";
                    TextBox1.Text += "Trucks:\n\n";
                    while (dr.Read())
                    {
                        TextBox1.Text += ("Truck Model: " + dr["Model"].ToString() + "\r\n" + "Color: " + dr["Color"].ToString() + "\r\n" + "Price: " + dr["Price"] + " DDK" + "\r\n" + "Capacity: " + dr["Capacity"] + " m^3" + "\r\n" + "Status: " + dr["Status"].ToString() + "\r\n" + "Owner: " + dr["BuyerName"].ToString() + "\r\n\n");
                    }

                }
            }
        }

        if (rbSCLocalDisk.Checked)
        {
            if (persistent.DeSerializeTruck().Count != 0)
            {
                for (int i = 0; i < persistent.DeSerializeTruck().Count; i++)
                {
                    TextBox1.Text += ("Truck Model: " + persistent.DeSerializeTruck()[i].model + "\r\n" + "Color: " + persistent.DeSerializeTruck()[i].color + "\r\n" + "Price: " + persistent.DeSerializeTruck()[i].price + " DDK" + "\r\n" + "Capacity: " + persistent.DeSerializeTruck()[i].capacity + " m^3" + "\r\n" + "Status: " + persistent.DeSerializeTruck()[i].status + "\r\n" + "Owner: " + persistent.DeSerializeTruck()[i].buyerName + "\r\n\n");
                }
            }
            else
            {
                TextBox1.Text = ("Empty database");
            }
        }
        if (rbSCLocalDisk.Checked == false && rbSCSQL.Checked == false)
        {
            TextBox1.Text = "Error! Please Select Data Source!";
        }
    }
}