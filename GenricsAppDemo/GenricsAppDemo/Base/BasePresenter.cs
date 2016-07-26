using System;

namespace GenricsAppDemo
{
    public class BasePresenter<TView> where TView : IBaseView
    {
        public TView View { get; set; }

        public void Display(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
