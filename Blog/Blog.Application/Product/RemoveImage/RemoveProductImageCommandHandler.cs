﻿using Blog.Application._Utilities;
using Blog.Application.Product.RemoveImage;
using Blog.Domain.ProductAgg.Repository;
using Common.Application;
using Common.Application.FileUtil.Interfaces;

internal class RemoveProductImageCommandHandler : IBaseCommandHandler<RemoveProductImageCommand>
{
    private readonly IProductRepository _repository;
    private readonly IFileService _fileService;

    public RemoveProductImageCommandHandler(IProductRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(RemoveProductImageCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetTracking(request.ProductId);
        if (product == null)
            return OperationResult.NotFound();

        var imageName = product.RemoveImage(request.ImageId);
        await _repository.Save();
        _fileService.DeleteFile(Directories.ProductGalleryImage, imageName);
        return OperationResult.Success();
    }
}