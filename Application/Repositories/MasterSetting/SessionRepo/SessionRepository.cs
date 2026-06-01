using Application.DTOs;
using Data;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            Session session = new Session
            {
                Name = input.Name,
                SessionTypeId = input.SessionTypeId,
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                IsActive = input.IsActive ?? 1
            };

            await _db.Sessions.AddAsync(session);
            await _db.SaveChangesAsync();

            return new
            {
                Success = true,
                Message = "Session Created Successfully"
            };
        }

        


        public async Task<List<SessionDTO>> GetAllSession()
        {
            var sessions = await (from s in _db.Sessions
                                  where s.IsActive == 1
                                  select new SessionDTO
                                  {
                                      Id = s.Id,
                                      Name = s.Name,
                                      SessionTypeId = s.SessionTypeId,
                                      StartDate = s.StartDate,
                                      EndDate = s.EndDate,
                                      IsActive = s.IsActive
                                  }).ToListAsync();
           
            return sessions;
        }
        public async Task<object> GetSessionById(int id)
        {
            var data = await _db.Sessions
                .Where(x => x.Id == id)
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

            existingSession.Name = input.Name;
            existingSession.SessionTypeId = input.SessionTypeId;
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

        public async Task<object> DeleteSession(int id)
        {
            var data = await _db.Sessions
                .FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
            {
                return new
                {
                    Success = false,
                    Message = "Session Not Found"
                };
            }

            _db.Sessions.Remove(data);
            await _db.SaveChangesAsync();

            return new
            {
                Success = true,
                Message = "Session Deleted Successfully"
            };
        }



    }
}












