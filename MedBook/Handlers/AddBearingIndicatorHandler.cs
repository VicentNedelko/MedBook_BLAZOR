using AutoMapper;
using DAL.Data;
using MedBook.Requests;
using MediatR;

namespace MedBook.Handlers
{
    public class AddBearingIndicatorHandler(ApplicationDbContext context, IMapper mapper) : IRequestHandler<AddBearingIndicatorRequest, AddBearingIndicatorRequest.Response>
    {
        private readonly ApplicationDbContext context = context;

        private readonly IMapper mapper = mapper;

        public async Task<AddBearingIndicatorRequest.Response> Handle(AddBearingIndicatorRequest request, CancellationToken cancellationToken)
        {
            var isExists = context?.BearingIndicators.FirstOrDefault(x => x.Name.ToUpper() == request.BearingIndicatorDto.Name.ToUpper());
            if (isExists is null)
            {
                var indicator = CreateIndicator(request);
                context?.Add(indicator);

                try
                {
                    var status = await context?.SaveChangesAsync();
                    return new AddBearingIndicatorRequest.Response(status);
                }
                catch
                {
                    throw;
                }
            }

            return new AddBearingIndicatorRequest.Response(-1);
        }

        private BearingIndicator CreateIndicator(AddBearingIndicatorRequest request)
            => mapper.Map<BearingIndicator>(request.BearingIndicatorDto);
    }
}
