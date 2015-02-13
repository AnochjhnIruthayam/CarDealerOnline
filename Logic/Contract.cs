using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Contract
    {
        /// <summary>
        /// Contains two constructors one without parameter and one with parameters. the parameters is BuyDate, Carmodel and Buyer Name
        /// </summary>
        
        
        public Contract() { }

        public Contract(string ContractBuyerName, string ContractCarModel, DateTime ContractBuyDate)
        {
            _ContractBuyerName = ContractBuyerName;
            _ContractCarModel = ContractCarModel;
            _ContractBuyDate = ContractBuyDate;
        }


        private DateTime _ContractBuyDate;
        private string _ContractCarModel;
        private string _ContractBuyerName;
        
        /// <summary>
        /// Create List of contracts
        /// </summary>
        private List<Contract> ContractList = new List<Contract>();

        /// <summary>
        /// Add contract to list
        /// </summary>
        /// <param name="oContract">Add contract to list</param>
        public void AddContract(Contract oContract)
        {
            ContractList.Add(oContract);
        }
        /// <summary>
        /// Get contract list
        /// </summary>
        /// <returns>Get contract list</returns>
        public List<Contract> GetContractList()
        {
            return ContractList;
        }

        /// <summary>
        /// property for ContractCarModel
        /// </summary>
        public string ContractCarModel
        {
            get { return _ContractCarModel; }
            set { _ContractCarModel = value; }
        }

        /// <summary>
        /// property for ContractBuyerName
        /// </summary>
        public string ContractBuyerName
        {
            get { return _ContractBuyerName; }
            set { _ContractBuyerName = value; }
        }

        /// <summary>
        /// property for ContractBuyDate
        /// </summary>
        public DateTime ContractBuyDate
        {
            get { return _ContractBuyDate; }
            set { _ContractBuyDate = value; }
        }
        

            
    }
}
