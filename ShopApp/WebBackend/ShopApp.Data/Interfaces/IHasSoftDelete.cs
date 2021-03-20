using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Data.Interfaces
{
    public interface IHasSoftDelete
    {
        bool IsDelete { get; set; }
    }
}
