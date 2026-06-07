using Application.DTOs;

namespace Application.Repositories
{
    public interface IMasterTypeRepository
    {
        public Task<object> CreateMasterType(MasterTypeDTO input);
        public Task<object> UpdateMasterType(MasterTypeDTO input);
        public Task<object> GetMasterTypeById(int id);
        Task<List<VMasterTypeDTO>> GetAllMasterType();
        Task<object> DeleteMasterType(int id, bool permanentDelete = false);
        //public Task<object> DeleteMasterType(int id);
    }
}
