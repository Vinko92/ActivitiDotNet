using System.Collections.Generic;

namespace ActivitiDotNet.Abstract
{
    internal interface IRemoveable<T>
    {
        T Delete(string id);

        bool TryDelete(string id, out T value);
    }
}
