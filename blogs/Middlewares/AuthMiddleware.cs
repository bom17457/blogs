namespace blogs.Middleware
{
    public class AuthMiddleware
    {
        Services.JwtAccessTokenService jwt = new Services.JwtAccessTokenService();

        public AuthMiddleware(){            
            string type = jwt.VerifyAccessToken("sdf").Type;
        }
    }
}