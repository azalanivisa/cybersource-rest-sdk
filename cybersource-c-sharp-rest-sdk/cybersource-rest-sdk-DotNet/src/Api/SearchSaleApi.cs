using System;

namespace Cybersource.Client
{
    internal class SearchSaleApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "GET";

        public SearchSaleApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/sales/" + transactionDetails[1];
        }

        public string GetTransactionType()
        {
            return this.transactionType;
        }

        public string GetTransactionResourcePath()
        {
            return this.transactionDetails;
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