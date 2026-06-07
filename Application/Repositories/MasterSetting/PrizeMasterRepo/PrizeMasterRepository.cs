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
            var data = await (
                from p in _db.PrizeMasters

                join ach in _db.MasterTypeDetails
                    on p.AchievementTypeId equals ach.Id

                join lvl in _db.MasterTypeDetails
                    on p.Level equals lvl.Id

                join med in _db.MasterTypeDetails
                    on p.MedalType equals med.Id

                join ses in _db.Sessions
                    on p.SessionId equals ses.Id

                where p.IsDelete == 0

                select new PrizeMasterDTO
                {
                    Id = p.Id,

                    AchievementTypeId = p.AchievementTypeId,
                    AchievementTypeName = ach.Name,

                    Level = p.Level,
                    LevelName = lvl.Name,

                    MedalType = p.MedalType,
                    MedalTypeName = med.Name,

                    SessionId = p.SessionId,
                    SessionName = ses.Name,

                    Prize = p.Prize,
                    IsActive = p.IsActive
                }
            ).ToListAsync();

            return data;
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



        public async Task<object> DeletePrizeMaster(int id, bool permanentDelete = false)
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
            if (permanentDelete)
            {
                _db.PrizeMasters.Remove(data);
            }
            else
            {
                data.IsDelete = 1;
                data.IsActive = 0;
            }
            await _db.SaveChangesAsync();
            return new
            {
                Success = true,
                Message = "Prize Deleted Successfully"
            };
        }

        //public async Task<object> DeletePrizeMaster(int id)
        //{
        //    var data = await _db.PrizeMasters
        //        .FirstOrDefaultAsync(x => x.Id == id);

        //    if (data == null)
        //    {
        //        return new
        //        {
        //            Success = false,
        //            Message = "Record Not Found"
        //        };
        //    }

        //    data.IsDelete = 1;
        //    data.IsActive = 0;   

        //    await _db.SaveChangesAsync();

        //    return new
        //    {
        //        Success = true,
        //        Message = "Prize Deleted Successfully"
        //    };
        //}



    }
}
