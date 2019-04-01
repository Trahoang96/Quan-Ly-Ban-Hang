using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using DTO;

namespace BUS
{
    public class SupplierBUS
    {
        SupplierDAO supDAO = new SupplierDAO();

        public List<Supplier> LoadSupplier()
        {
            return supDAO.LoadSupplier();
        }

        public int Add(Supplier s)
        {
            return supDAO.Add(s);
        }

        public int Delete(string id)
        {
            return supDAO.Delete(id);
        }

        public int Update(Supplier s)
        {
            return supDAO.Update(s);
        }
    }
}
