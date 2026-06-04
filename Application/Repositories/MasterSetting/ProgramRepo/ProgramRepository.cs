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
                if (input.StartDate.HasValue && input.EndDate.HasValue &&
                    input.EndDate < input.StartDate)
                {
                    return new
                    {
                        Success = false,
                        Message = "End Date cannot be earlier than Start Date"
                    };
                }

                var program = new Program
                {
                    Name = input.Name,
                    LocationId = input.LocationId,
                    SessionId = input.SessionId,

                    StartDate = input.StartDate ?? DateTime.Now,
                    EndDate = input.EndDate ?? DateTime.Now,

                    IsActive = input.IsActive ?? 1,
                    IsDelete = 0,

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

                int? districtId = null;
                int? stateId = null;

                if (program.LocationId.HasValue)
                {
                    var city = await _db.Locations
                        .FirstOrDefaultAsync(x => x.Id == program.LocationId);

                    if (city != null)
                    {
                        districtId = city.ParentId;

                        if (city.ParentId.HasValue)
                        {
                            var district = await _db.Locations
                                .FirstOrDefaultAsync(x => x.Id == city.ParentId);

                            if (district != null)
                            {
                                stateId = district.ParentId;
                            }
                        }
                    }
                }

                var dto = new ProgramDTO
                {
                    Id = program.Id,
                    Name = program.Name,
                    LocationId = program.LocationId,
                    SessionId = program.SessionId,
                    StartDate = program.StartDate,
                    EndDate = program.EndDate,
                    IsActive = program.IsActive,
                    IsDelete = program.IsDelete,

                    DistrictId = districtId,
                    StateId = stateId
                };

                return new
                {
                    Success = true,
                    Data = dto
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
                var program = await _db.Programs.FindAsync(input);

                if (program == null)
                {
                    return new
                    {
                        Success = false,
                        Message = "Program not found"
                    };
                }

                if (input.StartDate.HasValue && input.EndDate.HasValue &&
                    input.EndDate < input.StartDate)
                {
                    return new
                    {
                        Success = false,
                        Message = "End Date cannot be earlier than Start Date"
                    };
                }

                program.Name = input.Name;
                program.LocationId = input.LocationId;
                program.SessionId = input.SessionId;
                program.StartDate = input.StartDate ?? program.StartDate;
                program.EndDate = input.EndDate ?? program.EndDate;
                program.IsActive = input.IsActive ?? program.IsActive;


                await _db.SaveChangesAsync();

                return new
                {
                    Success = true,
                    Message = "Program Updated Successfully"
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
