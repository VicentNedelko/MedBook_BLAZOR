using Business.DTO;
using MediatR;

namespace MedBook.Requests
{
    public record DeleteSampleIndicatorRequest(SampleIndicatorDto SampleIndicatorDto) : IRequest<DeleteSampleIndicatorRequest.Response>
    {
        public record Response(int Status);
    }
}