using Application.Repositories;
//using Application.Repositories.MasterSetting.DropdownRepo;

namespace Application.Helper
{
    public interface IUnitOfWork
    {
        IMasterTypeRepository MasterType { get; }

        IMasterTypeDetailRepository MasterTypeDetail { get; }

        IDropdownRepository Dropdown { get; }
    }
}
