using System.Threading.Tasks;
using TestJobSRMD.Entity.Models;

namespace TestJobSRMD.Entity.Repository
{
    public class ContactRepository : RepositoryBase<Contact>
    {
        public ContactRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
        }

        public override void Create(Contact value)
        {
            dbContext.Contacts.Add(value);
        }

        public override void Delete(Contact value)
        {
            dbContext.Contacts.Remove(value);
        }

        public override Contact? Get(Guid id)
        {
            return dbContext.Contacts.Find(id);
        }

        public async Task<Contact?> GetAsync(Guid id)
        {
            return await dbContext.Contacts.FindAsync(id);
        }

        public override Contact[] GetAll()
        {
            return dbContext.Contacts.ToArray();
        }

        public override void Update(Contact value)
        {
            dbContext.Contacts.Update(value);
        }
    }
}
