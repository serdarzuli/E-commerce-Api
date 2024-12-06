using MediatR;

namespace ETicaretApi.Application.Features.Queries.GetByIdProduct
{
         public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public string Id { get; set; }
    }
}
