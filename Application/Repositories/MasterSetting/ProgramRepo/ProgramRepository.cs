using Application.DTOs;
using Data;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;



namespace Application.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly MissionEducationDbContext _db;

            public ProgramRepository(MissionEducationDbContext db)
            {
                _db = db;
              }



        public async Task<object> CreateProgram(ProgramDTO input)
        {
            try
            {
                var program = new Program
                {
                    Name = input.Name,
                    LocationId = input.LocationId,
                    SessionId = input.SessionId,
                    StartDate = input.StartDate,
                    EndDate = input.EndDate,
                    IsActive = input.IsActive ?? 1,
                    IsDelete = 0
                };

                await _db.Programs.AddAsync(program);
                await _db.SaveChangesAsync();

                return new
                {
                    Success = true,
                    Message = "Program Created Successfully"
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Success = false,
                    Message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }





        public async Task<List<ProgramDTO>> GetAllProgram()
        {
            return await _db.Programs
                .Where(x => x.IsDelete == 0)
                .Select(x => new ProgramDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    SessionId = x.SessionId,
                    LocationId = x.LocationId,
                    IsActive = x.IsActive,
                    IsDelete = x.IsDelete
                })
                .ToListAsync();
        }



        public async Task<object> GetProgramById(int id)
        {
            try
            {
                var program = await _db.Programs
                    .FirstOrDefaultAsync(x => x.Id == id && x.IsDelete == 0);

                if (program == null)
                {
                    return new
                    {
                        Success = false,
                        Message = "Program not found"
                    };
                }

                return new
                {
                    Success = true,
                    Data = program
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }




        public async Task<object> UpdateProgram(ProgramDTO input)
        {
            try
            {
                var program = await _db.Programs
                    .FirstOrDefaultAsync(x => x.Id == input.Id && x.IsDelete == 0);

                if (program == null)
                {
                    return new
                    {
                        Success = false,
                        Message = "Program not found"
                    };
                }

                program.Name = input.Name;
                program.LocationId = input.LocationId;
                program.SessionId = input.SessionId;
                program.StartDate = input.StartDate;
                program.EndDate = input.EndDate;
                program.IsActive = input.IsActive ?? program.IsActive;

                _db.Programs.Update(program);
                await _db.SaveChangesAsync();

                return new
                {
                    Success = true,
                    Message = "Program updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Success = false,
                    Message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }



        public async Task<object> DeleteProgram(int id)
        {
            try
            {
                var program = await _db.Programs
                    .FirstOrDefaultAsync(x => x.Id == id && x.IsDelete == 0);

                if (program == null)
                {
                    return new
                    {
                        Success = false,
                        Message = "Program not found"
                    };
                }

                program.IsDelete = 1;
                program.IsActive = 0;

                _db.Programs.Update(program);
                await _db.SaveChangesAsync();

                return new
                {
                    Success = true,
                    Message = "Program deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }










    }
}
