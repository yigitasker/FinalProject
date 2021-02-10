using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult                             // Hangi tipi dödüreceğini bana söyle. IResult içindekilerde burda geçerli olacak
    {
        T Data { get; }                                             // Data = ürünlerimiz, başka bişey,...
    
    
    
    }
}
