using System;

namespace Cybersource.Client
{
    internal class PaymentSearchApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "POST";

        public PaymentSearchApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/search";
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