using BenchmarkDotNet.Attributes;

namespace ListFilteringListBenchmarking
{
    [MemoryDiagnoser]
    [ReturnValueValidator(failOnError: true)]
    public class InclusiveFilterBenchmarks
    {
        private List<int> _ids;
        private List<Customer> _customers;

#if DEBUG
        public InclusiveFilterBenchmarks()
        {
            Setup();
        }
#endif

        [GlobalSetup]
        public void Setup()
        {
            _ids = Enumerable.Range(1, 100).Select(x => x).ToList();
            _customers = Enumerable.Range(1, 1000).Select(x => new Customer { Id = x }).ToList();
        }

        [Benchmark(Baseline = true)]
        public List<Customer> ForEach()
        {
            var returnList = new List<Customer>();
            foreach (var customer in _customers)
            {
                foreach (var id in _ids)
                {
                    if (customer.Id == id)
                    {
                        returnList.Add(customer);
                    }
                }
            }

            return returnList;
        }

        [Benchmark]
        public List<Customer> LinqAny()
        {
            return _customers.Where(customer => _ids.Any(id => customer.Id == id)).ToList();
        }

        [Benchmark]
        public List<Customer> LinqContains()
        {
            return _customers.Where(c => _ids.Contains(c.Id)).ToList();
        }

        [Benchmark]
        public List<Customer> LinqJoin()
        {
            return (from c in _customers
                    join i in _ids on c.Id equals i
                    select c).ToList();
        }

        [Benchmark]
        public List<Customer> LinqFindAllContains()
        {
            return _customers.FindAll(c => _ids.Contains(c.Id));
        }


        [Benchmark]
        public List<Customer> LinqFindAllAny()
        {
            return _customers.FindAll(c => _ids.Any(i => i == c.Id));
        }

        [Benchmark]
        public List<Customer> HashSetLinq()
        {
            var idSet = new HashSet<int>(_ids);
            return _customers.Where(c => idSet.Contains(c.Id)).ToList();
        }

        [Benchmark]
        public List<Customer> BinarySearch()
        {
            _ids.Sort();
            return _customers.Where(c => _ids.BinarySearch(c.Id) >= 0).ToList();
        }
    }   
}
  
