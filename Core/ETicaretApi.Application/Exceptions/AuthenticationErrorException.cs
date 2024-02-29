﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Exceptions
{
    public class AuthenticationErrorException : Exception
    {
        public AuthenticationErrorException() : base("Token couldn't created")
        {
        }

        public AuthenticationErrorException(string? message) : base(message)
        {
        }

        public AuthenticationErrorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AuthenticationErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
