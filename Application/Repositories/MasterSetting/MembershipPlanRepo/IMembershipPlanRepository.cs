using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IMembershipPlanRepository
    {


        Task<object> CreateMembershipPlan(MembershipPlanDTO input);
        Task<object> UpdateMembershipPlan(MembershipPlanDTO input);
        Task<object> GetMembershipPlanById(int id);
        Task<List<MembershipPlanDTO>> GetAllMembershipPlan();
        Task<object> DeleteMembershipPlan(int id);



    }
}
