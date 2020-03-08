namespace GTSharp.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
