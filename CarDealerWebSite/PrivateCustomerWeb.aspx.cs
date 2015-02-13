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

using Serialize;
using Logic;

public partial class PrivateCustomerWeb : System.Web.UI.Page
{
    CarDealer cardealer = new CarDealer();
    XML persistent = new XML();
    ConnectSQL conSQL = new ConnectSQL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (persistent.DeSerializePC().Count() != 0)
        {
            for (int i = 0; i < persistent.DeSerializePC().Count(); i++)
            {
                cardealer.AddPrivateCustomer(persistent.DeSerializePC()[i]);
            }
        }
        else
            persistent.SerializePC(cardealer.GetPrivateCustomer());
       
    }
    protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
    {

        
    }
    protected void btnPCCreatePC_Click(object sender, EventArgs e)
    {
        
        if (rbSQL.Checked == true)
        {
            conSQL.OpenConnection();
            conSQL.InsertPrivateCustomer(new PrivateCustomer(BxPCName.Text, BxPCAddress.Text, int.Parse(BxPCPhone.Text), int.Parse(BxPCAge.Text), BxPCSex.Text));
            conSQL.CloseConnection();
        }
        if (rbLocalDisk.Checked == true)
        {
            cardealer.AddPrivateCustomer(new PrivateCustomer(BxPCName.Text, BxPCAddress.Text, int.Parse(BxPCPhone.Text), int.Parse(BxPCAge.Text), BxPCSex.Text));
            persistent.SerializePC(cardealer.GetPrivateCustomer());
        }
        if (rbLocalDisk.Checked == false && rbSQL.Checked == false)
        {
            TextBox1.Text = "Error! Please Select Data Source!";
        }

    }
    protected void BxPCPhone_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnPCShow_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";

        if (rbSQL.Checked)
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
                cmd.CommandText = "Select * From PrivateCustomerDB";

                //Print out data with data reader
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    TextBox1.Text += "Your data reader object is a: " + dr.GetType().Name + "\n";
                    TextBox1.Text += "Private Customers:\n\n";
                    while (dr.Read())
                    {
                        TextBox1.Text += ("Name: " + dr["Name"].ToString() + "\r\n" + "Address: " + dr["Address"].ToString() + "\r\n" + "Phone no.: " + dr["Phone"] + "\r\n" + "Age: " + dr["Age"] + "\r\n" + "Sex: " + dr["Sex"].ToString() + "\r\n\n");

                    }

                }
            }
        }

        if (rbLocalDisk.Checked)
        {
            if (persistent.DeSerializePC().Count != 0)
            {
                //btnPCCreatePC.Visible = false;
                for (int i = 0; i < persistent.DeSerializePC().Count; i++)
                {
                    TextBox1.Text += ("Name: " + persistent.DeSerializePC()[i].name + "\r\n" + "Address: " + persistent.DeSerializePC()[i].address + "\r\n" + "Phone no.: " + persistent.DeSerializePC()[i].phone + "\r\n" + "Age: " + persistent.DeSerializePC()[i].age + "\r\n" + "Sex: " + persistent.DeSerializePC()[i].sex + "\r\n\n");
                }
            }
            else
            {
                TextBox1.Text = ("Empty database");
            }
        }
        if (rbLocalDisk.Checked == false && rbSQL.Checked == false)
        {
            TextBox1.Text = "Error! Please Select Data Source!";
        }
        

    }
    protected void XmlDataSource1_Transforming(object sender, EventArgs e)
    {

    }
}