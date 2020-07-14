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
        private static readonly int MAX_ELEMENTS = 18;
        public DotnetArrayController(ILogger<DotnetArrayController> logger)
        {
            _logger = logger;
        }

        [HttpGet("generateArray")]
        public IActionResult GenerateArray()
        {
            var array = new DotnetArray<long>(MAX_ELEMENTS + 1);
            for (int k = 0; k < MAX_ELEMENTS + 1; k++)
            {
                array.Insert(_random.Next(0, 999));
            }
            long[] tmpArray= array.toArray();
            Array.Sort(tmpArray);
            return Ok(new { values =tmpArray});
        }

        [HttpPost("findArray/binarysearch")]
        public IActionResult FindArrayBinarySearch([FromBody] BinarySearchQuery searchQuery)
        {
            var array = new DotnetArray<long>(MAX_ELEMENTS + 1);
            array.BinarySearch(searchQuery.Array, searchQuery.SearchKey);
            return Ok(new BinarySearchResult { VisitedIndex= array.visitedIndexOnBinarySearch, Found = array.found });
        }
    }
}
