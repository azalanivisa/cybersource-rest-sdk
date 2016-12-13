using System;

namespace Cybersource.Client
{
    internal class RetrieveCreditApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "GET";

        public RetrieveCreditApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/credits/" + transactionDetails[1];
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