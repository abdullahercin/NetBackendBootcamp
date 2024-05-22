using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp.Domain.Categories;

namespace Bootcamp.Service.Categories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<bool> IsExistName(string name);
    }
}
