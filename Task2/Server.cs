namespace Task2;

public class ImmutableWrapper(int value)
{
    public int Value { get; } = value;
}

public static class Server
{
    private static ImmutableWrapper _value = new(10);
    private static readonly ReaderWriterLockSlim  _lock = new();

    public static int GetCount()
    {
        _lock.EnterReadLock();
        try
        {
            return _value.Value;
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }

    public static void AddToCount(int value)
    {
        _lock.EnterWriteLock();
        try
        {
            _value = new ImmutableWrapper(_value.Value + value);
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }
    
}