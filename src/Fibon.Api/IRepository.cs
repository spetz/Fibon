using System.Collections.Generic;

namespace Fibon.Api
{
    public interface IRepository
    {
        int? Get(int number);
        void Insert(int number, int result);
    }

    public class InMemoryRepository : IRepository
    {
        private readonly Dictionary<int, int> _results = new Dictionary<int, int>();

        public int? Get(int number)
        {
            int result;
            if (_results.TryGetValue(number, out result))
            {
                return result;
            }

            return null;
        }

        public void Insert(int number, int result)
        {
            _results[number] = result;
        }
    }
}