using Application.DTOs;
using Data;
using Microsoft.EntityFrameworkCore;
using Model;

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

            MasterType masterType = new MasterType
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
            return new { Success = true, Message = "Master type created successfully" };
        }


        /* public async Task<object> GetAllMasterType()
         {
             var masterTypes = await _db.MasterTypes.Where(x => x.IsDelete == 0).ToListAsync();
             return new { Success = true, Data = masterTypes };
         }
 */
        public async Task<List<MasterTypeDTO>> GetAllMasterType()
        {

            var masterTypes = await (from mt in _db.MasterTypes
                                     where mt.IsDelete == 0
                                     select new MasterTypeDTO()
                                     {
                                         Id = mt.Id,
                                         Name = mt.Name,
                                         ParentId = mt.ParentId,
                                         IsActive = mt.IsActive
                                     }).ToListAsync();
            return masterTypes;
        }


        public async Task<object> GetMasterTypeById(int id)
        {
            var data = await _db.MasterTypes
                .Where(x => x.Id == id && x.IsDelete == 0)
                .Select(x => new MasterTypeDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    ParentId = x.ParentId,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync();

            if (data == null)
            {
                return new
                {
                    Success = false,
                    Message = "Data Not Found"
                };
            }

            return new
            {
                Success = true,
                Data = data
            };
        }


        public async Task<object> UpdateMasterType(MasterTypeDTO input)
        {
            var existingMasterType = await _db.MasterTypes
                .FirstOrDefaultAsync(x => x.Id == input.Id);

            if (existingMasterType == null)
            {
                return new
                {
                    Success = false,
                    Message = "MasterType Not Found"
                };
            }

            existingMasterType.Name = input.Name;
            existingMasterType.ParentId = input.ParentId;
            existingMasterType.IsActive = input.IsActive ?? 0;
            existingMasterType.IsEdit = 1;

            await _db.SaveChangesAsync();

            return new
            {
                Success = true,
                Message = "MasterType Updated Successfully"
            };
        }

        public async Task<object> DeleteMasterType(int id)
        {
            var data = await _db.MasterTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
            {
                return new
                {
                    Success = false,
                    Message = "MasterType Not Found"
                };
            }
            //soft delete 
            data.IsDelete = 1;
            data.IsActive = 0;
            _db.MasterTypes.Update(data);
            await _db.SaveChangesAsync();

            return new
            {
                Success = true,
                Message = "MasterType Deleted Successfully"
            };
        }












    }

}


