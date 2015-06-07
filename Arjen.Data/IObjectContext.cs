using System.Data.Entity;

namespace Arjen.Data
{
    public interface IObjectContext
    {
        DbSet<T> Set<T>() where T : class;
        RelatedObjectsConfiguration RelatedObjectsConfiguration { get; set; }
        CachingSettings CachingSettings { get; set; }
    }

    public class CachingSettings
    {
        public CachingSettings()
        {
            UseCache = true;
        }

        public bool UseCache { get; set; }
    }
}
