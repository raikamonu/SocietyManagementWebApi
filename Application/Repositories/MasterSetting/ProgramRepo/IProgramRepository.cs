using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IProgramRepository
    {
        public Task<object> CreateProgram(ProgramDTO input);

        public Task<object> UpdateProgram(ProgramDTO input);

        public Task<object> GetProgramById(int id);

        Task<List<ProgramDTO>> GetAllProgram();

        public Task<object> DeleteProgram(int id);


        //Task<object> CreateProgram(ProgramDTO input);

        //Task<object> UpdateProgram(ProgramDTO input);

        //Task<object> GetProgramById(int id);

        //Task<object> GetAllProgram();

        //Task<object> DeleteProgram(int id);

    }
}
