using System;

namespace Cybersource.Client
{
    internal class RetrieveReversalApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "POST";

        public RetrieveReversalApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/reversals/" + transactionDetails[1];
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