using AutoMapper;
using DAL.Data;
using MedBook.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MedBook.Handlers
{
    public class AddSampleIndicatorHandler(ApplicationDbContext context, IMapper mapper) : IRequestHandler<AddSampleIndicatorRequest, AddSampleIndicatorRequest.Response>
    {
        private readonly ApplicationDbContext context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly IMapper mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<AddSampleIndicatorRequest.Response> Handle(AddSampleIndicatorRequest request, CancellationToken cancellationToken)
        {
            if (context == null)
            {
                throw new InvalidOperationException("Database context is not initialized.");
            }

            var isExists = await context.SampleIndicators.AsNoTracking().FirstOrDefaultAsync(x => x.Name.ToUpper() == request.SampleIndicatorDto.Name.ToUpper());
            if (isExists is null)
            {
                var bearingIndicator = await context.BearingIndicators.FirstOrDefaultAsync(x => x.Id == request.SampleIndicatorDto.BearingIndicatorId);
                if (bearingIndicator is not null)
                {
                    var sampleIndicator = CreateIndicator(request, bearingIndicator);
                    sampleIndicator.BearingIndicator = bearingIndicator;
                    context.Add(sampleIndicator);
                }

                try
                {
                    var status = await context.SaveChangesAsync(cancellationToken);
                    return new AddSampleIndicatorRequest.Response(status);
                }
                catch
                {
                    throw;
                }
            }

            return new AddSampleIndicatorRequest.Response(-1);
        }

        private SampleIndicator CreateIndicator(AddSampleIndicatorRequest request, BearingIndicator bearingIndicator)
        {
            var sampleIndicator = mapper.Map<SampleIndicator>(request.SampleIndicatorDto);
            sampleIndicator.ReferenceMax = bearingIndicator.ReferenceMax;
            sampleIndicator.ReferenceMin = bearingIndicator.ReferenceMin;
            sampleIndicator.Unit = bearingIndicator.Unit;
            sampleIndicator.Type = bearingIndicator.Type;

            return sampleIndicator;
        }
    }
}
