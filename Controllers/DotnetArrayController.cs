using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStruct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DataStructBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DotnetArrayController : ControllerBase
    {

        private readonly ILogger<DotnetArrayController> _logger;
        private readonly Random _random = new Random();

        public DotnetArrayController(ILogger<DotnetArrayController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetDotnetArrayWithRandomValues/{maxElements}")]
        public long[] GetDotnetArrayWithRandomValues(int maxElements)
        {
            var array = new DotnetArray<long>(maxElements);
            for (int k = 0; k < maxElements; k++)
            {
                array.Insert(_random.Next(0, 100));
            }
            return array.toArray();
        }
    }
}
