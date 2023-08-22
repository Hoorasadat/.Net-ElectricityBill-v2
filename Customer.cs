﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class Customer
    {
        // ------------------------------------- Variables: -------------------------------------

        decimal adminFee = 12;
        decimal kwhCost = 0.07m;

        // ------------------------------------- Properties: -------------------------------------

        public int AccountNo { get; }
        string firstName;
        string lastName;
        private decimal powerUsage = 0;
        public decimal PowerUsage
        {
            get { return powerUsage; }
        }
        public decimal BillAmount { get; }


        // -------------------------------- 1st constructor method: --------------------------------
        
        public Customer(int accNo, string fstNm, string lstNm, decimal pwrUsg)
        {
            AccountNo = accNo;
            firstName = fstNm;
            lastName = lstNm;
            powerUsage = pwrUsg;
            BillAmount = CalculateCharge();
        }


        // -------------------------------- 2nd constructor method: --------------------------------
        
        public Customer(string fstNm, string lstNm, decimal pwrUsg)
        {
            Guid uniqueId = Guid.NewGuid();
            int hashedValue = Math.Abs(uniqueId.GetHashCode());

            AccountNo = hashedValue;
            firstName = fstNm;
            lastName = lstNm;
            powerUsage = pwrUsg;
            BillAmount = CalculateCharge();
        }


        // -------------------------------- calculate cost method: --------------------------------
        
        private decimal CalculateCharge()
        {
            decimal powerCost = 0;
            powerCost = kwhCost * powerUsage + adminFee;
            return powerCost;
        }


        // ------------------ calculate ToString method (method for MessageBox): ------------------

        public override string ToString()
        {
            string billString = CalculateCharge().ToString("C");
            return $"Add {firstName} {lastName} with account no. {AccountNo} and a bill of {billString}";
        }


        // ----------------- calculate CreateCustomer method (method for ListBox): -----------------

        public string CreateCustomer()
        {
            string billString = CalculateCharge().ToString("C");
            return $"First Name: {firstName}, Last Name: {lastName}, Account #: {AccountNo}, Bill: ${billString}";
        }

    }
}
