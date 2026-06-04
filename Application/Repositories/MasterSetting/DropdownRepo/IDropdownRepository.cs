using Application.DTOs;

namespace Application.Repositories
{
    public interface IDropdownRepository
    {
        Task<List<DropdownDTO>> GetTypeDetailList();
        Task<List<DropdownDTO>> GetMasterType();
        Task<List<DropdownDTO>> GetLocation();
        Task<List<DropdownDTO>> GetTypeById(int typeId);
        Task<List<DropdownDTO>> GetSession(int sessionTypeId);
        Task<List<DropdownDTO>> GetState();
        Task<List<DropdownDTO>> GetCommonLocation(int typeId, int parentId);
        Task<List<DropdownDTO>> GetProgram();
        Task<List<DropdownDTO>> GetMembershipPlan();
        Task<List<DropdownDTO>> GetSessionDropdown();



        //Task<List<DropdownDTO>> GetPrizeMasterDDL();



    }
}
