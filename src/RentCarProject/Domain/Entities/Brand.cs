using Core.Persistence.Repositories;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Brand : Entity
    {
        public string Name { get; set; }
        public  ICollection<Model> Models { get; set; }
        public Brand() {}
        public Brand(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
