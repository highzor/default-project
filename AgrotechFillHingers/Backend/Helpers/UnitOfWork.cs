using AgrotechFillHingers.Backend.Interfaces;
using AgrotechFillHingers.Backend.Models.Schedule;
using AgrotechFillHingers.Backend.Models.ScheduleStatus;
using AgrotechFillHingers.Backend.Models.User;
using AgrotechFillHingers.Backend.Repositories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace AgrotechFillHingers.Backend.Helpers
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;

        #region Custom
        private CustomRepository _customRepository;

        public CustomRepository CustomRepository { get { return _customRepository ??= new CustomRepository(_transaction); } }

        #endregion

        #region Tables 
        private RepositoryBase<UserModel> _userRepository;
        private RepositoryBase<ActsModel> _actsRepository;
        private RepositoryBase<CuratorsModel> _curatorsRepository;
        private RepositoryBase<Group_addressesModel> _groupAddressesRepository;
        private RepositoryBase<GroupsModel> _groupsRepository;
        private RepositoryBase<PartnersModel> _partnersRepository;
        private RepositoryBase<Task_docksModel> _taskDocksRepository;
        private RepositoryBase<Task_status_historyModel> _taskStatusHistoryRepository;
        private RepositoryBase<TasksModel> _tasksRepository;
        private RepositoryBase<UsersModel> _usersRepository;
        private RepositoryBase<VolunteersModel> _volunteersRepository;
        private RepositoryBase<ScheduleModel> _scheduleRepository;
        private RepositoryBase<ScheduleStatusModel> _scheduleStatusRepository;


        public RepositoryBase<UserModel> UserRepository { get { return _userRepository ??= new RepositoryBase<UserModel>(_transaction);  } }
        public RepositoryBase<ActsModel> ActsRepository { get { return _actsRepository ??= new RepositoryBase<ActsModel>(_transaction);  } }
        public RepositoryBase<CuratorsModel> CuratorsRepository { get { return _curatorsRepository ??= new RepositoryBase<CuratorsModel>(_transaction);  } }
        public RepositoryBase<Group_addressesModel> GroupAddressesRepository { get { return _groupAddressesRepository ??= new RepositoryBase<Group_addressesModel>(_transaction);  } }
        public RepositoryBase<GroupsModel> GroupsRepository { get { return _groupsRepository ??= new RepositoryBase<GroupsModel>(_transaction);  } }
        public RepositoryBase<PartnersModel> PartnersRepository { get { return _partnersRepository ??= new RepositoryBase<PartnersModel>(_transaction);  } }
        public RepositoryBase<Task_docksModel> TaskDocksRepository { get { return _taskDocksRepository ??= new RepositoryBase<Task_docksModel>(_transaction);  } }
        public RepositoryBase<Task_status_historyModel> TaskStatusHistoryRepository { get { return _taskStatusHistoryRepository ??= new RepositoryBase<Task_status_historyModel>(_transaction);  } }
        public RepositoryBase<TasksModel> TasksRepository { get { return _tasksRepository ??= new RepositoryBase<TasksModel>(_transaction);  } }
        public RepositoryBase<UsersModel> UsersRepository { get { return _usersRepository ??= new RepositoryBase<UsersModel>(_transaction);  } }
        public RepositoryBase<VolunteersModel> VolunteersRepository { get { return _volunteersRepository ??= new RepositoryBase<VolunteersModel>(_transaction);  } }
        
        public RepositoryBase<ScheduleModel> ScheduleRepository { get { return _scheduleRepository ??= new RepositoryBase<ScheduleModel>(_transaction); } }
        public RepositoryBase<ScheduleStatusModel> ScheduleStatusRepository { get { return _scheduleStatusRepository ??= new RepositoryBase<ScheduleStatusModel>(_transaction); } }
        #endregion

        #region Views
        #endregion

        public UnitOfWork(string connectionString) {

            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        private void resetRepositories ()
        {
            _userRepository = null;
            _scheduleRepository = null;
            _scheduleStatusRepository = null;
            _actsRepository = null;
            _curatorsRepository = null;
            _groupsRepository = null;
            _partnersRepository = null;
            _tasksRepository = null;
            _volunteersRepository = null;
            _usersRepository = null;
            _groupAddressesRepository = null;
            _taskDocksRepository = null;
            _taskStatusHistoryRepository = null;
        }

        public void Commit()
        {
            try {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                resetRepositories();
            }
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        public void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
