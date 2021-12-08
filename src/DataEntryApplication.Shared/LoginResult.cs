namespace DataEntryApplication.Shared
{
    public class LoginResult
    {
        public bool Successful { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
        public int Role { get; set; }
    }
}
