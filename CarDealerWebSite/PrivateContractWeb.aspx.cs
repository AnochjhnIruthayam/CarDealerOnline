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

public partial class PrivateContractWeb : System.Web.UI.Page
{
    CarDealer cardealer = new CarDealer();
    XML persistent = new XML();
    Contract contract = new Contract();
    ConnectSQL ConSQL = new ConnectSQL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (persistent.DeSerializeCarSmall().Count() != 0)
        {
            for (int i = 0; i < persistent.DeSerializeCarSmall().Count(); i++)
            {
                cardealer.AddSmallCar(persistent.DeSerializeCarSmall()[i]);
            }
        }
        else
            persistent.SerializeCarSmall(cardealer.GetSmallCar());

        if (persistent.DeSerializeCarLarge().Count() != 0)
        {
            for (int i = 0; i < persistent.DeSerializeCarLarge().Count(); i++)
            {
                cardealer.AddLargeCar(persistent.DeSerializeCarLarge()[i]);
            }
        }
        else
            persistent.SerializeCarLarge(cardealer.GetLargeCar());


        if (persistent.DeSerializeContract().Count() != 0)
        {
            for (int i = 0; i < persistent.DeSerializeContract().Count(); i++)
            {
                contract.AddContract(persistent.DeSerializeContract()[i]);
            }
        }
        else
            persistent.SerializeContract(contract.GetContractList());

      

    }
    protected void btnBCCreate_Click(object sender, EventArgs e)
    {

        if (rbSCSQL.Checked)
        {
            ConSQL.OpenConnection();
            ConSQL.InsertContract(new Contract(DDPCName.SelectedItem.ToString(), DDPCVehicle.SelectedItem.ToString(), DateTime.Now));

            //Small car update
            ConSQL.UpdateSmallCarStatus(DDPCVehicle.SelectedItem.ToString(), DDPCStatus.SelectedItem.ToString());
            ConSQL.UpdateSmallCarOwner(DDPCVehicle.SelectedItem.ToString(), DDPCName.SelectedItem.ToString());

            //Large car update
            ConSQL.UpdateLargeCarStatus(DDPCVehicle.SelectedItem.ToString(), DDPCStatus.SelectedItem.ToString());
            ConSQL.UpdateLargeCarOwner(DDPCVehicle.SelectedItem.ToString(), DDPCName.SelectedItem.ToString());

        }
        if (rbSCLocalDisk.Checked)
        {
            contract.AddContract(new Contract(DDPCName.SelectedItem.ToString(), DDPCVehicle.SelectedItem.ToString(), DateTime.Now));
            persistent.SerializeContract(contract.GetContractList());
            for (int i = 0; i < persistent.DeSerializeCarLarge().Count(); i++)
            {
                //Update CarLarge and save to xml file
                if (DDPCVehicle.SelectedItem.ToString() == persistent.DeSerializeCarLarge()[i].model)
                {
                    cardealer.GetLargeCar()[i].status = DDPCStatus.SelectedItem.ToString();
                    cardealer.GetLargeCar()[i].buyerName = DDPCName.SelectedItem.ToString();
                    persistent.SerializeCarLarge(cardealer.GetLargeCar());
                }
            }
            for (int i = 0; i < persistent.DeSerializeCarSmall().Count(); i++)
            {
                //Update CarSmall and save to xml file
                if (DDPCVehicle.SelectedItem.ToString() == persistent.DeSerializeCarSmall()[i].model)
                {


                    cardealer.GetSmallCar()[i].status = DDPCStatus.SelectedItem.ToString();
                    cardealer.GetSmallCar()[i].buyerName = DDPCName.SelectedItem.ToString();
                    persistent.SerializeCarSmall(cardealer.GetSmallCar());
                }
            }

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
                cmd.CommandText = "Select * From ContractDB";

                //Print out data with data reader
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    TextBox1.Text += "Your data reader object is a: " + dr.GetType().Name + "\n";
                    TextBox1.Text += "Private Contracts:\n\n";
                    while (dr.Read())
                    {
                        TextBox1.Text += ("Car Model: " + dr["CarModel"].ToString() + "\r\n" + "Owner: " + dr["BuyerName"].ToString() + "\r\n" + "Sale Date: " + dr["BuyDate"] + "\r\n\n");

                    }

                }
            }
        }

        if (rbSCLocalDisk.Checked)
        {
            if (persistent.DeSerializeContract().Count() != 0)
            {
                for (int i = 0; i < persistent.DeSerializeContract().Count(); i++)
                {
                    TextBox1.Text += ("Car Model: " + persistent.DeSerializeContract()[i].ContractCarModel + "\r\n" + "Owner: " + persistent.DeSerializeContract()[i].ContractBuyerName + "\r\n" + "Sale Date: " + persistent.DeSerializeContract()[i].ContractBuyDate + "\r\n\n");
                }
            }
            if (persistent.DeSerializeContract().Count() == 0)
            {
                TextBox1.Text = ("Empty");
            }
        }
        if (rbSCLocalDisk.Checked == false && rbSCSQL.Checked == false)
        {
            TextBox1.Text = "Error! Please Select Data Source!";
        }
    }
    protected void btnLoad_Click(object sender, EventArgs e)
    {
        if (persistent.DeSerializeCarSmall().Count() != 0)
        {
            for (int i = 0; i < persistent.DeSerializeCarSmall().Count(); i++)
            {
                cardealer.AddSmallCar(persistent.DeSerializeCarSmall()[i]);
            }
        }
        else
            persistent.SerializeCarSmall(cardealer.GetSmallCar());

        if (persistent.DeSerializeCarLarge().Count() != 0)
        {
            for (int i = 0; i < persistent.DeSerializeCarLarge().Count(); i++)
            {
                cardealer.AddLargeCar(persistent.DeSerializeCarLarge()[i]);
            }
        }
        else
            persistent.SerializeCarLarge(cardealer.GetLargeCar());


        if (persistent.DeSerializeContract().Count() != 0)
        {
            for (int i = 0; i < persistent.DeSerializeContract().Count(); i++)
            {
                contract.AddContract(persistent.DeSerializeContract()[i]);
            }
        }
        else
            persistent.SerializeContract(contract.GetContractList());
        DDPCVehicle.Items.Clear();
        DDPCName.Items.Clear();
        DDPCStatus.Items.Clear();

        DDPCStatus.Items.Add("Commission");
        DDPCStatus.Items.Add("Sold");
        DDPCStatus.Items.Add("Leased");
        if (rbSCLocalDisk.Checked)
        {

            //if not empty load data
            if (persistent.DeSerializePC().Count() != 0)
            {
                for (int i = 0; i < persistent.DeSerializePC().Count(); i++)
                {
                    DDPCName.Items.Add(persistent.DeSerializePC()[i].name);
                }
            }
            if (persistent.DeSerializePC().Count() == 0)
            {
                DDPCName.Items.Add("Empty");
            }
            //if not empty load data
            if (persistent.DeSerializeCarSmall().Count() != 0)
            {
                for (int i = 0; i < persistent.DeSerializeCarSmall().Count(); i++)
                {
                    //ONLY AVAILABLE CAR CAN BE SELECTED
                    if (persistent.DeSerializeCarSmall()[i].status == "Available")
                    {
                        DDPCVehicle.Items.Add(persistent.DeSerializeCarSmall()[i].model);
                    }

                }
            }
            //if not empty load data
            if (persistent.DeSerializeCarLarge().Count() != 0)
            {
                for (int i = 0; i < persistent.DeSerializeCarLarge().Count(); i++)
                {
                    //ONLY AVAILABLE CAR CAN BE SELECTED
                    if (persistent.DeSerializeCarLarge()[i].status == "Available")
                    {
                        DDPCVehicle.Items.Add(persistent.DeSerializeCarLarge()[i].model);
                    }
                }
            }
            if (persistent.DeSerializeCarLarge().Count() == 0 && persistent.DeSerializeCarSmall().Count() == 0)
            {
                DDPCVehicle.Items.Add("Empty");
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
                cmd.CommandText = "Select * From PrivateCustomerDB";

                //Print out data with data reader
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DDPCName.Items.Add(dr["Name"].ToString());

                    }

                }
                cmd.CommandText = "Select * From SmallDB";
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr["Status"].ToString() == "Available")
                        {
                            DDPCVehicle.Items.Add(dr["CarModel"].ToString());
                        }

                    }

                }
                cmd.CommandText = "Select * From LargeDB";
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr["Status"].ToString() == "Available")
                        {
                            DDPCVehicle.Items.Add(dr["CarModel"].ToString());
                        }

                    }

                }

            }
        }
    }
}