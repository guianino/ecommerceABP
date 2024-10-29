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

        private Costumer()
        {

        }

        internal Costumer(Guid id, string name, DateTime birthDate, string document ) : base(id)
        {
            SetName(name);
            BirthDate = birthDate;
            Document = document;
        }

        public void SetName (string name)
        {
            Name = name;
        }
        
        
    }
}