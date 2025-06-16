using Business.DTO;
using MediatR;

namespace MedBook.Requests
{
    public record AddBearingIndicatorRequest(BearingIndicatorDto BearingIndicatorDto) : IRequest<AddBearingIndicatorRequest.Response>
    {
        public record Response(int Status);
    }
}
