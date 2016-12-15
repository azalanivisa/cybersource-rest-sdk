using System;

namespace Cybersource.Client
{
    internal class RetrieveAllRefundApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "GET";

        public RetrieveAllRefundApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/refund";
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