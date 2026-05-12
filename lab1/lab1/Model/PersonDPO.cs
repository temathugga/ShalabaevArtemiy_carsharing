using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using lab1.ViewModel;

namespace lab1.Model
{
    public class PersonDPO : INotifyPropertyChanged
    {
        private int _id;
        private string _role;
        private string _firstName;
        private string _lastName;
        private DateTime _birthday;

        /// <summary>
        /// код сотрудника
        /// </summary>
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        /// <summary>
        /// должность сотрудника
        /// </summary>
        public string Role
        {
            get => _role;
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }

        /// <summary>
        /// имя сотрудника
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        /// <summary>
        /// фамилия сотрудника
        /// </summary>
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        /// <summary>
        /// дата рождения сотрудника
        /// </summary>
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                OnPropertyChanged(nameof(Birthday));
            }
        }

        public PersonDPO() { }

        public PersonDPO(int id, string role, string firstName, string lastName, DateTime birthday)
        {
            this.Id = id;
            this.Role = role;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
        }

        /// <summary>
        /// Метод поверхностного копирования
        /// </summary>
        /// <returns></returns>
        public PersonDPO ShallowCopy()
        {
            return (PersonDPO)this.MemberwiseClone();
        }

        /// <summary>
        /// копирование данных из класса Person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public PersonDPO CopyFromPerson(Person person)
        {
            PersonDPO perDPO = new PersonDPO();
            RoleViewModel vmRole = new RoleViewModel();
            string role = string.Empty;

            foreach (var r in vmRole.ListRole)
            {
                if (r.Id == person.RoleId)
                {
                    role = r.NameRole;
                    break;
                }
            }

            if (role != string.Empty)
            {
                perDPO.Id = person.Id;
                perDPO.Role = role;
                perDPO.FirstName = person.FirstName;
                perDPO.LastName = person.LastName;
                perDPO.Birthday = person.Birthday;
            }
            return perDPO;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}