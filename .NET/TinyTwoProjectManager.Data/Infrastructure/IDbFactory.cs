using System;

namespace TinyTwoProjectManager.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ProjectManagerDbContext Init();
    }
}