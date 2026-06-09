using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface ILocationRepository
    {
        Task<object> CreateLocation(LocationDTO input);

        Task<List<LocationDTO>> GetAllLocation();

        Task<object> GetLocationById(int id);

        Task<object> UpdateLocation(LocationDTO input);
        Task<object> DeleteLocation(int id, bool permanentDelete = false);
        Task<List<LocationDTO>> GetParentLocations();

    }
}
