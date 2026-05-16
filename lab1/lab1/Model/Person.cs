using lab1.ViewModel;
using System;

namespace lab1.Model
{
    public class Person
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public Person() { }

        public Person(int id, int roleId, string firstName, string lastName, DateTime birthday)
        {
            Id = id;
            RoleId = roleId;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        public Person CopyFromPersonDPO(PersonDPO p)
        {
            if (p == null) return this;

            this.Id = p.Id;
            this.FirstName = p.FirstName;
            this.LastName = p.LastName;
            this.Birthday = p.Birthday;

            foreach (var r in new RoleViewModel().ListRole)
            {
                if (r.NameRole == p.Role)
                {
                    this.RoleId = r.Id;
                    break;
                }
            }
            return this;
        }
    }
}