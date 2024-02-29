namespace ETicaretApi.Application.Features.Queries.GetByIdProduct
{
    //GetAllProductQueryResponse classinda controllerda ki return'e karsilik geliyor.
    public class GetByIdProductQueryResponse
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
    }
}
