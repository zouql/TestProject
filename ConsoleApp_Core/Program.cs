namespace ConsoleApp_Core
{
    using System;
    using System.IO;
    using NLog;

    class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetLogger("test");

            var resourceName = $"{typeof(Program).Namespace}.NLog.config";

            var configStream = typeof(Program).Assembly.GetManifestResourceStream(resourceName);

            var fileName = $"{Environment.CurrentDirectory}/nlog_{Guid.NewGuid()}.config";

            File.WriteAllBytes(fileName, configStream.ReadBytes());

            logger.Factory.LoadConfiguration(fileName);

            //var logger = LogManager.GetLogger("test");

            //logger.Factory.LoadConfiguration("NLog.config");

            System.IO.File.Delete(fileName);

            logger.Trace(DateTime.Now.ToString());
            logger.Debug(DateTime.Now.ToString());
            logger.Info(DateTime.Now.ToString());
            logger.Warn(DateTime.Now.ToString());
            logger.Error(DateTime.Now.ToString());
            logger.Fatal(DateTime.Now.ToString());

            Console.WriteLine("Hello World!");
        }
    }
}
