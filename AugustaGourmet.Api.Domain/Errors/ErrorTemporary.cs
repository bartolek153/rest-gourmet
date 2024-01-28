namespace AugustaGourmet.Api.Domain.Errors
{
    public class ErrorTemporary : IEquatable<ErrorTemporary>
    {
        public static readonly ErrorTemporary None = new(string.Empty, string.Empty);
        public static readonly ErrorTemporary NullValue = new("Error.NullValue", "The specified value is null.");

        public string Code { get; }
        public string Message { get; }

        public ErrorTemporary(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public static implicit operator string(ErrorTemporary error) => error.Code;

        public static bool operator ==(ErrorTemporary? a, ErrorTemporary? b) =>
            ReferenceEquals(a, b) || a?.Code == b?.Code;
        public static bool operator !=(ErrorTemporary? a, ErrorTemporary? b) => !(a == b);

        public bool Equals(ErrorTemporary? other)
        {
            if (other is null)
                return false;
            return Code == other.Code;
        }
        public override bool Equals(object? obj) => Equals(obj as ErrorTemporary);
        public override int GetHashCode() => Code.GetHashCode();
        public override string ToString() => $"Error: {Code} - {Message}";
    }
}