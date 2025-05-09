using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganisationName.ProductName.ComponentName.TestProject1
{
    [Parallelizable]
    [TestFixture]
    internal class ConsoleAppIntegrationTests
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        public void DisplaysHelloMessageWhenRun(int arbitraryValue)
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
