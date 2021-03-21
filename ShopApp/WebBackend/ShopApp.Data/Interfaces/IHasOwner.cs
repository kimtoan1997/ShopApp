using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Data.Interfaces
{
    public interface IHasOwner<T>
    {
        T OwerId { get; set; }
    }
}
