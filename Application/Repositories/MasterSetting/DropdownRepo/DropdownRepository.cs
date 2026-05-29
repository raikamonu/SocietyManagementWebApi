using Application.DTOs;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class DropdownRepository : IDropdownRepository
    {
        private readonly MissionEducationDbContext _db;
        public DropdownRepository(Data.MissionEducationDbContext db)
        {
            _db = db;
        }


        public async Task<List<DropdownDTO>> GetMasterTypeDDL()
        {
            var data = await (from mt in _db.MasterTypes
                              where mt.IsDelete == 0
                              && mt.IsActive == 1
                               && mt.Name != null
                               && mt.Name != ""
                              select new DropdownDTO()
                              {
                                  Id = mt.Id,
                                  Name = mt.Name
                              }).ToListAsync();
            return data;
        }

       
        public async Task<List<DropdownDTO>> GetTypeDetailList()
        {
            var data = await (from mtd in _db.MasterTypeDetails
                              where mtd.IsDelete == 0
                              && mtd.IsActive == 1
                              && mtd.Name != null
                              && mtd.Name != ""
                              select new DropdownDTO()
                              {
                                  Id = mtd.Id,
                                  Name = mtd.Name
                              }).ToListAsync();

            return data;
        }


    }
}