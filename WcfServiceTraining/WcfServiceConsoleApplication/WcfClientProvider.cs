using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceConsoleApplication
{
    public class WcfClientProvider<T> : IDisposable
    {
        private ChannelFactory<T> factory;

        public WcfClientProvider()
        {
            factory = new ChannelFactory<T>(string.Empty);
            Open();
        }

        public object GetProxy()
        {
            return factory.CreateChannel();
        }

        public void Open()
        {
            if (factory.State != CommunicationState.Opened)
            {
                factory.Open();
            }
        }

        public void Dispose()
        {
            factory.Close();
        }
    }
}
