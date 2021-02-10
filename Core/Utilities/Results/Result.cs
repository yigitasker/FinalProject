using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        

        public Result(bool success, string message):this(success)                 // iki parametre yolluyorsa success i de çalıştır demek. aşağıda
        {
            Message = message;
            
        }

        public Result(bool success)                   // tek veride yollayabilir.
        {
           Success = success;
        }

        public bool Success { get; }            // get, return yani döndür demek.

        public string Message { get; }
    }
}
