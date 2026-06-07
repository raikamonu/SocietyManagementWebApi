using Application.DTOs;
using Data;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly MissionEducationDbContext _db;

        public SessionRepository(MissionEducationDbContext db)
        {
            _db = db;
        }

        public async Task<object> CreateSession(SessionDTO input)
        {
            try
            {
                

             

                Session session = new Session
                {
                    Name = input.Name,
                    SessionTypeId = input.SessionTypeId,
                    StartDate = input.StartDate,
                    EndDate = input.EndDate,
                    IsActive = input.IsActive ?? 1,
                    IsDelete = 0
                };

                await _db.Sessions.AddAsync(session);
                await _db.SaveChangesAsync();

                return new
                {
                    Success = true,
                    Message = "Session Created Successfully"
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


        public async Task<List<SessionDTO>> GetAllSession()
        {
            var data = await(from s in _db.Sessions
                        join st in _db.MasterTypeDetails on s.SessionTypeId equals st.Id into sessionTypeGroup
                        from st in sessionTypeGroup.DefaultIfEmpty()
                        where s.IsDelete == 0
                        select new SessionDTO
                        {
                            Id = s.Id,
                            Name = s.Name?? "",
                            SessionTypeId = s.SessionTypeId,
                            SessionTypeName = st != null ? st.Name : null,
                            StartDate = s.StartDate,
                            EndDate = s.EndDate,
                            IsActive = s.IsActive
                        }).ToListAsync();



            return data;
        }


        public async Task<object> GetSessionById(int id)
        {
            var data = await _db.Sessions
                .Where(x => x.Id == id && x.IsDelete == 0)
                .Select(x => new SessionDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    SessionTypeId = x.SessionTypeId,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync();

            if (data == null)
            {
                return new
                {
                    Success = false,
                    Message = "Session Not Found"
                };
            }

            return new
            {
                Success = true,
                Data = data
            };
        }

        public async Task<object> UpdateSession(SessionDTO input)
        {
            try
            {
                var existingSession = await _db.Sessions
                    .FirstOrDefaultAsync(x => x.Id == input.Id);

                if (existingSession == null)
                {
                    return new
                    {
                        Success = false,
                        Message = "Session Not Found"
                    };
                }

                if (input.StartDate >= input.EndDate)
                {
                    return new
                    {
                        Success = false,
                        Message = "Start Date must be less than End Date"
                    };
                }

                var sessionTypeExists = await _db.MasterTypeDetails
                    .AnyAsync(x => x.Id == input.SessionTypeId);

                if (!sessionTypeExists)
                {
                    return new
                    {
                        Success = false,
                        Message = "Invalid Session Type"
                    };
                }

                existingSession.Name = input.Name;
                existingSession.StartDate = input.StartDate;
                existingSession.EndDate = input.EndDate;
                existingSession.IsActive = input.IsActive ?? 1;

                await _db.SaveChangesAsync();

                return new
                {
                    Success = true,
                    Message = "Session Updated Successfully"
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



            public async Task<object> DeleteSession(int id, bool permanentDelete = false)
            {
                var data = await _db.Sessions.FirstOrDefaultAsync(x => x.Id == id);
    
                if (data == null)
                {
                    return new
                    {
                        Success = false,
                        Message = "Session Not Found"
                    };
                }
    
                if (permanentDelete)
                {
                    _db.Sessions.Remove(data);
                }
                else
                {
                    data.IsDelete = 1;
                }
    
                await _db.SaveChangesAsync();
    
                return new
                {
                    Success = true,
                    Message = "Session Deleted Successfully"
                };
        }

        //public async Task<object> DeleteSession(int id)
        //{
        //    var data = await _db.Sessions.FirstOrDefaultAsync(x => x.Id == id);

        //    if (data == null)
        //    {
        //        return new
        //        {
        //            Success = false,
        //            Message = "Session Not Found"
        //        };
        //    }

        //    data.IsDelete = 1;

        //    await _db.SaveChangesAsync();

        //    return new
        //    {
        //        Success = true,
        //        Message = "Session Deleted Successfully"
        //    };
        //}







    }
}












