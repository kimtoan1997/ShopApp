using ShopApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { get; set; }
    }
}
