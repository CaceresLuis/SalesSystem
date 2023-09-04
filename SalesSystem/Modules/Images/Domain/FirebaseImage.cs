namespace SalesSystem.Modules.Images.Domain
{
    public class FirebaseImage
    {
        public Stream File { get; set; } = new MemoryStream();
        public string Name { get; set; } = string.Empty;
        public string Folder { get; set; } = string.Empty;
    }
}
