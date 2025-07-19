using DAL.Data;
using MedBook.Requests;
using MediatR;
using Serilog;

namespace MedBook.Handlers
{
    public class DeleteSampleIndicatorHandler(ApplicationDbContext dbContext) : IRequestHandler<DeleteSampleIndicatorRequest, DeleteSampleIndicatorRequest.Response>
    {
        public ApplicationDbContext dbContext = dbContext;
        public async Task<DeleteSampleIndicatorRequest.Response> Handle(DeleteSampleIndicatorRequest request, CancellationToken cancellationToken)
        {
            var sampleIndicator = dbContext.SampleIndicators.SingleOrDefault(x => x.Id == request.SampleIndicatorDto.Id) ??
                throw new ArgumentException($"Sample indicator {request.SampleIndicatorDto.Name} {request.SampleIndicatorDto.Id} is not found in DB.");

            try
            {
                dbContext.Remove(sampleIndicator);
                var status = await dbContext.SaveChangesAsync(cancellationToken);
                Log.Information($"Sample indicator {sampleIndicator.Name} deleted successfully.");

                return new DeleteSampleIndicatorRequest.Response(status);
            }
            catch (Exception e)
            {
                Log.Error($"Error deleting sample indicator {sampleIndicator.Name} - {e.Message}");
                throw;
            }
        }
    }
}
