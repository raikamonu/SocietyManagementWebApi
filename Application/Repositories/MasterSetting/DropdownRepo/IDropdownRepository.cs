using Application.DTOs;

namespace Application.Repositories
{
    public interface IDropdownRepository
    {
        Task<List<DropdownDTO>> GetTypeDetailList();
        Task<List<DropdownDTO>> GetMasterTypeDDL();
        Task<List<DropdownDTO>> GetLocationDDL();
        Task<List<DropdownDTO>> GetTypeById(int typeId);
        //Task<List<DropdownDTO>> GetSessionDDL();
        Task<List<DropdownDTO>> GetSessionDDL(int sessionId);
        Task<List<DropdownDTO>> GetStateDDL();
        Task<List<DropdownDTO>> GetCityDDL(int stateId);


    }
}
