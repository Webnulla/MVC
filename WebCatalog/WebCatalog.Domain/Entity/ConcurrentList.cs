namespace WebCatalog.Domain.Entity;

public class ConcurrentList<T>
{
    private readonly List<T>? _list;
    private readonly ReaderWriterLockSlim? _lock;

    public void AddItem(T item)
    {
        try
        {
            _lock.EnterWriteLock();
            _list.Add(item);
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }

    public bool RemoveItem(T item)
    {
        try
        {
            _lock.EnterWriteLock();
            return _list.Remove(item);
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }
}