using Cybersource.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cybersource.Api
{
    class AuthorizationApi : IApiAccessor
    {
        private string transactionDetails;
        private string transactionType = "POST";

        public AuthorizationApi(string[] transactionDetails)
        {
            this.transactionDetails = "payments/v1/authorizations";
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