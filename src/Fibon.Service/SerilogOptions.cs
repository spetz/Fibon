namespace Fibon.Api.Framework
{
    public class SerilogOptions
    {
        public string Level { get; set; }
        public string ApiUrl { get; set; }
        public bool UseBasicAuth { get; set ;}
        public string Username { get; set; }
        public string Password { get; set; }
        public string IndexFormat { get; set; }        
    }
}