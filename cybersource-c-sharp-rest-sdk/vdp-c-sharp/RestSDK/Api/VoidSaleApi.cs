using System;

namespace Cybersource.Client
{
    internal class VoidSaleApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "POST";

        public VoidSaleApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/sales/" + transactionDetails[1] + "/voids";
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