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
        #endregion

        #region Views
        #endregion

        void Commit();
    }
}
