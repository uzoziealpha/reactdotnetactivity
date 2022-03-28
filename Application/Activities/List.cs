using System.Collections.Generic;
using System.Linq;
using Domain;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Activities;
using System.Security.Policy;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;

namespace Application.Activities
{
    public class List 
    {
       
       public class Query : IRequest<List<Activity>> {}

       public class Handler : IRequestHandler<Query, List<Activity>>
       {
           private readonly DataContext _context;
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

