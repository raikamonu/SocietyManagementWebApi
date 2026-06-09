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
                Srno = input.Srno,
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


       
        public async Task<List<VMasterTypeDTO>> GetAllMasterType()
        {

            var masterTypes = await (from mt in _db.MasterTypes
                                    join pmt in _db.MasterTypes on mt.ParentId equals pmt.Id into Parent
                                    from pmt in Parent.DefaultIfEmpty()
                                     where mt.IsDelete == 0
                                     select new VMasterTypeDTO()
                                     {
                                         Id = mt.Id,
                                         Srno = mt.Srno,
                                         Name = mt.Name,
                                         ParentName = pmt.Name,
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
                    Srno = x.Srno,
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
            existingMasterType.Srno = input.Srno;
            existingMasterType.Name = input.Name;
            existingMasterType.ParentId = input.ParentId;
            existingMasterType.IsActive = input.IsActive ?? 0;
           

            await _db.SaveChangesAsync();

            return new
            {
                Success = true,
                Message = "MasterType Updated Successfully"
            };
        }








            public async Task<object> DeleteMasterType(int id, bool permanentDelete = false)
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
    
                if (permanentDelete)
                {
                    _db.MasterTypes.Remove(data);
                }
                else
                {
                    //soft delete 
                    data.IsDelete = 1;
                    data.IsActive = 0;
                    _db.MasterTypes.Update(data);
                }
                
                await _db.SaveChangesAsync();
    
                return new
                {
                    Success = true,
                    Message = permanentDelete ? "MasterType Permanently Deleted Successfully" : "MasterType Deleted Successfully"
                };
        }

       









    }

}


