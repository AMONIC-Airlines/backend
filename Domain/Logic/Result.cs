namespace Domain.Logic;

public class Result
{
    public bool Success { get; }
    public string Error { get; }
    public bool IsFailure => !Success;
    public bool IsException => !Success;

    protected Result(bool success, string error)
    {
        if (success && error != string.Empty)
            throw new InvalidOperationException();
        if (!success && error == string.Empty)
            throw new InvalidOperationException();
        Success = success;
        Error = error;
    }

    public static Result Fail(string message)
    {
        return new Result(false, message);
    }

    public static Result<T> Fail<T>(string message)
    {
        return new Result<T>(default, false, message);
    }

    public static Result Ok()
    {
        return new Result(true, string.Empty);
    }

    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>(value, true, string.Empty);
    }


    public static Result Exception(string message)
    {
        return new Result(false, message);
    }

    public static Result<T> Exception<T>(string message)
    {
        return new Result<T>(default, false, message);
    }
}

public class Result<T> : Result
{
    public T? Value { get; set; }

    protected internal Result(T? value, bool success, string error) : base(success, error)
    {
        Value = value;
    }
}
