namespace Cybersource.Client
{
    internal class TransactionManager
    {
        public string transactionType;
        private string transactionId;

        public string TransactionId
        {
            get
            {
                return transactionId;
            }

            set
            {
                transactionId = value;
            }
        }
    }

}