namespace SCORE.Models
{
    public class DocFiles
    {
        public List<FileViewModel> GetFiles(IHostEnvironment e, string? name)
        {
            List<FileViewModel> list = new List<FileViewModel>();

            DirectoryInfo dirInfo = new DirectoryInfo(
                Path.Combine(e.ContentRootPath, "wwwroot/Documents")
            );

            foreach (var item in dirInfo.GetFiles())
            {
                list.Add(new FileViewModel
                {
                    Name = item.Name,
                    Size = item.Length
                });

            }
            return list;
        }
    }
}
