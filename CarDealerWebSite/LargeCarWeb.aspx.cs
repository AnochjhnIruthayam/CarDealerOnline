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

public partial class LargeCarWeb : System.Web.UI.Page
{
    CarDealer cardealer = new CarDealer();
    XML persistent = new XML();
    ConnectSQL conSQL = new ConnectSQL();

    protected void Page_Load(object sender, EventArgs e)
    {
        //LBSCShow.Items.Clear();
        if (persistent.DeSerializeCarLarge().Count() != 0)
        {
            for (int i = 0; i < persistent.DeSerializeCarLarge().Count(); i++)
            {
                cardealer.AddLargeCar(persistent.DeSerializeCarLarge()[i]);
            }
        }
        else
            persistent.SerializeCarLarge(cardealer.GetLargeCar());

    }

    protected void btnSCCreate_Click(object sender, EventArgs e)
    {
        
        if (rbSCSQL.Checked == true)
        {
            conSQL.OpenConnection();
            conSQL.InsertLargeCar(new Large(BxLCModel.Text, BxLCColor.Text, float.Parse(BxLCPrice.Text), "Available", int.Parse(BxLCCapacity.Text), "NONE"));
            conSQL.CloseConnection();

        }
        if (rbSCLocalDisk.Checked == true)
        {
            cardealer.AddLargeCar(new Large(BxLCModel.Text, BxLCColor.Text, float.Parse(BxLCPrice.Text), "Available", int.Parse(BxLCCapacity.Text), "NONE"));
            persistent.SerializeCarLarge(cardealer.GetLargeCar());



        }
        if (rbSCLocalDisk.Checked == false && rbSCSQL.Checked == false)
        {
            TextBox1.Text = "Error! Please Select Data Source!";
        }
    }

    protected void btnBCShow_Click(object sender, EventArgs e)
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
                cmd.CommandText = "Select * From LargeDB";

                //Print out data with data reader
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    TextBox1.Text += "Your data reader object is a: " + dr.GetType().Name + "\n";
                    TextBox1.Text += "Large Cars:\n\n";
                    while (dr.Read())
                    {
                        TextBox1.Text += "Car Model: " + dr["CarModel"].ToString() + "\r\n" + "Color: " + dr["Color"].ToString() +"\r\n" + "Price: " + dr["Price"] + " DKK" + "\r\n" + "Capacity: " + dr["Capacity"] + " people" + "\r\n" + "Status: " + dr["Status"].ToString() + "\r\n" + "Owner: " + dr["BuyerName"].ToString() + "\r\n\n";

                    }

                }
            }
        }


        if (rbSCLocalDisk.Checked)
        {
            if (persistent.DeSerializeCarLarge().Count != 0)
            {
                for (int i = 0; i < persistent.DeSerializeCarLarge().Count; i++)
                {
                    TextBox1.Text += "Car Model: " + persistent.DeSerializeCarLarge()[i].model + "\r\n" + "Color: " + persistent.DeSerializeCarLarge()[i].color + "\r\n" + "Price: " + persistent.DeSerializeCarLarge()[i].price + " DKK" + "\r\n" + "Capacity: " + persistent.DeSerializeCarLarge()[i].largeCarCapacity + " people" + "\r\n" + "Status: " + persistent.DeSerializeCarLarge()[i].status + "\r\n" + "Owner: " + persistent.DeSerializeCarLarge()[i].buyerName + "\r\n\n";
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