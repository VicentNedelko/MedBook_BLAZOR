using Business.DTO;
using MediatR;

namespace MedBook.Requests
{
    public record UpdateSampleIndicatorRequest(SampleIndicatorDto SampleIndicatorDto) : IRequest<UpdateSampleIndicatorRequest.Response>
    {
        public record Response(int Status);
    }
}
