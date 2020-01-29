using HostBooks.Data.Models;
using HostBooks.Repos.Interfaces;
using HostBooks.Repos.UnitOfWorkInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostBooks.Repos.Services
{
    public class UsersService : IUsers
    {
        private readonly UnitOfWork _unitOfWork;

        public UsersService(IUnitOfWork _uow)
        {
            this._unitOfWork = _uow as UnitOfWork;
        }
        public IEnumerable<Users> GetAll()
        {
            return  _unitOfWork.Repository<Users>().GetAll();
        }

        public IEnumerable<Users> GetAllBySP()
        {
            string query = "exec usp_getAllUsers";
            return _unitOfWork.Repository<Users>().ExecuteWithStoreProcedure(query);
        }

        public IEnumerable<Users> GetTopSalaries(int count)
        {
            throw new NotImplementedException();
        }
    }
}
