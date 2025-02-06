using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private const int Shift = 3; 

        // POST: api/crypto/encrypt
        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] string text)
        {
            if (string.IsNullOrEmpty(text))
                return BadRequest("Text cannot be empty");

            string encryptedText = EncryptText(text);
            return Ok(new { encryptedText });
        }

        // POST: api/crypto/decrypt
        [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText))
                return BadRequest("Text cannot be empty");

            string decryptedText = DecryptText(encryptedText);
            return Ok(new { decryptedText });
        }

        private string EncryptText(string text)
        {
            return new string(text.Select(c => (char)(c + Shift)).ToArray());
        }

        private string DecryptText(string encryptedText)
        {
            return new string(encryptedText.Select(c => (char)(c - Shift)).ToArray());
        }
    }
}
