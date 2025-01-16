using Blog.Application._Utilities;
using Blog.Application.Product.Remove;
using Blog.Domain.ProductAgg.Repository;
using Common.Application;
using Common.Application.FileUtil.Interfaces;

internal class RemoveProductCommandHandler : IBaseCommandHandler<RemoveProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;

        public RemoveProductCommandHandler(IProductRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.productId);
            if (product == null)
                return OperationResult.NotFound();

            foreach(var item in product.Images)
            {
                var imageName = product.RemoveImage(item.Id);
                _fileService.DeleteFile(Directories.ProductGalleryImage, imageName);

            }
            await _repository.Save();
            return OperationResult.Success();
        }
    }
