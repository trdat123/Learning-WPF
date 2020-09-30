using System.Collections.Generic;

namespace _04_generic_example.Repository
{
    public class BaseRepository<T> : IRepository<T>
    {
        private IList<T> _data;
        public BaseRepository(IList<T> data)
        {
            _data = data;
        }
        public IList<T> GetAll()
        {
            return new List<T>();
        }
        public void Add(T item)
        {
            _data.Add(item);
        }
        public void Remove(T item)
        {
            _data.Remove(item);
        }
    }
}
