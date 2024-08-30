using MediatR;
using Microsoft.AspNetCore.Http;
using UberEats.Domain.Exceptions;
using Microsoft.AspNetCore.Hosting;
using UberEats.Domain.Entities;
using UberEats.Domain.IRepositories;

namespace UberEats.Application.Images.AddImage
{
    public class AddImageCommandHandler : IRequestHandler<AddImageCommand>
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDishImageRepository _dishImageRepository;

        public AddImageCommandHandler(IWebHostEnvironment hostEnvironment, IHttpContextAccessor httpContextAccessor,IDishImageRepository dishImageRepository )
        {
            _hostEnvironment = hostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _dishImageRepository = dishImageRepository;
        }

        public async Task Handle(AddImageCommand request, CancellationToken cancellationToken)
        {
            ValidateImages(request.ImageFiles);
            var uploadsFolder = Path.Combine("wwwroot/DishImages");

            foreach (var file in request.ImageFiles)
            {
                var filePath = Path.Combine(uploadsFolder, file.Name+Guid.NewGuid().ToString().Substring(5)+ Path.GetExtension(file.FileName));
                DishImage ImageDomain = new DishImage()
                {
                    FileName = file.FileName,
                    FileExtension = Path.GetExtension(file.FileName).ToLowerInvariant(),
                    FileSizeBytes = file.Length,
                    DishId=request.DishId,

                };
                

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    ImageDomain.FilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}" +
                        $"/{filePath}";
                }
                await _dishImageRepository.AddImage(ImageDomain);
            }

        }

        private void ValidateImages(List<IFormFile> imageFiles)
        {
            var allowedExtensions = new List<string> { ".png", ".jpg", ".jpeg" };

            foreach (var file in imageFiles)
            {
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(extension))
                {
                    throw new BadRequestException("Allowed extensions for images are only: png, jpg, jpeg.");
                }

                if (file.Length > 15000000)
                {
                    throw new BadRequestException("Max size of an image is 15MB.");
                }
            }
        }
    }
}
