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
                              where mt.IsDelete == 0 &&
                              mt.IsActive == 1
                              select new DropdownDTO()
                              {
                                  Id = mt.Id,
                                  Name = mt.Name
                              }).ToListAsync(); return data;
        }


        public async Task<List<DropdownDTO>> GetTypeDetailList()
        {
            var data = await (from mtd in _db.MasterTypeDetails
                              where mtd.IsDelete == 0
                                    && mtd.IsActive == 1
                              select new DropdownDTO()
                              {
                                  Id = mtd.Id,
                                  Name = mtd.Name
                              }).ToListAsync();

            return data;
        }


        public async Task<List<DropdownDTO>> GetTypeById(int typeId)
        {
            var data = await (from mtd in _db.MasterTypeDetails
                              where mtd.IsDelete == 0
                                    && mtd.IsActive == 1 && mtd.MasterTypeId == typeId
                              select new DropdownDTO()
                              {
                                  Id = mtd.Id,
                                  Name = mtd.Name
                              }).ToListAsync();

            return data;
        }

        public async Task<List<DropdownDTO>> GetLocationDDL()
        {
            var data = await (from l in _db.Locations
                              where l.IsActive == 1  
                              select new DropdownDTO()
                              {
                                  Id = l.Id,
                                  Name = l.Name
                              }).ToListAsync();
            return data;

        }


        //public async Task<List<DropdownDTO>> GetSessionTypeDDL()
        //{
        //    var data = await (from mtd in _db.MasterTypeDetails
        //                      select new DropdownDTO
        //                      {
        //                          Id = mtd.Id,
        //                          Name = mtd.Name
        //                      }).ToListAsync();

        //    return data;
        //}





        public async Task<List<DropdownDTO>> GetSessionDDL()
        {
            var data = await _db.Sessions
                .Where(x => x.IsActive == 1)
                .Select(x => new DropdownDTO
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            return data;
        }


    }
}