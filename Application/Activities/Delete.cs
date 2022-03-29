using System;
using System.Threading;
using System.Threading.Tasks;
//we bring in domain to be able to use the activity from details
using Domain;
using MediatR;
using AutoMapper;
using Persistence;
using Application.Activities;
using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace Application.Activites
{
    public class Delete
    {
       public class Command : IRequest
       {
           public Guid Id { get; set;}
       }

       public class Handler : IRequestHandler<Command>
       {
           private readonly DataContext _context;
           public Handler(DataContext context)
           {
               _context = context;
           }
           public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
           {
              var activity = await _context.Activities.FindAsync(request.Id);

              _context.Remove(activity);

              await _context.SaveChangesAsync();

              return Unit.Value;
           }
       }
    }
}