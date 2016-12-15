using System;

namespace Cybersource.Client
{
    internal class CreditApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "POST";

        public CreditApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/credits";
        }

        public string GetTransactionResourcePath()
        {
            return this.transactionDetails;
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