namespace netCore6WebApiJWT.Authentication
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
