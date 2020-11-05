namespace tracker.WebApi.Models
{
    public class result<T>
    {
        public string code { get; set; }
        public string msg { get; set; }
        public T data { get; set; }

        public void setResult(string code, string msg, T data)
        {
            this.code = code;
            this.msg = msg;
            this.data = data;
        }
    }
}