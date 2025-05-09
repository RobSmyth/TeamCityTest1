using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganisationName.ProductName.ComponentName.TestProject1
{
    [TestFixture]
    internal class ConsoleAppIntegrationTests
    {
        [Test]
        public void DisplaysHelloMessageWhenRun()
        {
            var finished = RunApp();

            Assert.That(finished, Is.True);
        }

        private static bool RunApp()
        {
            var process = new Process();
            process.StartInfo = new ProcessStartInfo("dotnet", "ConsoleApp1.dll");
            process.Start();

            return process.WaitForExit(5000);
        }
    }
}
