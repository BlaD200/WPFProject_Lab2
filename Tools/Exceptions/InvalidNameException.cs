using System;

namespace WPFProject_Lab2.Tools.Exceptions
{
    internal class InvalidNameException: Exception
    {

        internal InvalidNameException(string message) : base(message) { }
    }
}
