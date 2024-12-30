using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace WardGames.Web.Apple.AppStoreConnect.Experiments
{
    public class PEMTester
    {
        public static ECDsa LoadPrivateKeyFromPem(string privateKeyPem)
        {
            var lines = privateKeyPem.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var trimmedLines = lines[1..^1]; // Exclude the first and last line
            var base64Key = string.Concat(trimmedLines);

            byte[] privateKeyDer = Convert.FromBase64String(base64Key);
            ECDsa privateKey = ECDsa.Create();
            privateKey.ImportPkcs8PrivateKey(privateKeyDer, out _);

            return privateKey;
        }
    }
}