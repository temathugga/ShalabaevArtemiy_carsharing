using lab1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab1.ViewModel
{
    public class RoleViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// выбранная в списке должность
        /// </summary>
        private Role _selectedRole;

        /// <summary>
        /// выбранная в списке должность
        /// </summary>
        public Role SelectedRole
        {
            get
            {
                return _selectedRole;
            }
            set
            {
                _selectedRole = value;
                OnPropertyChanged(nameof(SelectedRole));
                EditRole.CanExecute(true);
            }
        }

        /// <summary>
        /// коллекция должностей сотрудников
        /// </summary>
        public ObservableCollection<Role> ListRole { get; set; } = new ObservableCollection<Role>();

        public RoleViewModel()
        {
            ListRole.Add(new Role
            {
                Id = 1,
                NameRole = "Директор"
            });
            ListRole.Add(new Role
            {
                Id = 2,
                NameRole = "Бухгалтер"
            });
            ListRole.Add(new Role
            {
                Id = 3,
                NameRole = "Менеджер"
            });
        }

        /// <summary>
        /// Нахождение максимального Id в коллекции
        /// </summary>
        /// <returns></returns>
        public int MaxId()
        {
            int max = 0;
            foreach (var r in ListRole)
            {
                if (max < r.Id)
                {
                    max = r.Id;
                }
            }
            return max;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}