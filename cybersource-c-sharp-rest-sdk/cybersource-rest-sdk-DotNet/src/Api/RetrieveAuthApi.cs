using System;

namespace Cybersource.Client
{
    internal class RetrieveAuthApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "GET";

        public RetrieveAuthApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/authorizations/" + transactionDetails[1];
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