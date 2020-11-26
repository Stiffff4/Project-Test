using System.Collections.Generic;
using DataAccesss.Models;

namespace DataAccesss.Interfaces
{
    public interface ICategories
    {
        public List<Categories> Retrieve();
        public void Create(Categories category);
        public void Update(Categories category);
        public void Delete(Categories category);
    }
}