using AgrotechFillHingers.Backend.Interfaces;
using AgrotechFillHingers.Backend.Models.User;
using AgrotechFillHingers.Backend.Repositories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AgrotechFillHingers.Backend.Helpers
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;

        #region Tables 
        private RepositoryBase<UserModel> _userRepository;
        private RepositoryBase<Acts> _actsRepository;
        private RepositoryBase<Curators> _curatorsRepository;
        private RepositoryBase<Group_addresses> _groupAddressesRepository;
        private RepositoryBase<Groups> _groupsRepository;
        private RepositoryBase<Partners> _partnersRepository;
        private RepositoryBase<Shedules> _shedulesRepository;
        private RepositoryBase<Task_docks> _taskDocksRepository;
        private RepositoryBase<Task_status_history> _taskStatusHistoryRepository;
        private RepositoryBase<Tasks> _tasksRepository;
        private RepositoryBase<Users> _usersRepository;
        private RepositoryBase<Volunteers> _volunteersRepository;
        
        public RepositoryBase<UserModel> UserRepository { get { return _userRepository ??= new RepositoryBase<UserModel>(_transaction);  } }
        public RepositoryBase<Acts> ActsRepository { get { return _actsRepository ??= new RepositoryBase<Acts>(_transaction);  } }
        public RepositoryBase<Curators> CuratorsRepository { get { return _curatorsRepository ??= new RepositoryBase<Curators>(_transaction);  } }
        public RepositoryBase<Group_addresses> GroupAddressesRepository { get { return _groupAddressesRepository ??= new RepositoryBase<Group_addresses>(_transaction);  } }
        public RepositoryBase<Groups> GroupsRepository { get { return _groupsRepository ??= new RepositoryBase<Groups>(_transaction);  } }
        public RepositoryBase<Partners> PartnersRepository { get { return _partnersRepository ??= new RepositoryBase<Partners>(_transaction);  } }
        public RepositoryBase<Shedules> ShedulesRepository { get { return _shedulesRepository ??= new RepositoryBase<Shedules>(_transaction);  } }
        public RepositoryBase<Task_docks> TaskDocksRepository { get { return _taskDocksRepository ??= new RepositoryBase<Task_docks>(_transaction);  } }
        public RepositoryBase<Task_status_history> TaskStatusHistoryRepository { get { return _taskStatusHistoryRepository ??= new RepositoryBase<Task_status_history>(_transaction);  } }
        public RepositoryBase<Tasks> TasksRepository { get { return _tasksRepository ??= new RepositoryBase<Tasks>(_transaction);  } }
        public RepositoryBase<Users> UsersRepository { get { return _usersRepository ??= new RepositoryBase<Users>(_transaction);  } }
        public RepositoryBase<Volunteers> VolunteersRepository { get { return _volunteersRepository ??= new RepositoryBase<Volunteers>(_transaction);  } }
        

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
            _actsRepository = null;
            _curatorsRepository = null;
            _groupsRepository = null;
            _partnersRepository = null;
            _shedulesRepository = null;
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
