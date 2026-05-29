using Application.DTOs;

namespace Application.Repositories
{
    public interface IDropdownRepository
    {
        Task<List<DropdownDTO>> GetParentDDL();
        Task<List<DropdownDTO>> GetMasterTypeDDL();
        Task<List<DropdownDTO>> GetMasterTypeParentDDL();

    }
}
