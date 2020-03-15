using System;

namespace WPFProject_Lab2.Tools.Exceptions
{
    internal class InvalidEmailException: Exception
    {

        internal InvalidEmailException(string message) : base(message) { }

    }
}
