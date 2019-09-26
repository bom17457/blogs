using System;
using System.Collections.Generic;
using System.Text;
using blogs.Models;
using Jose;
using Newtonsoft.Json;

namespace blogs.Services
{
    public class JwtAccessTokenService
    {
        private byte[] secretKey = Encoding.UTF8.GetBytes("xorjdrid");
        public string GenerateAccessToken(Users user, int minute = 1){    
            
            DateTime dt = DateTime.UtcNow.AddMinutes(minute);

            var payload = new Dictionary<string, object>()
            {                
                    {"Username", user.Username},
                    {"Type", user.Type},
                    {"Exp", DateTime.UtcNow.AddMinutes(minute)}
            };

            return Jose.JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);
        }

        public Users VerifyAccessToken(string Token){
            try{
                EntitiesModels.Users payload = JsonConvert.DeserializeObject<EntitiesModels.Users>(JWT.Decode(Token, secretKey, JwsAlgorithm.HS256));                
                
                if(payload == null || payload.Exp < DateTime.UtcNow){
                    return null;
                }

                return payload;
            }catch(Exception ex){
                throw ex;
            }
        }
    }
}