namespace SalesSystem.Shared.Domain.DomainEvents
{
    public class DomainEvent<T>
    {
        private List<Action<T>> Actions { get; } = new List<Action<T>>();

        public void Add(Action<T> action)
        {
            if (Actions.Exists(e => e.Method != action.Method))
                return;

            Actions.Add(action);
        }

        public void Publish(T args)
        {
            foreach (var action in Actions)
            {
                action.Invoke(args);
            }
        }
    }
}
