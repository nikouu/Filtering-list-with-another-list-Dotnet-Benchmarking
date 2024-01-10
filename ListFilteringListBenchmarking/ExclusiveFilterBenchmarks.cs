using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListFilteringListBenchmarking
{
    [MemoryDiagnoser]
    [ReturnValueValidator(failOnError: true)]
    public class ExclusiveFilterBenchmarks
    {
        private List<int> _ids;
        private List<Customer> _customers;

#if DEBUG
        public ExclusiveFilterBenchmarks()
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

        [IterationSetup(Targets = [nameof(ForRemoveAt), nameof(RemoveAll), nameof(BinarySearch)])]
        public void SetupMutativeBenchmarks() => Setup();

        [Benchmark(Baseline = true)]
        public List<Customer> ForRemoveAt()
        {
            for (int i = _customers.Count - 1; i >= 0; i--)
            {
                if (_ids.Contains(_customers[i].Id))
                {
                    _customers.RemoveAt(i);
                }
            }

            return _customers;
        }

        [Benchmark]
        public List<Customer> LinqExceptBy()
        {
            return _customers.ExceptBy(_ids.Select(x => x), c => c.Id).ToList();
        }

        [Benchmark]
        public List<Customer> RemoveAll()
        {
            _customers.RemoveAll(c => _ids.Any(i => i == c.Id));
            return _customers;
        }       


        [Benchmark]
        public List<Customer> LinqAny()
        {
            return _customers.Where(customer => !_ids.Any(id => customer.Id == id)).ToList();
        }

        [Benchmark]
        public List<Customer> LinqContains()
        {
            return _customers.Where(c => !_ids.Contains(c.Id)).ToList();
        }

        [Benchmark]
        public List<Customer> LinqFindAllContains()
        {
            return _customers.FindAll(c => !_ids.Contains(c.Id));
        }

        [Benchmark]
        public List<Customer> LinqFindAllAny()
        {
            return _customers.FindAll(c => !_ids.Any(i => i == c.Id));
        }


        [Benchmark]
        public List<Customer> HashSetLinq()
        {
            var idSet = new HashSet<int>(_ids);
            return _customers.Where(c => !idSet.Contains(c.Id)).ToList();
        }

        [Benchmark]
        public List<Customer> BinarySearch()
        {
            _ids.Sort();
            _customers.RemoveAll(c => _ids.BinarySearch(c.Id) >= 0);

            return _customers;
        }
    }
}
