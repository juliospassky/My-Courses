using GTSharp.Infra.Persistence;

namespace GTSharp.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GTSharpContext _context;

        public UnitOfWork(GTSharpContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
