using Application.DTOs;

namespace Application.Repositories
{
    public interface IMasterTypeRepository
    {
         Task<object> CreateMasterType(MasterTypeDTO input);
         Task<object> UpdateMasterType(MasterTypeDTO input);
         Task<object> GetMasterTypeById(int id);
        Task<List<VMasterTypeDTO>> GetAllMasterType();
        Task<object> DeleteMasterType(int id, bool permanentDelete = false);
    }
}
