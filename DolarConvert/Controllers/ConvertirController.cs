using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using DolarConvert.Recursos;
using System.ComponentModel.DataAnnotations;

namespace DolarConvert.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ConvertirController : ControllerBase
    {
        [HttpGet(Name = "GetQuote")]
        public async Task<string> GetQuote([FromQuery, Required] decimal value)
        {
            ExampleAPI api = new ExampleAPI();
            decimal result = await api.GetSpecificQuote();
            return (result * value).ToString();
        }
    }
}
