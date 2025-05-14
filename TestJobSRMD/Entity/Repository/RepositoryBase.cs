namespace TestJobSRMD.Entity.Repository
{
    public abstract class RepositoryBase<T> : IRepository<T>
    {
        protected ApplicationDbContext dbContext;

        public RepositoryBase(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public abstract void Create(T value);
        public abstract void Delete(T value);
        public abstract T? Get(Guid id);
        public abstract T[] GetAll();
        public abstract void Update(T value);

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
