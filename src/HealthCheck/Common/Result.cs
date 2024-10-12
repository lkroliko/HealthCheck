namespace HealthCheck.Common;

internal class Result
{
    internal bool IsSuccess { get; }
    internal Result(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    internal static Result Ok() => new Result(true);
    internal static Result Fail() => new Result(false);

    public static implicit operator int(Result result) => result.IsSuccess ? 0 : 1;
}
