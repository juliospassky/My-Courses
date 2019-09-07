namespace GTSharp.Infra.Transactions
{
    interface IUnitOfWork
    {
        void Commit();
    }
}
