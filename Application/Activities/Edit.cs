using System.Threading;
using System.Threading.Tasks;
//we bring in domain to be able to use the activity from details
using Domain;
using MediatR;
using AutoMapper;
using Persistence;
using Application.Activities;


namespace Application.Activites
{
    public class Edit 
    {

      public class Command : IRequest
      {
          public Activity Activity { get; set; }
      }  
    public class Handler : IRequestHandler<Command>
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;
        public Handler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await _context.Activities.FindAsync(request.Activity.Id);
            
            //this sets the props manually
          //  activity.Title = request.Activity.Title ?? activity.Title;

             //****** AUTOMAPPER
             _mapper.Map(request.Activity, activity);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
     }
  }
}