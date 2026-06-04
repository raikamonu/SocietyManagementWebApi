using Application.DTOs;

namespace Application.Repositories
{
    public interface IDropdownRepository
    {
        Task<List<DropdownDTO>> GetTypeDetailList();
        Task<List<DropdownDTO>> GetMasterTypeDDL();
        Task<List<DropdownDTO>> GetLocationDDL();
        Task<List<DropdownDTO>> GetTypeById(int typeId);
        Task<List<DropdownDTO>> GetSessionDDL(int sessionTypeId);
        Task<List<DropdownDTO>> GetStateDDL();
        Task<List<DropdownDTO>> GetCommonLocation(int typeId, int parentId);
        Task<List<DropdownDTO>> GetProgramDDL();
        Task<List<DropdownDTO>> GetMembershipPlanDDL();
        Task<List<DropdownDTO>> GetAchievementTypeDropdown();
        Task<List<DropdownDTO>> GetLevelDropdown();
        Task<List<DropdownDTO>> GetSessionDropdown();
        Task<List<DropdownDTO>> GetMedalTypeDropdown();



        //Task<List<DropdownDTO>> GetPrizeMasterDDL();



    }
}
