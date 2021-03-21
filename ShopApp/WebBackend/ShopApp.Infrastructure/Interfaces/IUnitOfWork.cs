using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Call Save change from db context
        void Commit();
    }
}
