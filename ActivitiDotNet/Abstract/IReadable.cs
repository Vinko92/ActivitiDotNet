using System.Collections.Generic;

namespace ActivitiDotNet.Abstract
{
    interface IReadable<T>
    {
        List<T> GetAll();

        T Get(string id);
    }
}
