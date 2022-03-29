using System.Collections.Generic;
using System.Linq;
using Domain;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Microsoft.Extensions.Logging;
using System;

namespace Application.Activities
{
    public class List 
    {
       
       public class Query : IRequest<List<Activity>> {}

       public class Handler : IRequestHandler<Query, List<Activity>>
       {
           private readonly DataContext _context;

           private readonly ILogger<List> _logger;
           public Handler(DataContext context)
           {
               _context = context;
           }
           public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
           {
          
               return await _context.Activities.ToListAsync();
           }
       }
    }  
}
