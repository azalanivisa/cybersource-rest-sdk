using System;

namespace Cybersource.Client
{
    internal class RefundSaleIdApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "GET";

        public RefundSaleIdApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/sales/" + transactionDetails[1] + "/refunds";
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