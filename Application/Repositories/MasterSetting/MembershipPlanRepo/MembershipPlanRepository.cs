

using Application.DTOs;
using Data;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public class MembershipPlanRepository : IMembershipPlanRepository
    {
        private readonly MissionEducationDbContext _db;
        public MembershipPlanRepository(MissionEducationDbContext db)
        {
            _db = db;
        }


        public async Task<object> CreateMembershipPlan(MembershipPlanDTO input)
        {
            try
            {
                var membershipPlan = new MembershipPlan
                {
                    Name = input.Name,
                    Amount = input.Amount,
                    ValidityMonth = input.ValidityMonth,
                    IsRenewal = input.IsRenewal ?? 0,
                    IsActive = input.IsActive ?? 1,
                    IsDelete = 0
                };

                await _db.MembershipPlans.AddAsync(membershipPlan);
                await _db.SaveChangesAsync();

                return new
                {
                    Success = true,
                    Message = "Membership Plan Created Successfully"
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

        public async Task<List<MembershipPlanDTO>> GetAllMembershipPlan()
        {
            return await _db.MembershipPlans
                .Where(x => x.IsDelete == 0)
                .Select(x => new MembershipPlanDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Amount = x.Amount,
                    ValidityMonth = x.ValidityMonth,
                    IsRenewal = x.IsRenewal,
                    IsActive = x.IsActive
                })
                .ToListAsync();
        }

        public async Task<object> GetMembershipPlanById(int id)
        {
            var data = await _db.MembershipPlans
                .Where(x => x.Id == id && x.IsDelete == 0)
                .Select(x => new MembershipPlanDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Amount = x.Amount,
                    ValidityMonth = x.ValidityMonth,
                    IsRenewal = x.IsRenewal,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync();

            if (data == null)
            {
                return new
                {
                    Success = false,
                    Message = "Membership Plan Not Found"
                };
            }

            return new
            {
                Success = true,
                Data = data
            };
        }

        public async Task<object> UpdateMembershipPlan(MembershipPlanDTO input)
        {
            try
            {
                var existingPlan = await _db.MembershipPlans
                    .FirstOrDefaultAsync(x => x.Id == input.Id);

                if (existingPlan == null)
                {
                    return new
                    {
                        Success = false,
                        Message = "Membership Plan Not Found"
                    };
                }

                existingPlan.Name = input.Name;
                existingPlan.Amount = input.Amount;
                existingPlan.ValidityMonth = input.ValidityMonth;
                existingPlan.IsRenewal = input.IsRenewal ?? 0;
                existingPlan.IsActive = input.IsActive ?? 1;

                await _db.SaveChangesAsync();

                return new
                {
                    Success = true,
                    Message = "Membership Plan Updated Successfully"
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
        public async Task<object> DeleteMembershipPlan(int id)
        {
            var data = await _db.MembershipPlans
                .FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
            {
                return new
                {
                    Success = false,
                    Message = "Membership Plan Not Found"
                };
            }

            data.IsDelete = 1;
            data.IsActive = 0;

            await _db.SaveChangesAsync();

            return new
            {
                Success = true,
                Message = "Membership Plan Deleted Successfully"
            };
        }



        public async Task<object> DeleteMembershipPlan(int id, bool permanentDelete = false)
        {
            var plan = await _db.MembershipPlans.FindAsync(id);

            if (plan == null)
            {
                return new
                {
                    Success = false,
                    Message = "Plan not found"
                };
            }

            if (permanentDelete)
            {
                _db.MembershipPlans.Remove(plan); // Hard Delete
            }
            else
            {
                plan.IsDelete = 1; // Soft Delete
            }

            await _db.SaveChangesAsync();

            return new
            {
                Success = true,
                Message = permanentDelete
                    ? "Plan permanently deleted"
                    : "Plan soft deleted"
            };
        }









    }
}
