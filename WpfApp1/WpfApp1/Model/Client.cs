using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }  
        public string Name { get; set; }         
        public string Inn { get; set; }          
        public string Address { get; set; }     
        public string Phone { get; set; }        
        public bool IsSalesman { get; set; }     
        public bool IsBuyer { get; set; }        
    }
}
