using System.Collections.Generic;
using DataAccesss.Models;

namespace DataAccesss.Interfaces
{
    public interface IProducts
    {
        public List<Products> Retrieve();
        public void Create(Products product);
        public void Update(Products product);
        public void Delete(Products product);
    }
}