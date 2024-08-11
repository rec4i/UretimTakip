namespace WebIU.Models.HelperModels
{
    public class JsonResponseModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}
