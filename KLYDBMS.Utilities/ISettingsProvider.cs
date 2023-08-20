namespace KLYDBMS.Utilities
{
    public interface ISettingsProvider<T>
    {
        T Settings { get; }

        void Save();
    }
}
