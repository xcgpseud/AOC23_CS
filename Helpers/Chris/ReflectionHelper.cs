namespace Helpers.Chris;

public static class ReflectionHelper
{
    private static List<Type> GetImplementations<T>(string user) where T : class
    {
        var type = typeof(T);
        var assembly = type.Assembly;

        return assembly
            .GetTypes()
            .Where(
                t => type.IsAssignableFrom(t) &&
                     t is { IsClass: true, IsAbstract: false } &&
                     t.Namespace?.Contains($"Services.{user}") == true
            )
            .ToList();
    }

    private static List<T> CreateInstances<T>(List<Type> types) where T : class
    {
        var results = new List<T>();

        types.ForEach(
            t =>
            {
                if (Activator.CreateInstance(t) is T instance)
                {
                    results.Add(instance);
                }
            }
        );

        return results;
    }

    public static List<T> CreateInstancesOfImplementations<T>(string user) where T : class
    {
        return CreateInstances<T>(GetImplementations<T>(user));
    }
}