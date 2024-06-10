using RentACar_DataAccessLayer.Repository;
using RentACar_ModelsLayer.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_BusinessLayer.Concreate
{
    public class CustomerBS
    {
        public Customer LogIn(string uName, string pass)
        {
            var CustomerRepo = new CustomerRepository();
            var cust = CustomerRepo.GetLogIn(uName, pass);
            return cust;
        }

        public Customer AddCustomer(Customer customer)
        {
            var repo = new CustomerRepository();
            var customers = repo.AddCustomer(customer);
            return customers;
        }
        public List<Customer> GetAll(params string[] includeList)
        {
            var repo = new CustomerRepository();
            var listCustomer = repo.GetAllCustomers(includeList);
            return listCustomer;
        }

        public bool CheckUsernameExistence(string username)
        {
            var repo = new CustomerRepository();
            var existingCustomer = repo.GetCustomerByUsername(username);
            return existingCustomer != null;
        }
        public Customer GetById(int id)
        {
            var repo = new CustomerRepository();
            var customers = repo.GetById(id);
            return customers;
        }
        public void Delete(int id)
        {
            var repo = new CustomerRepository();
            repo.Delete(id);

        }
        public Customer Update(Customer customer)
        {
            var repo = new CustomerRepository();
            var customers = repo.Update(customer);
            return customers;
        }
    }
}
