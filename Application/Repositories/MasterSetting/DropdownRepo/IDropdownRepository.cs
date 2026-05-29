using Application.DTOs;

namespace Application.Repositories
{
    public interface IDropdownRepository
    {
        Task<List<DropdownDTO>> GetTypeDetailList();
        Task<List<DropdownDTO>> GetMasterTypeDDL();

    }
}
