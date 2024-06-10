using Microsoft.EntityFrameworkCore;
using RentACar_DataAccessLayer.Context;
using RentACar_ModelsLayer.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_DataAccessLayer.Repository
{
    public class CustomerRepository
    {
        public Customer GetLogIn(string uName, string pass)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var cust = cnt.Customers.SingleOrDefault(x => x.CustomerUserName == uName && x.CustomerPassword == pass);
                return cust;
            }
        }
        public Customer AddCustomer(Customer customer)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var cus = cnt.Customers.Add(customer);
                cnt.SaveChanges();
                return cus.Entity;
            }
        }
        public List<Customer> GetAllCustomers(params string[] includeList)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                IQueryable<Customer> dbSet = cnt.Customers;

                if (includeList != null && includeList.Length > 0)
                {
                    for (int i = 0; i < includeList.Length; i++)
                    {
                        dbSet = dbSet.Include(includeList[i]);
                    }
                }
                var list = dbSet.ToList();
                return list;
            }
        }
        public Customer GetCustomerByUsername(string username)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var customer = cnt.Customers.FirstOrDefault(x => x.CustomerUserName == username);
                return customer;
            }
        }

        public Customer GetById(int id)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var cust = cnt.Customers.SingleOrDefault(x => x.CustomerID == id);
                return cust;
            }

        }
        public void Delete(int id)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var cust = GetById(id);
                cnt.Customers.Remove(cust);
                cnt.SaveChanges();
            }
        }

        public Customer Update(Customer customer)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var cust = cnt.Customers.Update(customer);
                cnt.SaveChanges();
                return cust.Entity;
            }

        }
    }
}
