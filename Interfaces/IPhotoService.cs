using CloudinaryDotNet.Actions;

namespace Social_Media.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<ImageUploadResult> UpdatePhotoAsync(IFormFile file);
        public Task<ImageUploadResult> DeletePhotoAsync(string publicUrl);
    }
}
