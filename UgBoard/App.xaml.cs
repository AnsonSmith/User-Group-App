namespace UgBoard
{
    using System.Windows;
    using System.Windows.Threading;

    public partial class App : Application
    {
        Bootstrapper bootstrapper;

        public App()
        {
            bootstrapper = new Bootstrapper();
        }

        /// <summary>
        /// DispatcherUnhandledException is used to catch all unhandled exceptions.
        /// </summary>
        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {

            //REMARK: Should we handle the exception and do something more user-friendly here?
            MessageBox.Show("UG Board has encountered an unexpected error. App_DispatcherUnhandledException");
        }

    }
}
