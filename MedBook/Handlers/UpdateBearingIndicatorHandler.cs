using DAL.Data;
using MedBook.Requests;
using MediatR;

namespace MedBook.Handlers
{
    public class UpdateBearingIndicatorHandler(ApplicationDbContext context) : IRequestHandler<UpdateBearingIndicatorRequest, UpdateBearingIndicatorRequest.Response>
    {
        private readonly ApplicationDbContext context = context;
        public async Task<UpdateBearingIndicatorRequest.Response> Handle(UpdateBearingIndicatorRequest request, CancellationToken cancellationToken)
        {
            var indicator = context.BearingIndicators.SingleOrDefault(x => x.Id == request.BearingIndicatorDto.Id)
                ?? throw new ArgumentException($"Bearing indicator {request.BearingIndicatorDto.Name} {request.BearingIndicatorDto.Id} is not found in DB.");
            
            try
            {
                indicator.Name = request.BearingIndicatorDto.Name;
                indicator.ReferenceMin = request.BearingIndicatorDto.ReferenceMin;
                indicator.ReferenceMax = request.BearingIndicatorDto.ReferenceMax;
                indicator.Unit = request.BearingIndicatorDto.Unit;
                indicator.Type = request.BearingIndicatorDto.Type;

                var status = await context!.SaveChangesAsync(cancellationToken);

                return new UpdateBearingIndicatorRequest.Response(status);
            }
            catch
            {
                throw;
            }
        }
    }
}
