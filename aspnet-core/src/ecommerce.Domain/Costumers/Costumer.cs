using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ecommerce.Costumers
{
    public class Costumer :FullAuditedAggregateRoot<Guid>
    {   
        public string Name { get; private set; }
        public DateTime BirthDate { get; set; }
        public string Document { get; set; }
        public string FileDocument { get; set; }

        private Costumer()
        {

        }

        internal Costumer(Guid id, string name, DateTime birthDate, string document, string fileDocument ) : base(id)
        {
            SetName(name);
            BirthDate = birthDate;
            Document = document;
            FileDocument = fileDocument;
        }

        public void SetName (string name)
        {
            Name = name;
        }
        
        
    }
}