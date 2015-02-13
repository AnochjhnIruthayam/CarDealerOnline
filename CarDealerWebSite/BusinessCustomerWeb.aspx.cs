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

public partial class BusinessCustomerWeb : System.Web.UI.Page
{
    CarDealer cardealer = new CarDealer();
    XML persistent = new XML();
    ConnectSQL conSQL = new ConnectSQL();

    protected void Page_Load(object sender, EventArgs e)
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

    }

    protected void btnBCCreate_Click(object sender, EventArgs e)
    {
        
        if (rbBCSQL.Checked == true)
        {
            conSQL.OpenConnection();
            conSQL.InsertBusinessCustomer(new BusinessCustomer(BxBCName.Text, BxBCAddress.Text, int.Parse(BxBCPhone.Text), int.Parse(BxBCSE.Text), int.Parse(BxBCFax.Text), BxBCContactPerson.Text));
            conSQL.CloseConnection();

        }
        if (rbBCLocalDisk.Checked == true)
        {
            cardealer.AddBusinessCustomer(new BusinessCustomer(BxBCName.Text, BxBCAddress.Text, int.Parse(BxBCPhone.Text), int.Parse(BxBCSE.Text), int.Parse(BxBCFax.Text), BxBCContactPerson.Text));
            persistent.SerializeBC(cardealer.GetBusinessCustomer());
        }
        if (rbBCLocalDisk.Checked == false && rbBCSQL.Checked == false)
        {
            TBShow.Text = "Error! Please Select Data Source!";
        }
    }
    protected void btnBCShow_Click(object sender, EventArgs e)
    {
        TBShow.Text = "";
        if (rbBCSQL.Checked)
        {
            string dp = ConfigurationManager.AppSettings["provider"];
            string cnStr = ConfigurationManager.ConnectionStrings["CarDealerSQLProvider"].ConnectionString;

            DbProviderFactory df = DbProviderFactories.GetFactory(dp);

            //Get connection object
            using (DbConnection cn = df.CreateConnection())
            {
                TBShow.Text += "Your connection object is a: " + cn.GetType().Name + "\n";
                cn.ConnectionString = cnStr;
                cn.Open();
                if (cn is SqlConnection)
                {
                    TBShow.Text += "SQL version: " + ((SqlConnection)cn).ServerVersion + "\n";
                }

                //Make command object
                DbCommand cmd = df.CreateCommand();
                TBShow.Text += "Your command object is a: " + cmd.GetType().Name + "\n";
                cmd.Connection = cn;
                cmd.CommandText = "Select * From BusinessCustomerDB";

                //Print out data with data reader
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    TBShow.Text += "Your data reader object is a: " + dr.GetType().Name + "\n";
                    TBShow.Text += "Business Costumers:\n\n";
                    while (dr.Read())
                    {
                        TBShow.Text += "Company: " + dr["Name"].ToString() + "\r\n" + "Address: " + dr["Address"].ToString() + "\r\n" + "Phone no.: " + dr["Phone"] + "\r\n" + "SE no.: " + dr["SE"] + "\r\n" + "Fax no. : " + dr["Fax"] + "\r\n" + "Contact Person: " + dr["ContactPerson"].ToString() + "\r\n\n";

                    }

                }
            }
        }

        if (rbBCLocalDisk.Checked)
        {

            if (persistent.DeSerializeBC().Count != 0)
            {
                for (int i = 0; i < persistent.DeSerializeBC().Count; i++)
                {
                    TBShow.Text += "Company: " + persistent.DeSerializeBC()[i].name + "\r\n" + "Address: " + persistent.DeSerializeBC()[i].address + "\r\n" + "Phone no.: " + persistent.DeSerializeBC()[i].phone + "\r\n" + "SE no.: " + persistent.DeSerializeBC()[i].SEnr + "\r\n" + "Fax no. : " + persistent.DeSerializeBC()[i].fax + "\r\n" + "Contact Person: " + persistent.DeSerializeBC()[i].ContactPerson + "\r\n\n";

                    //LBBCShow.Items.Add("Company: " + persistent.DeSerializeBC()[i].name + Environment.NewLine + "Address: " + persistent.DeSerializeBC()[i].address + "\r\n" + "Phone no.: " + persistent.DeSerializeBC()[i].phone + "\r\n" + "SE no.: " + persistent.DeSerializeBC()[i].SEnr + "\r\n" + "Fax no. : " + persistent.DeSerializeBC()[i].fax + "\r\n" + "Contact Person: " + persistent.DeSerializeBC()[i].ContactPerson + "\r\n");

                }
            }
            else
            {
                TBShow.Text = "Empty database";
                //LBBCShow.Items.Add("Empty database");
            }
        }
        if (rbBCLocalDisk.Checked == false && rbBCSQL.Checked == false)
        {
            TBShow.Text = "Error! Please Select Data Source!";
        }
    }

}