using HostBooks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostBooks.Repos.Interfaces
{
    public interface IUsers
    {
        IEnumerable<Users> GetTopSalaries(int count);
        IEnumerable<Users> GetAll();
        IEnumerable<Users> GetAllBySP();
    }
}
