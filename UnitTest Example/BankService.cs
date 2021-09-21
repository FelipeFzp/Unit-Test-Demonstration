using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest_Example
{
    public class BankService
    {
        public Dictionary<string, double> accounts = new Dictionary<string, double>();

        public double GetBalance(string accountNumber)
        {
            if (!accounts.ContainsKey(accountNumber))
                throw new ArgumentException("Invalid account number exception");

            return accounts.GetValueOrDefault(accountNumber);
        }

        public void Transfer(string sourceAccountNumber, string targetAccountNumber, double value)
        {
            if (!accounts.ContainsKey(sourceAccountNumber))
                throw new ArgumentException("Unable to find source account");

            if (!accounts.ContainsKey(targetAccountNumber))
                throw new ArgumentException("Unable to find target account");

            if (accounts[sourceAccountNumber] - value < 0)
                throw new InvalidOperationException("Insufficient funds");

            accounts[sourceAccountNumber] -= value;
            accounts[targetAccountNumber] += value;
        }
    }
}
