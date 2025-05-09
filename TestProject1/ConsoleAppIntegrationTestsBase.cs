using System.Diagnostics;

namespace OrganisationName.ProductName.ComponentName.TestProject1;

internal abstract class ConsoleAppIntegrationTestsBase
{
    [TestCase(1)]
    [TestCase(20)]
    [TestCase(100)]
    [TestCase(50)]
    [TestCase(500)]
    [TestCase(300)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(200)]
    [TestCase(110)]
    [TestCase(12)]
    [TestCase(13)]
    [TestCase(14)]
    [Timeout(10000)]
    public void DisplaysHelloMessageWhenRun(int runDelayMilliseconds)
    {
        RunTest(runDelayMilliseconds);
    }

    [Test]
    [Timeout(20000)]
    public void DisplaysHelloMessageWhenRun02()
    {
        RunTest(4000);
    }

    [Test]
    [Timeout(20000)]
    public void DisplaysHelloMessageWhenRun03()
    {
        RunTest(6000);
    }

    [Test]
    [Timeout(20000)]
    public void DisplaysHelloMessageWhenRun04()
    {
        RunTest(5000);
    }

    private static void OnErrorDataReceived(string? data, TextWriter errorOut)
    {
        if (data == null)
        {
            return;
        }

        errorOut.WriteLine(data);
    }

    private bool RunApp(StringWriter outWriter, StringWriter? errorWriter, int runDelayMilliseconds)
    {
        Console.WriteLine($"Run app with {runDelayMilliseconds} ms delay");
        var process = new Process();
        process.StartInfo.FileName = "dotnet";
        process.StartInfo.Arguments = $"ConsoleApp1.dll {runDelayMilliseconds}";
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;

        if (errorWriter != null)
        {
            process.ErrorDataReceived += (sender, data) => OnErrorDataReceived(data.Data, errorWriter);
        }

        process.Start();

        process.BeginErrorReadLine();
        outWriter.Write(process.StandardOutput.ReadToEnd());

        return process.WaitForExit(30000);
    }

    private void RunTest(int runDelayMilliseconds)
    {
        var outWriter = new StringWriter();
        var errorWriter = new StringWriter();

        var finished = RunApp(outWriter, errorWriter, runDelayMilliseconds);
        Assert.That(finished, Is.True);
        Console.WriteLine("App completed");

        var output = outWriter.ToString();
        var errorOutput = errorWriter.ToString();

        Assert.That(output, Is.EqualTo($"Hello, World!{Environment.NewLine}"));
        Assert.That(errorOutput, Is.Empty);
    }
}