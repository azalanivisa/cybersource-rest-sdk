using System;

namespace Cybersource.Client
{
    internal class RetrieveAllAuthApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "GET";

        public RetrieveAllAuthApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/authorizations";
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