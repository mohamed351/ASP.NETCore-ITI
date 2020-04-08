
using Microsoft.AspNetCore.Http;

namespace FirstApplication.Models
{
    public class Employees
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public decimal  Salary { get; set; }

        public IFormFile myfile {get; set;}
    }
}