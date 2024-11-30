using UssJuniorTest.Core;
using UssJuniorTest.Core.Models;
using UssJuniorTest.Infrastructure.Store;

namespace UssJuniorTest.Infrastructure.Repositories
{
    public class DriveLogRepoository : IRepository<DriveLog>
    {
        private readonly IStore store;
        public DriveLogRepoository(IStore store) 
        {
            this.store = store;
        }
        public DriveLog? Get(long id)
        {
            return store.GetAllDriveLogs().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<DriveLog> GetAll()
        {
            return store.GetAllDriveLogs();
        }
    }
}
