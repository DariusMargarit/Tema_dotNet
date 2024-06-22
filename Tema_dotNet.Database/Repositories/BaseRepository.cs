using Tema_dotNet.Database.Context;

namespace Tema_dotNet.Database.Repositories
{
    public class BaseRepository
    {
        protected readonly ProducatorManagementDBContext _producatorManagementDbContext;

        public BaseRepository(ProducatorManagementDBContext producatorManagementDBContext)
        {
            this._producatorManagementDbContext = producatorManagementDBContext;
        }

        public void SaveChanges()
        {
            _producatorManagementDbContext.SaveChanges();
        }
    }
}