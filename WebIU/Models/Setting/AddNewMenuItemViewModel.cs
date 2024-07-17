namespace WebIU.Models.Setting
{
    public class AddNewMenuItemViewModel
    {
        public string Name { get; set; }
        public int   ParentId { get; set; }
        public string Url { get; set; }
        public string IconCss { get; set; }

        public int? Order { get; set; }
        public int OrderCount { get; set; }
    }
}
