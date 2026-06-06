using Application.DTOs;

namespace Application.Repositories
{
    public interface IMasterTypeRepository
    {
        public Task<object> CreateMasterType(MasterTypeDTO input);
        public Task<object> UpdateMasterType(MasterTypeDTO input);
        public Task<object> GetMasterTypeById(int id);
        Task<List<VMasterTypeDTO>> GetAllMasterType();
        public Task<object> DeleteMasterType(int id);
    }
}
