using Application.Repositories;
using Data;

namespace Application.Helper
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MissionEducationDbContext _db;

        public IMasterTypeRepository MasterType { get; private set; }
        public IMasterTypeDetailRepository MasterTypeDetail { get; private set; }
        public IDropdownRepository Dropdown { get; private set; }
        public ILocationRepository Location { get; private set; }
        public ISessionRepository Session { get; private set; }
        

        public UnitOfWork(MissionEducationDbContext db)
        {
            _db = db;

            MasterType = new MasterTypeRepository(db);
            MasterTypeDetail = new MasterTypeDetailRepository(db);
            Dropdown = new DropdownRepository(db);
            Location = new LocationRepository(db);
            Session = new SessionRepository(db);
        }
    }
}