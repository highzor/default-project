using AgrotechFillHingers.Backend.Models.User;
using AgrotechFillHingers.Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        #region Tables
            RepositoryBase<UserModel> UserRepository { get; }
            RepositoryBase<Acts> ActsRepository { get; }
            RepositoryBase<Curators> CuratorsRepository { get; }
            RepositoryBase<Group_addresses> GroupAddressesRepository { get; }
            RepositoryBase<Groups> GroupsRepository { get; }
            RepositoryBase<Partners> PartnersRepository { get; }
            RepositoryBase<Shedules> ShedulesRepository { get; }
            RepositoryBase<Task_docks> TaskDocksRepository { get; }
            RepositoryBase<Task_status_history> TaskStatusHistoryRepository{get;}
            RepositoryBase<Tasks> TasksRepository { get; }
            RepositoryBase<Users> UsersRepository { get; }
            RepositoryBase<Volunteers> VolunteersRepository { get; }

        #endregion

        #region Views
        #endregion

        void Commit();
    }
}
