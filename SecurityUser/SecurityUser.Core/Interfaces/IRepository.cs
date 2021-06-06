using SecurityUser.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecurityUser.Core.Interfaces
{
    public interface IRepository <T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add();
        Task<T> Update();
        Task<T> Delete();


    }
}
