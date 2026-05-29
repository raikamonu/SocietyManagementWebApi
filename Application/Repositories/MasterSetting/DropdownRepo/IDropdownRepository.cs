using Application.DTOs;
using Application.DTOs.Dropdown;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IDropdownRepository
    {
        Task<List<DropdownDTO>> GetParentDDL();
        Task<List<DropdownDTO>> GetMasterTypeDDL();
        Task<List<DropdownDTO>> GetMasterTypeParentDDL();

    }
}
