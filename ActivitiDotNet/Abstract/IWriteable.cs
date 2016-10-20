namespace ActivitiDotNet.Abstract
{
    interface IWriteable<T>
    {
        T Update(string id, T value);

        T Create(T value);

    }
}
