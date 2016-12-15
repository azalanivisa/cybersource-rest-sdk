using Cybersource.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;

namespace Cybersource.Test
{

    [TestClass]
    public class CybersourcePaymentsTest
    {
        private string paymentAuthorizationRequest;
        private VisaAPIClient visaAPIClient;

        public CybersourcePaymentsTest()
        {
            visaAPIClient = new VisaAPIClient();
        }

        [TestMethod]
        public void TestPaymentAuthorizations(string []transactionDetails)
        {
            string baseUri = "cybersource/";
            string queryString = "apikey=" + ConfigurationManager.AppSettings["apiKey"];
            string status = visaAPIClient.DoXPayTokenCall(baseUri, transactionDetails, queryString, "Cybersouce Payments Authorization Test", paymentAuthorizationRequest);
            Console.WriteLine(status);
            //Assert.AreEqual(status, "Created");"",
        }
        static void Main(string[] args)
        {
            //paymentAuthorizationRequest = System.IO.File.ReadAllText("C:/Users/azalani/Desktop/bill.json");
                       
            CybersourcePaymentsTest cybstest = new CybersourcePaymentsTest();
            cybstest.paymentAuthorizationRequest = System.IO.File.ReadAllText("C:/Users/azalani/Desktop/bill.json");
            cybstest.TestPaymentAuthorizations(args);
            System.Console.ReadLine();
        }
    }
}
