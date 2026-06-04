using Application.DTOs;
using Data;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public class PrizeMasterRepository : IPrizeMasterRepository
    {

        private readonly MissionEducationDbContext _db;
        public PrizeMasterRepository(MissionEducationDbContext db)
        {
            _db = db;
        }


        public async Task<object> CreatePrizeMaster(PrizeMasterDTO dto)
        {
            try
            {
                var data = new PrizeMaster
                {
                    AchievementTypeId = dto.AchievementTypeId,
                    Level = dto.Level,
                    MedalType = dto.MedalType,
                    SessionId = dto.SessionId,
                    Prize = dto.Prize,
                    IsActive = dto.IsActive ?? 1,
                    IsDelete = 0
                };

                await _db.PrizeMasters.AddAsync(data);
                await _db.SaveChangesAsync();

                return new
                {
                    Success = true,
                    Message = "Prize Created Successfully"
                };
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

        public async Task<List<PrizeMasterDTO>> GetAllPrizeMaster()
        {
            return await _db.PrizeMasters
                .Where(x => x.IsDelete == 0)
                .Select(x => new PrizeMasterDTO
                {
                    Id = x.Id,
                    AchievementTypeId = x.AchievementTypeId,
                    Level = x.Level,
                    MedalType = x.MedalType,
                    SessionId = x.SessionId,
                    Prize = x.Prize,
                    IsActive = x.IsActive
                })
                .ToListAsync();
        }

        public async Task<object> GetPrizeMasterById(int id)
        {
            var data = await _db.PrizeMasters
                .Where(x => x.Id == id && x.IsDelete == 0)
                .Select(x => new PrizeMasterDTO
                {
                    Id = x.Id,
                    AchievementTypeId = x.AchievementTypeId,
                    Level = x.Level,
                    MedalType = x.MedalType,
                    SessionId = x.SessionId,
                    Prize = x.Prize,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync();

            if (data == null)
            {
                return new
                {
                    Success = false,
                    Message = "Record Not Found"
                };
            }

            return new
            {
                Success = true,
                Data = data
            };
        }

        public async Task<object> UpdatePrizeMaster(PrizeMasterDTO dto)
        {
            try
            {
                var data = await _db.PrizeMasters
                    .FirstOrDefaultAsync(x => x.Id == dto.Id);

                if (data == null)
                {
                    return new
                    {
                        Success = false,
                        Message = "Record Not Found"
                    };
                }

                data.AchievementTypeId = dto.AchievementTypeId;
                data.Level = dto.Level;
                data.MedalType = dto.MedalType;
                data.SessionId = dto.SessionId;
                data.Prize = dto.Prize;
                data.IsActive = dto.IsActive ?? 1;

                await _db.SaveChangesAsync();

                return new
                {
                    Success = true,
                    Message = "Prize Updated Successfully"
                };
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
        public async Task<object> DeletePrizeMaster(int id)
        {
            var data = await _db.PrizeMasters
                .FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
            {
                return new
                {
                    Success = false,
                    Message = "Record Not Found"
                };
            }

            data.IsDelete = 1;
            data.IsActive = 0;   

            await _db.SaveChangesAsync();

            return new
            {
                Success = true,
                Message = "Prize Deleted Successfully"
            };
        }



    }
}
