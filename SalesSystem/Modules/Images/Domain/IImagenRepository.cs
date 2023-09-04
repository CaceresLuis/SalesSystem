namespace SalesSystem.Modules.Images.Domain
{
    public interface IImagenRepository
    {
        void Add(Image image);
        Task<string> UploadImageAsync(FirebaseImage image);
    }
}
