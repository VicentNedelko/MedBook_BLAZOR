using DAL.Data;
using MedBook.Requests;
using MediatR;
using Serilog;

namespace MedBook.Handlers
{
    public class UpdateBearingIndicatorHandler(ApplicationDbContext dbContext) : IRequestHandler<UpdateBearingIndicatorRequest, UpdateBearingIndicatorRequest.Response>
    {
        private readonly ApplicationDbContext dbContext = dbContext;
        public async Task<UpdateBearingIndicatorRequest.Response> Handle(UpdateBearingIndicatorRequest request, CancellationToken cancellationToken)
        {
            var indicator = dbContext.BearingIndicators.SingleOrDefault(x => x.Id == request.BearingIndicatorDto.Id)
                ?? throw new ArgumentException($"Bearing indicator {request.BearingIndicatorDto.Name} {request.BearingIndicatorDto.Id} is not found in DB.");
            
            try
            {
                indicator.Name = request.BearingIndicatorDto.Name;
                indicator.ReferenceMin = request.BearingIndicatorDto.ReferenceMin;
                indicator.ReferenceMax = request.BearingIndicatorDto.ReferenceMax;
                indicator.Unit = request.BearingIndicatorDto.Unit;
                indicator.Type = request.BearingIndicatorDto.Type;
                indicator.Description = request.BearingIndicatorDto.Description;

                var status = await dbContext!.SaveChangesAsync(cancellationToken);

                Log.Information($"{indicator.Name} updated successfully.");

                return new UpdateBearingIndicatorRequest.Response(status);
            }
            catch (Exception e)
            {
                Log.Error($"Error updating {indicator.Name} - {e.Message}.");
                throw;
            }
        }
    }
}
