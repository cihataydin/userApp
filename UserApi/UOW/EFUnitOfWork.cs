using UserApi.Data;
using UserApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UserApi.UOW
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly UserDBContext _dbContext;
        public EFUnitOfWork(UserDBContext dbContext)
        {

            if (dbContext == null)
                throw new Exception("db context null");

            _dbContext = dbContext;

        }

        public async Task Dispose()
        {
            try
            {
                await _dbContext.DisposeAsync();
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}