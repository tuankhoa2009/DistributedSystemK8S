using Query.Domain.Abstractions;
using Query.Domain.Attributes;
using Query.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Domain.Entities
{
    [BsonCollection(CollectionNames.Event)]
    public class EventProjection : Document
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }


    }
}
