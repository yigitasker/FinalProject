using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)                // gönderdiğim değerlerinden sadece hata veren kuralı dödürür. params = birden fazla veri yazmamı sağlar
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)                         // doğru değilse
                {
                    return logic;                           // metotu dödür.
                }
            }
            return null;
        }
    }
}
