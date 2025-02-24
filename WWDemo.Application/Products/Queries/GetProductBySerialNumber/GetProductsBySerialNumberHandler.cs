using AutoMapper;
using MediatR;
using WWDemo.Application.DTOs;
using WWDemo.Data.Products;

namespace WWDemo.Application.Products.Queries.GetProductBySerialNumber
{
    public class GetProductsBySerialNumberHandler : IRequestHandler<GetProductBySerialNumberQuery, ProductRepresentation>
    {
        private readonly IProductRepository _productRepository;
        

        public GetProductsBySerialNumberHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            
        }
        public async Task<ProductRepresentation> Handle(GetProductBySerialNumberQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductBySerialNumber(request.SerialNumber);
            var result = new ProductRepresentation { 
                                                    Category = product.Category, 
                                                    Name = product.Name, 
                                                    Price = product.Price, 
                                                    SerialNumber = product.SerialNumber };
            return result; 
        }
    }
}
