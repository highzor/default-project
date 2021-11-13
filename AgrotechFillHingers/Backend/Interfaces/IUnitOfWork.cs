using AgrotechFillHingers.Backend.Models.Schedule;
using AgrotechFillHingers.Backend.Models.ScheduleStatus;
using AgrotechFillHingers.Backend.Models.User;
using AgrotechFillHingers.Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgrotechFillHingers.Backend.Models.Acts;
using AgrotechFillHingers.Backend.Models.Curators;
using AgrotechFillHingers.Backend.Models.Group_addresses;
using AgrotechFillHingers.Backend.Models.Groups;
using AgrotechFillHingers.Backend.Models.Partners;
using AgrotechFillHingers.Backend.Models.Task_docks;
using AgrotechFillHingers.Backend.Models.Task_status_history;
using AgrotechFillHingers.Backend.Models.Tasks;
using AgrotechFillHingers.Backend.Models.Users;
using AgrotechFillHingers.Backend.Models.Volunteers;

namespace AgrotechFillHingers.Backend.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Tables
        RepositoryBase<UserModel> UserRepository { get; }
        RepositoryBase<ScheduleModel> ScheduleRepository { get; }
        RepositoryBase<ScheduleStatusModel> ScheduleStatusRepository { get; }

        RepositoryBase<ActsModel> ActsRepository { get; }
        RepositoryBase<CuratorsModel> CuratorsRepository { get; }
        RepositoryBase<Group_addressesModel> GroupAddressesRepository { get; }
        RepositoryBase<GroupsModel> GroupsRepository { get; }
        RepositoryBase<PartnersModel> PartnersRepository { get; }
        RepositoryBase<Task_docksModel> TaskDocksRepository { get; }
        RepositoryBase<Task_status_historyModel> TaskStatusHistoryRepository { get; }
        RepositoryBase<TasksModel> TasksRepository { get; }
        RepositoryBase<UsersModel> UsersRepository { get; }
        RepositoryBase<VolunteersModel> VolunteersRepository { get; }

        #endregion

        #region Views
        #endregion

        void Commit();
    }
}
