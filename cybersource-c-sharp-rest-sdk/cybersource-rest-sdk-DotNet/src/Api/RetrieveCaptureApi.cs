using System;

namespace Cybersource.Client
{
    internal class RetrieveCaptureApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "GET";

        public RetrieveCaptureApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/captures/" + transactionDetails[1];
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