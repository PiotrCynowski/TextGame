namespace TextGame
{
    public class CommandResult
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }

    public struct CommandData
    {
        public string command;
        public string target;

        public CommandData(string inputCommand)
        {
            string[] parts = inputCommand.Split(' ', 2);
            command = parts[0];
            target = parts.Length > 1 ? parts[1] : string.Empty;
        }
    }
}