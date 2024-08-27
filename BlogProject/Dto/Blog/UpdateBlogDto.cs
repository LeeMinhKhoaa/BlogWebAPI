namespace BlogProject.Dto.Blog
{
    public class UpdateBlogDto
    {
        public string? Title { get; set; }
        public string? Content { get; set; }

        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
