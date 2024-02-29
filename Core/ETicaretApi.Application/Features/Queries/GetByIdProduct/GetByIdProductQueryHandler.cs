using ETicaretApi.Application.Repositories;
using MediatR;
using P = ETicaretApi.Domain.Entities;

namespace ETicaretApi.Application.Features.Queries.GetByIdProduct
{
    // GetAllProductQueryHandler classinda ise controllerin icersinde ki islemlere karsilik ediyor, (return'dan onceki islemlere)
    internal class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {

        readonly IProductReadRepository _productReadRepository;
        public GetByIdProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            P.Product product = await _productReadRepository.GetByIdAsync(request.Id, false);
            return new()
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }
    }
}
