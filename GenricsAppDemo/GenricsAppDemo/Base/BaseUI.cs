using System.Web.UI;
namespace GenricsAppDemo
{
    public class BaseUI : Page
    {
        public T CreatePresenter<T>()
        {
            return ShellContainer.Resolve<T>();
        }
    }
}
