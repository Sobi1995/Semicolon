using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
 public   interface IApplicationDbContext
    {
        DbSet<Domain.Entities.Contact> Contact { get; set; }
        DbSet<Domain.Entities.Post> Post { get; set; }
        DbSet<Domain.Entities.Tags> Tags { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
