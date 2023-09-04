using Firebase.Auth;
using Firebase.Storage;
using Microsoft.Extensions.Options;
using SalesSystem.Modules.Images.Domain;
using SalesSystem.Shared.Infrastructure;

namespace SalesSystem.Modules.Images.Infrastructure
{
    public class ImagenRepository : IImagenRepository
    {
        private readonly FireBaseConfiguration _fireConfiguration;
        private readonly ApplicationDbContext _applicationDbContext;

        public ImagenRepository(IOptions<FireBaseConfiguration> fireConfiguration, ApplicationDbContext applicationDbContext)
        {
            _fireConfiguration = fireConfiguration.Value;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<string> UploadImageAsync(FirebaseImage image)
        {
            FirebaseAuthProvider auth = new (new FirebaseConfig(_fireConfiguration.ApiKey));
            FirebaseAuthLink a = await auth.SignInWithEmailAndPasswordAsync(_fireConfiguration.Email, _fireConfiguration.Password);

            CancellationTokenSource cancellation = new();

            FirebaseStorageTask task = new FirebaseStorage(
                _fireConfiguration.Rute,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child(image.Folder)
                .Child(image.Name)
                .PutAsync(image.File, cancellation.Token);

            return await task;
        }

        public void Add(Image image) => _applicationDbContext.Images.Add(image);
    }
}
