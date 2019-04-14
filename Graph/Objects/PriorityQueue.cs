using System.Collections.Generic;
using System.Linq;

namespace Graph.Objects
{
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IGraphNode
    {
        private readonly List<T> _innerList = new List<T>();

        public void Push(T item)
        {
            _innerList.Add(item);
        }

        public T Pop()
        {
            if (_innerList.Count <= 0)
            {
                return default;
            }

            var item = _innerList.OrderBy(i => i.TentativeDistance).First();
            _innerList.Remove(item);
            return item;
        }
    }
}