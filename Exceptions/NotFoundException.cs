namespace Class13.Exceptions
{
    public class NotFoundException : ArgumentException
    {
        public NotFoundException(string? message) : base(message)
        {
        }

        public static void ThrowIfNull<T>(T? param, string? message = null)
        {
            if (param is null)
            {
                throw new NotFoundException(message ?? $"{nameof(param)} was not found");
            }
        }
    }
}
