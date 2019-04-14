namespace Graph.Objects
{
    public interface IPriorityQueue<T>
    {
        void Push(T item);
        T Pop();
    }
}
