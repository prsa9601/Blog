using Blog.Application._Utilities;
using Blog.Domain.ProductAgg;
using Blog.Domain.ProductAgg.Repository;
using Common.Application;
using Common.Application.FileUtil.Interfaces;

namespace Blog.Application.Product.AddImage
{
    public class AddImageProductCommandHandler : IBaseCommandHandler<AddImageProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;

        public AddImageProductCommandHandler(IProductRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(AddImageProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if (product == null) {return OperationResult.NotFound(); }

            var imageName = await _fileService
                 .SaveFileAndGenerateName(request.ImageFile, Directories.ProductGalleryImage);

            var productImage = new ProductImage(imageName, request.Sequence);
            product.AddImage(productImage);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
