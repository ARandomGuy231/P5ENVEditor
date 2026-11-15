namespace P5ENVEditor
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Logger.GenerateNewLog();
            ApplicationConfiguration.Initialize();
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            Application.Run(new MainWindow());
        }
    }
}
