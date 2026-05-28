using Application.DTOs;
using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public class MasterTypeRepository : IMasterTypeRepository
    {
        private readonly MissionEducationDbContext _db;
        public MasterTypeRepository(MissionEducationDbContext db)
        {
            _db = db;
        }

        public async Task<object> CreateMasterType(MasterTypeDTO input)
        {
           MasterType masterType=new MasterType
           {
               Name = input.Name,
               ParentId = input.ParentId,
               IsActive = input.IsActive ?? 0,
               IsDelete = 0,
               IsEdit = 0,
               Date = DateTime.Now

           };
           await _db.MasterTypes.AddAsync(masterType);
           await _db.SaveChangesAsync();
           return new { Success =true,Message="Master type created successfully"};
        }
    }
}
