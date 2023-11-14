namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    internal static class Utilities
    {
        public static string BuildArguments(Collection<string?> argumentList)
        {
            var arguments = new StringBuilder();
            if (argumentList is not { Count: > 0 })
            {
                return string.Empty;
            }

            foreach (string? argument in argumentList) PasteArguments.AppendArgument(ref arguments, argument);
            return arguments.ToString();
        }
    }
}
