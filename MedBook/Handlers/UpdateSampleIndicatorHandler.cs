using DAL.Data;
using MedBook.Requests;
using MediatR;

namespace MedBook.Handlers
{
    public class UpdateSampleIndicatorHandler(ApplicationDbContext dbContext) : IRequestHandler<UpdateSampleIndicatorRequest, UpdateSampleIndicatorRequest.Response>
    {
        private readonly ApplicationDbContext dbContext = dbContext;
        public async Task<UpdateSampleIndicatorRequest.Response> Handle(UpdateSampleIndicatorRequest request, CancellationToken cancellationToken)
        {
            var sampleIndicator = dbContext.SampleIndicators.SingleOrDefault(x => x.Id == request.SampleIndicatorDto.Id) ??
                throw new ArgumentException($"Sample indicator {request.SampleIndicatorDto.Name} {request.SampleIndicatorDto.Id} is not found in DB.");

            try
            {
                if (request.SampleIndicatorDto.BearingIndicatorId != sampleIndicator.BearingIndicatorId)
                {
                    var newBearing = dbContext.BearingIndicators.SingleOrDefault(x => x.Id == request.SampleIndicatorDto.BearingIndicatorId) ??
                        throw new ArgumentException($"New Bearing indicator {request.SampleIndicatorDto.BearingIndicatorId} is not found in DB while updating Sample indicator.");

                    sampleIndicator.BearingIndicatorId = newBearing.Id;
                    sampleIndicator.BearingIndicator = newBearing;
                    sampleIndicator.ReferenceMax = newBearing.ReferenceMax;
                    sampleIndicator.ReferenceMin = newBearing.ReferenceMin;
                    sampleIndicator.Unit = newBearing.Unit;
                    sampleIndicator.Type = newBearing.Type;
                }

                sampleIndicator.Name = request.SampleIndicatorDto.Name;

                var status = await dbContext.SaveChangesAsync(cancellationToken);

                return new UpdateSampleIndicatorRequest.Response(status);
            }
            catch
            {
                throw;
            }
        }
    }
}
