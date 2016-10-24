using System.Collections;
using ActivitiDotNet.Base;

namespace ActivitiDotNet.Collection
{
    public interface IInfoObjectCollection<T> 
    {
        void Add(T info);

        void Remove(T info);

        void Remove(int index);

        void RemoveAll();

        void Insert(int index, T info);


    }
}
