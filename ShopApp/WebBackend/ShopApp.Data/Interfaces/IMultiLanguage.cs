using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Data.Interfaces
{
    public interface IMultiLanguage<T>
    {
        T LanguageId { get; set; }
    }
}
