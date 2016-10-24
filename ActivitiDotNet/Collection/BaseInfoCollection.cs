using System.Collections;
using System.Linq;

using ActivitiDotNet.Abstract;

namespace ActivitiDotNet.Collection
{
    public class BaseInfoCollection<T> : CollectionBase where T : class
    {
        BaseInfoProvider<T> provider;
        private string baseUrl;

        public BaseInfoCollection(string baseUrl)
        {
            this.baseUrl = baseUrl;
            Init();
        }

        private void Init()
        {
            provider = new BaseInfoProvider<T>(baseUrl);
            var objects = provider.GetAll(string.Empty);

            if(objects != null)
            {
                objects.ForEach(x => List.Add(x));
            }
        }

        public T this[int index]
        {
            get
            {
                return List[index] as T;
            }
        }


        public  T Get(int id)
        {
            T retValue = default(T);
            

            foreach(T value in List)
            {
                string valueId = value.GetType().GetProperty("Id").GetValue(value).ToString();

                if (valueId == id.ToString())
                {
                    retValue = value;
                    break;
                }
            }

            return retValue;
        }

        public void Remove(T value)
        {
            provider.Delete(value.GetType().GetProperty("Id").GetValue(value).ToString());
            List.Remove(value);
        }

        public void Remove(int id)
        {
            provider.Delete(id.ToString());
            List.Remove(Get(id));
        }

        public void Add(T info)
        {
            provider.Create(ref info);
            List.Add(info);
        }
    }
}
