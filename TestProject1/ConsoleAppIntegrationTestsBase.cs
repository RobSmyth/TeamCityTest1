using System.Diagnostics;

namespace OrganisationName.ProductName.ComponentName.TestProject1;

internal abstract class ConsoleAppIntegrationTestsBase
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
    [TestCase(12)]
    [TestCase(13)]
    [TestCase(14)]
    [Timeout(10000)]
    public void DisplaysHelloMessageWhenRun(int arbitraryValue)
    {
        RunTest();
    }

    [Test]
    [Timeout(10000)]
    public void DisplaysHelloMessageWhenRun02()
    {
        RunTest();
    }

    private static void OnErrorDataReceived(string? data, TextWriter errorOut)
    {
        if (data == null)
        {
            return;
        }

        errorOut.WriteLine(data);
    }

    private bool RunApp(StringWriter outWriter, StringWriter? errorWriter)
    {
        var process = new Process();
        process.StartInfo.FileName = "dotnet";
        process.StartInfo.Arguments = "ConsoleApp1.dll";
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

        return process.WaitForExit(5000);
    }

    private void RunTest()
    {
        var outWriter = new StringWriter();
        var errorWriter = new StringWriter();

        var finished = RunApp(outWriter, errorWriter);
        Assert.That(finished, Is.True);

        var output = outWriter.ToString();
        var errorOutput = errorWriter.ToString();

        Assert.That(output, Is.EqualTo($"Hello, World!{Environment.NewLine}"));
        Assert.That(errorOutput, Is.Empty);
    }
}