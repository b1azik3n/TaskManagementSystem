using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Client:BaseClass
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber {  get; set; }
        public string EmailAddress { get; set; }    
        public long ? VAT {  get; set; }
        public long PAN { get; set; }
 

        //Client < Project
        public ICollection<Project> Projects { get; set; }

    }
}
