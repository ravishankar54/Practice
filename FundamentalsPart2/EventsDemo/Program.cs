using System;
using System.ComponentModel;
using System.Reflection.Emit;

namespace EventsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Employee : INotifyPropertyChanged, IDisposable
    {
        public string Name
        {
            get { return "Suceed"; }
            set
            {
                var val = value;
                OnPropertyChange(val);
            }
        }

        private void OnPropertyChange(string val)
        {
            if (PropertyChanged != null)
            {
                var args = new PropertyChangedEventArgs(val);
                PropertyChanged(this, args);
            }


        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~Employee()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            //Requests that the common language runtime not call the finalizer for the specified
            //     object.
            GC.SuppressFinalize(this);

            //Forces an immediate garbage collection of all generations.
            GC.Collect();
            var obj = new object();
            DynamicMethod hjj;
            hjj = null;
            var iy = hjj;
        }
        #endregion
    }
}
