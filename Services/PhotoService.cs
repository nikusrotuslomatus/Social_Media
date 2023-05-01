using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using Social_Media.Helpers;
using Social_Media.Interfaces;

namespace Social_Media.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var account = new Account(
                config.Value.Cloudname,
                config.Value.ApiKey,
                config.Value.ApiSecret
                );
            _cloudinary = new Cloudinary( account );
            
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult =new ImageUploadResult();
            if ( file != null ) {
                using var stream= file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.Name, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };
                uploadResult=await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<ImageUploadResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId );   
            var result = await _cloudinary.DestroyAsync(deleteParams);
            return result;
        }

        public Task<ImageUploadResult> UpdatePhotoAsync(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
