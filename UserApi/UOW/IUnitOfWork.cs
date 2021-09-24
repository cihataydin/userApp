using UserApi.Data;
using UserApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApi.UOW
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}