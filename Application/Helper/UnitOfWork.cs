using Application.Repositories;
using Data;

namespace Application.Helper
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly MissionEducationDbContext _db;
        public IMasterTypeRepository MasterType { get; private set; }
        public UnitOfWork(MissionEducationDbContext db)
        {
            _db = db;

            MasterType=new MasterTypeRepository(db);
        }

       
         
    }
}
