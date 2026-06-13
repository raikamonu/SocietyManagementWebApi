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
            var data = await (
                from p in _db.Programs

                    // city
                join city in _db.Locations
                    on p.LocationId equals city.Id into cityJoin
                from city in cityJoin.DefaultIfEmpty()

                    // block parent of city
                join block in _db.Locations
                    on city.ParentId equals block.Id into blockJoin
                from block in blockJoin.DefaultIfEmpty()

                    // district parent of block
                join district in _db.Locations
                    on block.ParentId equals district.Id into districtJoin
                from district in districtJoin.DefaultIfEmpty()

                    // state parent of district
                join state in _db.Locations
                    on district.ParentId equals state.Id into stateJoin
                from state in stateJoin.DefaultIfEmpty()

                    // country parent of state
                join country in _db.Locations
                    on state.ParentId equals country.Id into countryJoin
                from country in countryJoin.DefaultIfEmpty()

                where p.IsDelete == 0

                select new ProgramDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    SessionId = p.SessionId,
                    LocationId = p.LocationId,
                    IsActive = p.IsActive,
                    IsDelete = p.IsDelete,

                    CityName = city != null ? city.Name : null,
                    BlockName = block != null ? block.Name : null,
                    DistrictName = district != null ? district.Name : null,
                    StateName = state != null ? state.Name : null,
                    CountryName = country != null ? country.Name : null,

                    BlockId = block != null ? block.Id : null,
                    DistrictId = district != null ? district.Id : null,
                    StateId = state != null ? state.Id : null,
                    CountryId = country != null ? country.Id : null
                }
            ).ToListAsync();

            return data;
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

                int? blockId = null;
                int? districtId = null;
                int? stateId = null;
                int? countryId = null;



                if (program.LocationId.HasValue)
                {
                    var city = await _db.Locations
        .FirstOrDefaultAsync(x => x.Id == program.LocationId);

                    if (city != null)
                    {
                        // Block
                        blockId = city.ParentId;

                        if (blockId.HasValue)
                        {
                            var block = await _db.Locations
                                .FirstOrDefaultAsync(x => x.Id == blockId);

                            if (block != null)
                            {
                                // District
                                districtId = block.ParentId;

                                if (districtId.HasValue)
                                {
                                    var district = await _db.Locations
                                        .FirstOrDefaultAsync(x => x.Id == districtId);

                                    if (district != null)
                                    {
                                        // State
                                        stateId = district.ParentId;

                                        if (stateId.HasValue)
                                        {
                                            var state = await _db.Locations
                                                .FirstOrDefaultAsync(x => x.Id == stateId);

                                            if (state != null)
                                            {
                                                // Country
                                                countryId = state.ParentId;
                                            }
                                        }
                                    }
                                }
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

                    BlockId = blockId,
                    DistrictId = districtId,
                    StateId = stateId,
                    CountryId = countryId
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








        public async Task<object> DeleteProgram(int id, bool permanentDelete = false)
        {
            try
            {
                var program = await _db.Programs
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (program == null)
                {
                    return new
                    {
                        Success = false,
                        Message = "Program not found"
                    };
                }

                if (permanentDelete)
                {
                    _db.Programs.Remove(program);
                }
                else
                {
                    program.IsDelete = 1;
                    program.IsActive = 0;
                }

                await _db.SaveChangesAsync();

                return new
                {
                    Success = true,
                    Message = permanentDelete
                        ? "Program permanently deleted successfully"
                        : "Program soft deleted successfully"
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
        

    }
}
