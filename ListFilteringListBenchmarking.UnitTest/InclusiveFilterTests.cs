using Newtonsoft.Json.Bson;
using System.Runtime.CompilerServices;

namespace ListFilteringListBenchmarking.UnitTest
{
    [TestClass]
    public class InclusiveFilterTests
    {
        private readonly InclusiveFilterBenchmarks _inclusiveFilterBenchmarks;

        public InclusiveFilterTests()
        {
            _inclusiveFilterBenchmarks = new InclusiveFilterBenchmarks();
        }

        [TestMethod]
        public void ForEach_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.ForEach(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void ForEach_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.ForEach(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void ForEach_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.ForEach(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void ForEach_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.ForEach(ids, customers);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
        }

        [TestMethod]
        public void ForEach_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _inclusiveFilterBenchmarks.ForEach(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
        }

        [TestMethod]
        public void ForEach_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.ForEach(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void ForEach_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _inclusiveFilterBenchmarks.ForEach(ids, customers);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
            Assert.IsTrue(result[2].Id == 3);
        }

        [TestMethod]
        public void LinqAny_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.LinqAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqAny_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.LinqAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqAny_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.LinqAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqAny_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.LinqAny(ids, customers);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
        }

        [TestMethod]
        public void LinqAny_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _inclusiveFilterBenchmarks.LinqAny(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
        }

        [TestMethod]
        public void LinqAny_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.LinqAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqAny_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _inclusiveFilterBenchmarks.LinqAny(ids, customers);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
            Assert.IsTrue(result[2].Id == 3);
        }

        [TestMethod]
        public void LinqContains_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.LinqContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqContains_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.LinqContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqContains_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.LinqContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqContains_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.LinqContains(ids, customers);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
        }

        [TestMethod]
        public void LinqContains_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _inclusiveFilterBenchmarks.LinqContains(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
        }

        [TestMethod]
        public void LinqContains_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.LinqContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqContains_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _inclusiveFilterBenchmarks.LinqContains(ids, customers);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
            Assert.IsTrue(result[2].Id == 3);
        }

        [TestMethod]
        public void LinqJoin_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.LinqJoin(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqJoin_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.LinqJoin(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqJoin_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.LinqJoin(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqJoin_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.LinqJoin(ids, customers);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
        }

        [TestMethod]
        public void LinqJoin_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _inclusiveFilterBenchmarks.LinqJoin(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
        }

        [TestMethod]
        public void LinqJoin_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.LinqJoin(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqJoin_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _inclusiveFilterBenchmarks.LinqJoin(ids, customers);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
            Assert.IsTrue(result[2].Id == 3);
        }

        [TestMethod]
        public void LinqFindAllContains_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.LinqFindAllContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqFindAllContains_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.LinqFindAllContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqFindAllContains_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.LinqFindAllContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqFindAllContains_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.LinqFindAllContains(ids, customers);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
        }

        [TestMethod]
        public void LinqFindAllContains_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _inclusiveFilterBenchmarks.LinqFindAllContains(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
        }

        [TestMethod]
        public void LinqFindAllContains_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.LinqFindAllContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqFindAllContains_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _inclusiveFilterBenchmarks.LinqFindAllContains(ids, customers);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
            Assert.IsTrue(result[2].Id == 3);
        }

        [TestMethod]
        public void LinqFindAllAny_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.LinqFindAllAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqFindAllAny_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.LinqFindAllAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqFindAllAny_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.LinqFindAllAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqFindAllAny_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.LinqFindAllAny(ids, customers);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
        }

        [TestMethod]
        public void LinqFindAllAny_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _inclusiveFilterBenchmarks.LinqFindAllAny(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
        }

        [TestMethod]
        public void LinqFindAllAny_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.LinqFindAllAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqFindAllAny_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _inclusiveFilterBenchmarks.LinqFindAllAny(ids, customers);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
            Assert.IsTrue(result[2].Id == 3);
        }

        [TestMethod]
        public void HashSetLinq_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.HashSetLinq(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSetLinq_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.HashSetLinq(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSetLinq_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.HashSetLinq(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSetLinq_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.HashSetLinq(ids, customers);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
        }

        [TestMethod]
        public void HashSetLinq_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _inclusiveFilterBenchmarks.HashSetLinq(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
        }

        [TestMethod]
        public void HashSetLinq_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.HashSetLinq(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSetLinq_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _inclusiveFilterBenchmarks.HashSetLinq(ids, customers);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
            Assert.IsTrue(result[2].Id == 3);
        }


        [TestMethod]
        public void BinarySearch_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void BinarySearch_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void BinarySearch_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void BinarySearch_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
        }

        [TestMethod]
        public void BinarySearch_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _inclusiveFilterBenchmarks.BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
        }

        [TestMethod]
        public void BinarySearch_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void BinarySearch_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _inclusiveFilterBenchmarks.BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
            Assert.IsTrue(result[2].Id == 3);
        }
    }
}