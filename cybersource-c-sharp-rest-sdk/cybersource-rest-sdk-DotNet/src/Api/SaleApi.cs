using System;

namespace Cybersource.Client
{
    internal class SaleApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "POST";

        public SaleApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/sales";
        }

        public string GetTransactionResourcePath()
        {
            return transactionDetails;
        }

        public string GetTransactionType()
        {
            return this.transactionType;
        }
        public ExceptionFactory ExceptionFactory
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        
    }
}