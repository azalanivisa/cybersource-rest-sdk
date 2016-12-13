using System;

namespace Cybersource.Client
{
    internal class AuthReversalApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "POST";


        public AuthReversalApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/authorizations/" + transactionDetails[1] +"/reversals";
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