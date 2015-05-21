namespace Arjen.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Save();
        void Cancel();
        IObjectContext GetObjectContext();
    }
}
