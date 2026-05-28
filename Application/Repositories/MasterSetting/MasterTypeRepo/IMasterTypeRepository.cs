using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IMasterTypeRepository
    {
        public Task<object> CreateMasterType(MasterTypeDTO input);
        public Task<object> UpdateMasterType(MasterTypeDTO input);
        public Task<object> GetMasterTypeById(int id);
        Task<List<MasterTypeDTO>> GetAllMasterType();
         public Task<object> DeleteMasterType(int id);
    }
}
