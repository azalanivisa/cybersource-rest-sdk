using System;

namespace Cybersource.Client
{
    internal class VoidCaptureApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "POST";

        public VoidCaptureApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/captures/" + transactionDetails[1] + "/voids";
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