using Application.DTOs;

namespace Application.Repositories
{
    public interface IMasterTypeDetailRepository
    {
        Task<object> CreateMasterTypeDetail(MasterTypeDetailDTO input);

        Task<List<MasterTypeDetailDTO>> GetAllMasterTypeDetail();

        Task<object> GetMasterTypeDetailById(int id);

        Task<object> UpdateMasterTypeDetail(MasterTypeDetailDTO input);
        Task<object> DeleteMasterTypeDetail(int id, bool permanentDelete = false);

        //Task<object> DeleteMasterTypeDetail(int id);

    }
}
