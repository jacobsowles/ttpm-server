namespace TinyTwoProjectManager.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}