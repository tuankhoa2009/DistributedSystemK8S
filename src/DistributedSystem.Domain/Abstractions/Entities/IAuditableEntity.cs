﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedSystem.Domain.Abstractions.Entities
{
    public interface IAuditableEntity
    {
        DateTimeOffset CreatedOnUtc { get; set; }

        DateTimeOffset? ModifiedOnUtc { get; set; }

    }
}
