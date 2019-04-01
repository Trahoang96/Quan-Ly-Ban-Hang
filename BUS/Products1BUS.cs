using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using DTO;

namespace BUS
{
    public class Products1BUS
    {
        Products1DAO supPro = new Products1DAO();

        public List<Products1> LoadProducts1()
        {
            return supPro.LoadProducts1();
        }

        public int Add(Products1 s)
        {
            return supPro.Add(s);
        }

        public int Delete(string id)
        {
            return supPro.Delete(id);
        }

        public int Update(Products1 s)
        {
            return supPro.Update(s);
        }
    }
}
