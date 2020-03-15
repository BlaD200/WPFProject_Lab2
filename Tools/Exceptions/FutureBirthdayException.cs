using System;

namespace WPFProject_Lab2.Tools.Exceptions
{
    internal class FutureBirthdayException: Exception
    {

        internal FutureBirthdayException(string message) : base(message) { }
    }
}
