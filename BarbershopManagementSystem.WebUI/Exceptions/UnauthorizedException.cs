﻿namespace BarbershopManagementSystem.WebUI.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base() { }

        public UnauthorizedException(string message) : base(message) { }
    }
}
