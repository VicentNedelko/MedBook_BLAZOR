using AutoMapper;
using DAL.Data;
using MedBook.Requests;
using MediatR;

namespace MedBook.Handlers
{
    public class AddSampleIndicatorHandler(ApplicationDbContext context, IMapper mapper) : IRequestHandler<AddSampleIndicatorRequest, AddSampleIndicatorRequest.Response>
    {
        private readonly ApplicationDbContext context = context;
        private readonly IMapper mapper = mapper;

        public async Task<AddSampleIndicatorRequest.Response> Handle(AddSampleIndicatorRequest request, CancellationToken cancellationToken)
        {
            var isExists = context?.SampleIndicators.FirstOrDefault(x => x.Name.ToUpper() == request.SampleIndicatorDto.Name.ToUpper());
            if (isExists is null)
            {
                var bearingIndicator = context!.BearingIndicators.FirstOrDefault(x => x.Id == request.SampleIndicatorDto.BearingIndicatorId);
                var sampleIndicator = CreateIndicator(request, bearingIndicator);
                sampleIndicator.BearingIndicator = bearingIndicator!;
                context?.Add(sampleIndicator);

                try
                {
                    var status = await context?.SaveChangesAsync();
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

            return sampleIndicator;
        }
    }
}
