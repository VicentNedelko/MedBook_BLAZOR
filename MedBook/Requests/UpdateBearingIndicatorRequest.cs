using Business.DTO;
using MediatR;

namespace MedBook.Requests
{
    public record UpdateBearingIndicatorRequest(BearingIndicatorDto BearingIndicatorDto) : IRequest<UpdateBearingIndicatorRequest.Response>
    {
        public record Response(int Status);
    }
}
