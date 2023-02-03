namespace Domain.Logic;

public class Result
{
    public bool Success { get; }
    public string Error { get; }
    public bool IsFailure => !Success;
    public bool IsException { get; }

    protected Result(bool success, bool isException, string error)
    {
        Success = success;
        IsException = isException;
        Error = error;
    }

    public static Result Fail(string message)
    {
        return new Result(false, false, message);
    }

    public static Result<T> Fail<T>(string message)
    {
        return new Result<T>(default, false, false, message);
    }

    public static Result Ok()
    {
        return new Result(true, false, string.Empty);
    }

    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>(value, true, false, string.Empty);
    }

    public static Result Exception()
    {
        return new Result(false, false, string.Empty);
    }

    public static Result<T> Exception<T>()
    {
        return new Result<T>(default, false, false, string.Empty);
    }
}

public class Result<T> : Result
{
    public T? Value { get; set; }

    protected internal Result(T? value, bool success, bool isException, string error)
        : base(success, isException, error)
    {
        Value = value;
    }
}
