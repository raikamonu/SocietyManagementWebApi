using Application.Repositories;

namespace Application.Helper
{
    public interface IUnitOfWork
    {
        IMasterTypeRepository MasterType { get; }

        IMasterTypeDetailRepository MasterTypeDetail { get; }

        IDropdownRepository Dropdown { get; }
    }
}
