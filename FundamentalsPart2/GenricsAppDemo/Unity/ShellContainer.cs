using Microsoft.Practices.Unity;
namespace GenricsAppDemo
{
    public static class ShellContainer
    {
        private static UnityContainer Instance { get; set; }
        static ShellContainer()
        {
            Instance = new UnityContainer();
        }
        public static T Resolve<T>()
        {
            return Instance.Resolve<T>();
        }
    }
}
