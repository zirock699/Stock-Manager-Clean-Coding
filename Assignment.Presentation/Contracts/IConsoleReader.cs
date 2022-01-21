namespace Assignment.Contracts
{
    public interface IConsoleReader
    {
        int ReadInteger(string prompt);
        decimal ReadDecimal(string prompt);
        string ReadString(string prompt);
    }
}
