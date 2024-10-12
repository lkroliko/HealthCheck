namespace HealthCheck
{
    internal class ArgsParser
    {
        private readonly string[] _args;

        internal ArgsParser(string[] args)
        {
            _args = args;
        }

        internal bool IsAddressValid() => Uri.TryCreate(_args[0], UriKind.Absolute, out var _);

        internal string GetAddress() => _args[0];

        internal bool GetIsSilent()
        {
            if (_args.Length <= 1)
                return false;
            return _args[1] == "--silent";
        }
    }
}
