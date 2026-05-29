using Application.DTOs;
using Application.DTOs.MasterType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IMasterTypeDetailRepository
    {
        Task<object> CreateMasterTypeDetail(MasterTypeDetailDTO input);

        Task<List<MasterTypeDetailDTO>> GetAllMasterTypeDetail();

        Task<object> GetMasterTypeDetailById(int id);

        Task<object> UpdateMasterTypeDetail(MasterTypeDetailDTO input);

        Task<object> DeleteMasterTypeDetail(int id);

    }
}
