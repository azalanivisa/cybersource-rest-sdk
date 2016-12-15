using System;

namespace Cybersource.Client
{
    internal class CaptureApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "POST";

        public CaptureApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/authorizations/" + transactionDetails[1] + "/captures";
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