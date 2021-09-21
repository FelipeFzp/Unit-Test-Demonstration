using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnitTest_Example;

namespace Tests
{
    public class Tests
    {
        private BankService _bankService;

        [SetUp]
        public void Setup()
        {
            _bankService = new BankService();

            //Arrange
            _bankService.accounts.Add("111", 10.00);
            _bankService.accounts.Add("222", 5.00);
        }

        [Test]
        public void GetBalanceTest()
        {
            //Arrange
            var accountToGetBalance = "111";

            //Act
            var balance = _bankService.GetBalance(accountToGetBalance);

            //Assert
            Thread.Sleep(1000);
            Assert.AreEqual(balance, 10.00);
        }
        
        [Test]
        public void GetInexistentAccountBalanceTest()
        {
            //Arrange
            var inexistentAccountNumber = "999";

            //Act & Assert
            Thread.Sleep(1000);
            Assert.Throws<ArgumentException>(() => _bankService.GetBalance(inexistentAccountNumber));
        }
        
        [Test]
        public void TransferMoneyTest()
        {
            //Arrange
            var sourceAccountNumber = "111";
            var targetAccountNumber = "222";

            //Act
            _bankService.Transfer(sourceAccountNumber, targetAccountNumber, 1.50);

            //Assert
            var account1Balance = _bankService.accounts[sourceAccountNumber];
            var account2Balance = _bankService.accounts[targetAccountNumber];

            Thread.Sleep(1000);
            Assert.AreEqual(account1Balance, 8.50);
            Assert.AreEqual(account2Balance, 6.50);
        }
        
        [Test]
        public void InsufficientFundsTest()
        {
            //Arrange
            var sourceAccountNumber = "111";
            var targetAccountNumber = "222";

            //Act & Assert
            Thread.Sleep(1000);
            Assert.Throws<InvalidOperationException>(() => _bankService.Transfer(sourceAccountNumber, targetAccountNumber, 100));
        }
    }
}