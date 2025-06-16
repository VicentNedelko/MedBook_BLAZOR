using Business.DTO;
using MediatR;

namespace MedBook.Requests
{
    public record AddSampleIndicatorRequest(SampleIndicatorDto SampleIndicatorDto) : IRequest<AddSampleIndicatorRequest.Response>
    {
        public record Response(int Status);
    }
}
