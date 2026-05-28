using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IMasterTypeRepository
    {
        public Task<object> CreateMasterType(MasterTypeDTO input);
    }
}
