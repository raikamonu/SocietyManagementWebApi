using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IPrizeMasterRepository
    {
        Task<object> CreatePrizeMaster(PrizeMasterDTO dto);
        Task<object> UpdatePrizeMaster(PrizeMasterDTO dto);
        Task<object> GetPrizeMasterById(int id);
        Task<List<PrizeMasterDTO>> GetAllPrizeMaster();
        Task<object> DeletePrizeMaster(int id);


    }
}
