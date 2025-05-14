namespace TestJobSRMD.Entity.Repository
{
    public interface IRepository<T>
    {
        public T? Get(Guid id);

        public T[] GetAll();

        public void Update(T value);

        public void Create(T value);

        public void Delete(T value);
    }
}
