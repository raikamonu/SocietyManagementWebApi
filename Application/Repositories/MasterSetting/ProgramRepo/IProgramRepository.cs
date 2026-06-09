using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IProgramRepository
    {
         Task<object> CreateProgram(ProgramDTO input);

         Task<object> UpdateProgram(ProgramDTO input);

         Task<object> GetProgramById(int id);

        Task<List<ProgramDTO>> GetAllProgram();
        Task<object> DeleteProgram(int id, bool permanentDelete = false);



    }
}
