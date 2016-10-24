namespace ActivitiDotNet.Abstract
{
    interface IWriteable<T>
    {
        T Update(string id, T value);

        void Create(ref T value);

    }
}
