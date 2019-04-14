using System.Collections.Generic;

namespace Graph.Objects
{
    public class AssociationHashSet<T> : HashSet<T>
    {
        public AssociationHashSet(int capacity = 1000)
        {
            EnsureCapacity(capacity);
        }

        public void AddItem(T v)
        {
            if (!Contains(v))
            {
                Add(v);
            }
        }
    }
}
