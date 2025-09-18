using System;

public class CSetException : Exception
{
    public CSetException(string message) : base(message) { }
}

public class InvalidElementException : CSetException
{
    public InvalidElementException(string message) : base(message) { }
}

public class FileOpenException : CSetException
{
    public FileOpenException(string message) : base(message) { }
}

public class FileReadException : CSetException
{
    public FileReadException(string message) : base(message) { }
}

public class DuplicateElementException : CSetException
{
    public DuplicateElementException(string message) : base(message) { }
}
