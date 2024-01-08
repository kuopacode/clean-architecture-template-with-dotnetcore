using Product.Infrastucture.Seedworks;
using System.Data;

namespace Product.Api.Applications.Seedworls
{
    public class UnitOfWork : IUnitOfWorkDapper
    {
        public IDbTransaction Transaction { get; private set; }

        public IDbConnection Master { get; private set; }

        public IDbConnection Slave { get; private set; }

        public void BeginTransaction()
        {
            if (Transaction != null)
                return;

            if (Master.State != ConnectionState.Open)
                Master.Open();

            Transaction = Master.BeginTransaction();
        }

        public UnitOfWork(IDbConnection Master, IDbConnection Slave)
        {
            this.Master = Master;
            this.Slave = Slave;
        }

        public UnitOfWork(IDbConnection dbConnection)
        {
            Master = dbConnection;
            Slave = dbConnection;
        }

        public void Commit()
        {
            Transaction.Commit();

            if (Master.State != ConnectionState.Closed)
                Master.Close();
        }

        public void RollBack()
        {
            Transaction.Rollback();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                if (Transaction != null)
                {
                    Transaction.Dispose();
                    Transaction = null;
                }
                if (Master != null)
                {
                    Master.Dispose();
                    Master = null;
                }
                if (Slave != null)
                {
                    Slave.Dispose();
                    Slave = null;
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
