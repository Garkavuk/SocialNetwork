using Graph.Algorithm;
using Graph.Objects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Graph.IO;

namespace Graph.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialNetworkController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            var filePath = @"Data\SocialNetwork.txt";
            string pointA = "STACEY_STRIMPLE";
            string pointB = "RICH_OMLI";

            var graphDictionary = new Dictionary<string, GraphNode<string>>();
            var unique = new AssociationHashSet<string>(100 * 1000);
            var links = new AssociationHashSet<string[]>(1000 * 1000);

            IOServicecs.GetData(filePath, graphDictionary, unique, links);
            Dijkstra<string> dijkstra = new Dijkstra<string>(graphDictionary.Select(g => g.Value));

            var path = dijkstra.FindPathBetween(graphDictionary[pointA], graphDictionary[pointB]);

            return $"Count of people: {unique.Count}. Path between {pointA} and {pointB} :[ {string.Join(" -> ", path.Select(p => p.Value).ToArray())} ]";
        }
    }
}
