using System;

namespace Cybersource.Client
{
    internal class RefundSaleApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "POST";

        public RefundSaleApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/sales/" + transactionDetails[1] + "/refunds";
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