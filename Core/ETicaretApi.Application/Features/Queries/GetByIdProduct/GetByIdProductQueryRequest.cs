using MediatR;

namespace ETicaretApi.Application.Features.Queries.GetByIdProduct
{
    //burada controllerda bulunan hangi entity icin islem yapiyorsak onun propertysini vermemiz gerekiyor
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public string Id { get; set; }
    }
}
