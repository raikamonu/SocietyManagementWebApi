using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface ISessionRepository
    {
       
         Task<object> CreateSession(SessionDTO input);
        Task<object> UpdateSession(SessionDTO input);
        Task<object> GetSessionById(int id);
        Task<List<SessionDTO>> GetAllSession();
        Task<object> DeleteSession(int id, bool permanentDelete = false);
    }
}
