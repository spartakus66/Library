using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;

namespace Library.ViewModel
{
    public class UsersViewModel
    {
        public List<Admin> Admins;
        public List<Employee> Employees;
        public List<Reader> Readers;
    }
}