namespace Lesson21;
//using Microsoft.Playwright;
public class AsyncHomework
{
    public async Task<string> GetStringAsync()
    {
        await Task.Delay(500);
        return "Hello, World!";
    }

    public async Task<int> GetNumberWithExceptionAsync()
    {
        await Task.Delay(1000);
        throw new InvalidOperationException("An error occurred while fetching the number.");
    }

    [Test]
    public async Task TestGetStringAsync()
    {
        // TODO: Uncomment and implement test so it pass
        var result = "Hello, World!";
       //await Assertions.Expect(result).Tob
    }

    [Test]
    public void TestGetNumberWithExceptionAsync()
    {
        // TODO: Verify that GetNumberWithExceptionAsync() throws InvalidOperationException
        // and that exception message is "An error occurred while fetching the number."
    }

}