using Application.DTOs;
using Data;
using Microsoft.EntityFrameworkCore;
using Model;



namespace Application.Repositories
{
    public class MasterTypeDetailRepository : IMasterTypeDetailRepository
    {
        private readonly MissionEducationDbContext _db;
        public MasterTypeDetailRepository(MissionEducationDbContext db)
        {
            _db = db;
        }

        

        public async Task<object> CreateMasterTypeDetail(MasterTypeDetailDTO input)
        {
            try
            {
                MasterTypeDetail masterTypeDetail = new MasterTypeDetail()
                {
                    Code = input.Code,
                    Name = input.Name,
                    ParentId = input.ParentId,
                    MasterTypeId = input.MasterTypeId,
                    IsActive = input.IsActive ?? 0,
                    IsDelete = 0,
                    IsEdit = 0,
                    Date = DateTime.Now
                };

                await _db.MasterTypeDetails.AddAsync(masterTypeDetail);
                await _db.SaveChangesAsync();

                return new { Success = true, Message = "Created successfully" };
            }
            catch (Exception ex)
            {
                return new
                {
                    Success = false,
                    Message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public async Task<List<MasterTypeDetailDTO>> GetAllMasterTypeDetail()
        {
            var masterTypeDetails = await (from mtd in _db.MasterTypeDetails
                                           where mtd.IsDelete == 0
                                           select new MasterTypeDetailDTO()
                                           {
                                               Id = mtd.Id,
                                               Code = mtd.Code,
                                               Name = mtd.Name,
                                               ParentId = mtd.ParentId,
                                               MasterTypeId = mtd.MasterTypeId,
                                               IsActive = mtd.IsActive
                                           }).ToListAsync();
            return masterTypeDetails;
        }



        public async Task<object> GetMasterTypeDetailById(int id)
        {
            var data = await _db.MasterTypeDetails
                .Where(x => x.Id == id && x.IsDelete == 0)
                .Select(x => new MasterTypeDetailDTO
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    ParentId = x.ParentId,
                    MasterTypeId = x.MasterTypeId,
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




        public async Task<object> UpdateMasterTypeDetail(MasterTypeDetailDTO input)
        {
            var existingMasterTypeDetail = await _db.MasterTypeDetails
                .FirstOrDefaultAsync(x => x.Id == input.Id);
            if (existingMasterTypeDetail == null)
            {
                return new
                {
                    Success = false,
                    Message = "MasterTypeDetail Not Found"
                };
            }
            existingMasterTypeDetail.Code = input.Code;
            existingMasterTypeDetail.Name = input.Name;
            existingMasterTypeDetail.ParentId = input.ParentId;
            existingMasterTypeDetail.MasterTypeId = input.MasterTypeId;
            existingMasterTypeDetail.IsActive = input.IsActive ?? 0;
            existingMasterTypeDetail.IsEdit = 1;
            await _db.SaveChangesAsync();
            return new
            {
                Success = true,
                Message = "MasterTypeDetail Updated Successfully"
            };
        }


        public async Task<object> DeleteMasterTypeDetail(int id)
        {
            var data = await _db.MasterTypeDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return new
                {
                    Success = false,
                    Message = "MasterTypeDetail Not Found"
                };
            }
            data.IsDelete = 1;
            data.IsActive = 0;
            _db.MasterTypeDetails.Update(data);
            await _db.SaveChangesAsync();
            return new
            {
                Success = true,
                Message = "MasterTypeDetail Deleted Successfully"
            };
        }









    }
}
