namespace WebCatalog.Domain.Events;

public static class DomainEvents
{
    private static readonly Dictionary<Type, List<Delegate>> _handlers = new();

    public static void Register<T>(Action<T> eventHandler)
        where T : IDomainEvents
    {
        if (_handlers.ContainsKey(typeof(T)))
        {
            _handlers[typeof(T)].Add(eventHandler);
        }
        else
        {
            _handlers[typeof(T)] = new List<Delegate>() {eventHandler};
        }
    }

    public static void Raise<T>(T domainEvent)
        where T : IDomainEvents
    {
        foreach (Delegate handler in _handlers[domainEvent.GetType()])
        {
            var action = (Action<T>)handler;
            action(domainEvent);
        }
    }
}