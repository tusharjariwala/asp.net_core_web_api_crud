using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Infrastructure.Domain.Entites
{
    public class Employee: Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string CvFile { get; set; }
        public long CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public Employee() { }
        public Employee(string name, DateTime birthDate, string email, string password, string address, string cvFile, long companyId)
        {
         
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Password = password;
            Address = address;
            CvFile = cvFile;
            CompanyId = companyId;
            createdOn = DateTime.UtcNow;
            IsDeleted= false;
        }
        public Employee Delete()
        {
            updatedOn = DateTime.UtcNow;
            IsDeleted= true;
            return this;
        }
    }
}
