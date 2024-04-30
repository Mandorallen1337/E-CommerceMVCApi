namespace E_CommerceMVCApi.Models.Entities
{
    public class Images
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public int FileSize { get; set; }
        public string FilePath { get; set; }

        public Images()
        {

        }

        public Images(string fileName, string fileType, int fileSize, string filePath)
        {
            FileName = fileName;
            FileType = fileType;
            FileSize = fileSize;
            FilePath = filePath;
        }
    }
}
