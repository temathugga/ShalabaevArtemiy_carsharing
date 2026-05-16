using System;

namespace lab1.Model
{
    public class Role
    {
        public int Id { get; set; }
        public string NameRole { get; set; }

        public Role() { }

        public Role(int id, string nameRole)
        {
            Id = id;
            NameRole = nameRole;
        }

        public Role ShallowCopy()
        {
            return (Role)this.MemberwiseClone();
        }
    }
}
