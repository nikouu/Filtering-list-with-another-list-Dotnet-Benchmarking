﻿using BenchmarkDotNet.Attributes;

namespace ListFilteringListBenchmarking
{
    [MemoryDiagnoser]
    public class ExclusiveFilterBenchmarks
    {
        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public List<Customer> ExceptBy(List<int> ids, List<Customer> customers)
        {
            return customers.ExceptBy(ids, x => x.Id).ToList();
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public List<Customer> RemoveAll_Any(List<int> ids, List<Customer> customers)
        {
            customers.RemoveAll(c => ids.Any(i => i == c.Id));
            return customers;
        }


        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public List<Customer> RemoveAll_Contains(List<int> ids, List<Customer> customers)
        {
            customers.RemoveAll(c => ids.Contains(c.Id));
            return customers;
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public List<Customer> Where_Any(List<int> ids, List<Customer> customers)
        {
            return customers.Where(customer => !ids.Any(id => customer.Id == id)).ToList();
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public List<Customer> Where_Contains(List<int> ids, List<Customer> customers)
        {
            return customers.Where(c => !ids.Contains(c.Id)).ToList();
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public List<Customer> FindAll_Contains(List<int> ids, List<Customer> customers)
        {
            return customers.FindAll(c => !ids.Contains(c.Id));
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public List<Customer> FindAll_Any(List<int> ids, List<Customer> customers)
        {
            return customers.FindAll(c => !ids.Any(i => i == c.Id));
        }


        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public List<Customer> HashSet_Where_Contains(List<int> ids, List<Customer> customers)
        {
            var idSet = new HashSet<int>(ids);
            return customers.Where(c => !idSet.Contains(c.Id)).ToList();
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public List<Customer> HashSet_RemoveAll_Contains(List<int> ids, List<Customer> customers)
        {
            var idSet = new HashSet<int>(ids);
            customers.RemoveAll(c => idSet.Contains(c.Id));

            return customers;
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public List<Customer> Where_BinarySearch(List<int> ids, List<Customer> customers)
        {
            ids.Sort();
            return customers.Where(c => ids.BinarySearch(c.Id) < 0).ToList();
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public List<Customer> RemoveAll_BinarySearch(List<int> ids, List<Customer> customers)
        {
            ids.Sort();
            customers.RemoveAll(c => ids.BinarySearch(c.Id) >= 0);

            return customers;
        }

        public IEnumerable<object[]> Data()
        {
            // Simple case - small
            //yield return new object[] { Enumerable.Range(1, 100).Select(x => x).ToList(), Enumerable.Range(1, 1000).Select(x => new Customer { Id = x }).ToList() };

            // Simple case - medium
            //yield return new object[] { Enumerable.Range(1, 1000).Select(x => x).ToList(), Enumerable.Range(1, 10000).Select(x => new Customer { Id = x }).ToList() };

            //// Simple case - large
            //yield return new object[] { Enumerable.Range(1, 10000).Select(x => x).ToList(), Enumerable.Range(1, 100000).Select(x => new Customer { Id = x }).ToList() };

            // Larger IDs case - small
            //yield return new object[] { Enumerable.Range(1, 1000).Select(x => x).ToList(), Enumerable.Range(1, 100).Select(x => new Customer { Id = x }).ToList() };

            //// Larger IDs case - medium
            //yield return new object[] { Enumerable.Range(1, 10000).Select(x => x).ToList(), Enumerable.Range(1, 1000).Select(x => new Customer { Id = x }).ToList() };

            //// Larger IDs case - large
            //yield return new object[] { Enumerable.Range(1, 100000).Select(x => x).ToList(), Enumerable.Range(1, 10000).Select(x => new Customer { Id = x }).ToList() };

            //// Simple shuffled case - small
            //yield return new object[] { Shuffle(Enumerable.Range(1, 100).Select(x => x).ToList(), 69420), Shuffle(Enumerable.Range(1, 1000).Select(x => new Customer { Id = x }).ToList(), 69420) };

            //// Simple shuffled case - medium
            //yield return new object[] { Shuffle(Enumerable.Range(1, 1000).Select(x => x).ToList(), 69420), Shuffle(Enumerable.Range(1, 10000).Select(x => new Customer { Id = x }).ToList(), 69420) };

            //// Simple shuffled case - large
            yield return new object[] { Shuffle(Enumerable.Range(1, 10000).Select(x => x).ToList(), 69420), Shuffle(Enumerable.Range(1, 100000).Select(x => new Customer { Id = x }).ToList(), 69420) };
        }

        // https://stackoverflow.com/a/42980187
        // Modified terribly to fit case
        private List<T> Shuffle<T>(IList<T> list, int seed)
        {
            var rng = new Random(seed);
            int n = list.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list.ToList();
        }
    }
}
