using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface ISessionRepository
    {
       
            public Task<object> CreateSession(SessionDTO input);
        public Task<object> UpdateSession(SessionDTO input);
        public Task<object> GetSessionById(int id);
        Task<List<SessionDTO>> GetAllSession();
        public Task<object> DeleteSession(int id);
    }
}
