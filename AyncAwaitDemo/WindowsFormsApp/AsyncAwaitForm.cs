using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class AsyncAwaitForm : Form
    {
        public AsyncAwaitForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
              var result=  await LoginAsync();
                btnLogin.Text = result;
            }
            catch (Exception)
            {

                btnLogin.Text = "Internal Error";
            }
        }

        private async Task<string> LoginAsync()
        {
            try
            {
                var result = await Task.Run(() =>
                    {
                        Thread.Sleep(2000);
                        return "Login Successfully";
                    });

                return result;
            }
            catch (Exception)
            {

                return "Login Failed";
            }
        }
    }
}
