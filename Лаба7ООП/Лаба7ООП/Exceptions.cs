// Exceptions.cs
using System;


public class SetException : Exception
{
    public SetException(string message) : base(message) { }

   
    public SetException(string message, Exception innerException)
        : base(message, innerException) { }
}


public class InvalidObjectDataException : SetException
{
    public InvalidObjectDataException(string message) : base(message) { }

   
    public InvalidObjectDataException(string message, Exception innerException)
        : base(message, innerException) { }
}


public class FileProcessingException : SetException
{
    public FileProcessingException(string message) : base(message) { }

    
    public FileProcessingException(string message, Exception innerException)
        : base(message, innerException) { }
}


public class InvalidFileFormatException : FileProcessingException
{
    public InvalidFileFormatException(string message) : base(message) { }

    
    public InvalidFileFormatException(string message, Exception innerException)
        : base(message, innerException) { }
}


public class UnsupportedTypeException : SetException
{
    public UnsupportedTypeException(string message) : base(message) { }

   
    public UnsupportedTypeException(string message, Exception innerException)
        : base(message, innerException) { }
}


public class MemoryAllocationException : SetException
{
    public MemoryAllocationException(string message) : base(message) { }

    
    public MemoryAllocationException(string message, Exception innerException)
        : base(message, innerException) { }
}