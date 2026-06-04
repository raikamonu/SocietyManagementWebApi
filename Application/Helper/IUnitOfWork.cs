using Application.Repositories;

namespace Application.Helper
{
    public interface IUnitOfWork
    {
        IMasterTypeRepository MasterType { get; }

        IMasterTypeDetailRepository MasterTypeDetail { get; }

        IDropdownRepository Dropdown { get; }

        ILocationRepository Location { get; }
        ISessionRepository Session { get; }
        IProgramRepository Program { get; }
        IMembershipPlanRepository MembershipPlan { get; }
        IPrizeMasterRepository PrizeMaster { get; }

    }
}
