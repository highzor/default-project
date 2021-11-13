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

namespace AgrotechFillHingers.Backend.Helpers
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;

        #region Tables 
        private RepositoryBase<UserModel> _userRepository;
        private RepositoryBase<ScheduleModel> _scheduleRepository;
        private RepositoryBase<ScheduleStatusModel> _scheduleStatusRepository;


        public RepositoryBase<UserModel> UserRepository { get { return _userRepository ??= new RepositoryBase<UserModel>(_transaction);  } }
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
