using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>                // DataResulr, sen bir Resultsın diyor.
    {
        public DataResult(T data,bool success,string message):base(success,message)                 // base = Result için constrctor ları gönderdiklerime göre çalıştır.            
        {
            Data = data;
        }

        public DataResult(T data,bool success):base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
