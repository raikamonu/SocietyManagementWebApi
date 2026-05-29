using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public class DropdownRepository : IDropdownRepository
    {
        private readonly Data.MissionEducationDbContext _db;
        public DropdownRepository(Data.MissionEducationDbContext db)
        {
            _db = db;
        }

        public async Task<List<DTOs.Dropdown.DropdownDTO>> GetMasterTypeDDL()
        {
            var data = await (from mt in _db.MasterTypes
                              where mt.IsDelete == 0
                              select new DTOs.Dropdown.DropdownDTO()
                              {
                                  Id = mt.Id,
                                  Name = mt.Name
                              }).ToListAsync();
            return data;
        }

        public async Task<List<DTOs.Dropdown.DropdownDTO>> GetParentDDL()
        {
            var data = await (from mtd in _db.MasterTypeDetails
                              where mtd.IsDelete == 0
                              select new DTOs.Dropdown.DropdownDTO()
                              {
                                  Id = mtd.Id,
                                  Name = mtd.Name
                              }).ToListAsync();
            return data;
        }
    }
}