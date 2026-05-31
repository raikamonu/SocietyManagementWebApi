using Application.DTOs;
using Data;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace Application.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly MissionEducationDbContext _db;
        public LocationRepository(MissionEducationDbContext db)
        {
            _db = db;
        }

        public async Task<object> CreateLocation(LocationDTO input)
        {
            try
            {
                var location = new Location
                {
                    Name = input.Name,
                    Code = input.Code,
                    ParentId = input.ParentId,
                    TypeId = input.TypeId,
                    IsActive = input.IsActive
                };
                _db.Locations.Add(location);
                await _db.SaveChangesAsync();
                return new { Success = true, Message = "Location created successfully", Data = location };
            }

            catch (Exception ex)
            {
                return new
                {
                    Success = false,
                    Message = ex.Message,
                    InnerException = ex.InnerException?.Message
                };
            }
            //catch (Exception ex)
            //{
            //    return new { Success = false, Message = $"Error creating location: {ex.Message}" };
            //}
        }



        public async Task<List<LocationDTO>> GetAllLocation()
        {
            var locations = await _db.Locations
                .Include(l => l.Parent)
                .Include(l => l.Type)
                .Select(l => new LocationDTO
                {
                    Id = l.Id,
                    Name = l.Name,
                    Code = l.Code,
                    ParentId = l.ParentId,
                    ParentName = l.Parent != null ? l.Parent.Name : null,
                    TypeId = l.TypeId,
                    TypeName = l.Type != null ? l.Type.Name : null,
                    IsActive = l.IsActive
                })
                .ToListAsync();
            return locations;
        }




        public async Task<object> GetLocationById(int id)
        {
            var location = await _db.Locations
                .Include(l => l.Parent)
                .Include(l => l.Type)
                .Where(l => l.Id == id)
                .Select(l => new LocationDTO
                {
                    Id = l.Id,
                    Name = l.Name,
                    Code = l.Code,
                    ParentId = l.ParentId,
                    ParentName = l.Parent != null ? l.Parent.Name : null,
                    TypeId = l.TypeId,
                    TypeName = l.Type != null ? l.Type.Name : null,
                    IsActive = l.IsActive
                })
                .FirstOrDefaultAsync();
            if (location == null)
            {
                return new { Success = false, Message = "Location not found" };
            }
            return new { Success = true, Data = location };
        }




        public async Task<object> UpdateLocation(LocationDTO input)
        {
            try
            {
                var location = await _db.Locations.FindAsync(input.Id);
                if (location == null)
                {
                    return new { Success = false, Message = "Location not found" };
                }
                location.Name = input.Name;
                location.Code = input.Code;
                location.ParentId = input.ParentId;
                location.TypeId = input.TypeId;
                location.IsActive = input.IsActive;
                await _db.SaveChangesAsync();
                return new { Success = true, Message = "Location updated successfully", Data = location };
            }
            catch (Exception ex)
            {
                return new { Success = false, Message = $"Error updating location: {ex.Message}" };
            }
        }




        public async Task<object> DeleteLocation(int id)
        {
            try
            {
                var location = await _db.Locations.FindAsync(id);
                if (location == null)
                {
                    return new { Success = false, Message = "Location not found" };
                }
                _db.Locations.Remove(location);
                await _db.SaveChangesAsync();
                return new { Success = true, Message = "Location deleted successfully" };
            }
            catch (Exception ex)
            {
                return new { Success = false, Message = $"Error deleting location: {ex.Message}" };
            }
        }







        public async Task<List<LocationDTO>> GetParentLocations()
        {
            var data = await _db.Locations
                .Where(x => x.IsActive == 1)
                .Select(x => new LocationDTO
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            return data;
        }












    }
}
