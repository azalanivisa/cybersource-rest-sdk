using System;

namespace Cybersource.Client
{
    internal class RetrieveAllCaptureApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "GET";

        public RetrieveAllCaptureApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/captures";
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