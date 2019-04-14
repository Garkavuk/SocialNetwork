using System.Collections.Generic;
using System.Linq;
using Graph.Objects;

namespace Graph.Algorithm
{
    public class Dijkstra<T>
    {
        private readonly List<GraphNode<T>> _graph;
        private PriorityQueue<GraphNode<T>> _unvistedNodes;

        public Dijkstra(IEnumerable<GraphNode<T>> graph)
        {
            _graph = graph.ToList();
        }

        public IList<GraphNode<T>> FindPathBetween(GraphNode<T> start, GraphNode<T> finish)
        {
            _unvistedNodes = new PriorityQueue<GraphNode<T>>();
            _graph.ForEach(x =>
            {
                x.Visited = false;
                x.TentativeDistance = int.MaxValue;
                _unvistedNodes.Push(x);
            });
            start.TentativeDistance = 0;

            var current = start;

            while (true)
            {
                foreach (GraphNode<T>.Neighbour neighbour in current.Neighbours.Where(x => !x.GraphNode.Visited))
                {
                    var newTentativeDistance = current.TentativeDistance + neighbour.Distance;
                    if (newTentativeDistance < neighbour.GraphNode.TentativeDistance)
                    {
                        neighbour.GraphNode.TentativeDistance = newTentativeDistance;
                    }
                }

                current.Visited = true;

                var next = _unvistedNodes.Pop();
                if (next == null || next.TentativeDistance == int.MaxValue)
                {
                    if (finish.TentativeDistance == int.MaxValue)
                    {
                        return new List<GraphNode<T>>();//no path
                    }
                    finish.Visited = true;
                    break;
                }

                var smallest = next;
                current = smallest;
            }

            return GetPath(start, finish);
        }

        private static List<GraphNode<T>> GetPath(GraphNode<T> start, GraphNode<T> finish)
        {
            var current = finish;
            var path = new List<GraphNode<T>> { current };
            var currentTentativeDistance = finish.TentativeDistance;

            while (true)
            {
                if (current == start)
                {
                    break;
                }

                foreach (var neighbour in current.Neighbours.Where(x => x.GraphNode.Visited))
                {
                    if (currentTentativeDistance - neighbour.Distance == neighbour.GraphNode.TentativeDistance)
                    {
                        current = neighbour.GraphNode;
                        path.Add(current);
                        currentTentativeDistance -= neighbour.Distance;
                        break;
                    }
                }
            }
            path.Reverse();
            return path;
        }
    }
}
