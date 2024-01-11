using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListFilteringListBenchmarking.UnitTest
{
    [TestClass]
    public class ExclusiveFilterTests
    {
        private readonly ExclusiveFilterBenchmarks _exclusiveFilterBenchmarks;
        public ExclusiveFilterTests()
        {
            _exclusiveFilterBenchmarks = new ExclusiveFilterBenchmarks();
        }

        [TestMethod]
        public void LinqExceptBy_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.LinqExceptBy(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void LinqExceptBy_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.LinqExceptBy(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqExceptBy_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.LinqExceptBy(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqExceptBy_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.LinqExceptBy(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
        }

        [TestMethod]
        public void LinqExceptBy_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _exclusiveFilterBenchmarks.LinqExceptBy(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqExceptBy_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.LinqExceptBy(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void LinqExceptBy_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _exclusiveFilterBenchmarks.LinqExceptBy(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAllAny_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.RemoveAllAny(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void RemoveAllAny_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.RemoveAllAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAllAny_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.RemoveAllAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAllAny_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.RemoveAllAny(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
        }

        [TestMethod]
        public void RemoveAllAny_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _exclusiveFilterBenchmarks.RemoveAllAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAllAny_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.RemoveAllAny(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void RemoveAllAny_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _exclusiveFilterBenchmarks.RemoveAllAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAllContains_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.RemoveAllContains(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void RemoveAllContains_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.RemoveAllContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAllContains_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.RemoveAllContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAllContains_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.RemoveAllContains(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
        }

        [TestMethod]
        public void RemoveAllContains_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _exclusiveFilterBenchmarks.RemoveAllContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAllContains_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.RemoveAllContains(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void RemoveAllContains_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _exclusiveFilterBenchmarks.RemoveAllContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _exclusiveFilterBenchmarks.LinqAny(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void LinqAny_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.LinqAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqAny_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.LinqAny(ids, customers);

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

            var result = _exclusiveFilterBenchmarks.LinqAny(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
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

            var result = _exclusiveFilterBenchmarks.LinqAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _exclusiveFilterBenchmarks.LinqAny(ids, customers);

            Assert.IsTrue(result.Count == 3);
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

            var result = _exclusiveFilterBenchmarks.LinqAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _exclusiveFilterBenchmarks.LinqContains(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void LinqContains_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.LinqContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqContains_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.LinqContains(ids, customers);

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

            var result = _exclusiveFilterBenchmarks.LinqContains(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
        }

        [TestMethod]
        public void LinqContainsy_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _exclusiveFilterBenchmarks.LinqContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _exclusiveFilterBenchmarks.LinqContains(ids, customers);

            Assert.IsTrue(result.Count == 3);
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

            var result = _exclusiveFilterBenchmarks.LinqContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _exclusiveFilterBenchmarks.LinqFindAllContains(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void LinqFindAllContains_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.LinqFindAllContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqFindAllContains_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.LinqFindAllContains(ids, customers);

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

            var result = _exclusiveFilterBenchmarks.LinqFindAllContains(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
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

            var result = _exclusiveFilterBenchmarks.LinqFindAllContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _exclusiveFilterBenchmarks.LinqFindAllContains(ids, customers);

            Assert.IsTrue(result.Count == 3);
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

            var result = _exclusiveFilterBenchmarks.LinqFindAllContains(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _exclusiveFilterBenchmarks.LinqFindAllAny(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void LinqFindAllAny_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.LinqFindAllAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void LinqFindAllAny_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.LinqFindAllAny(ids, customers);

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

            var result = _exclusiveFilterBenchmarks.LinqFindAllAny(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
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

            var result = _exclusiveFilterBenchmarks.LinqFindAllAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _exclusiveFilterBenchmarks.LinqFindAllAny(ids, customers);

            Assert.IsTrue(result.Count == 3);
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

            var result = _exclusiveFilterBenchmarks.LinqFindAllAny(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _exclusiveFilterBenchmarks.HashSetLinq(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void HashSetLinq_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.HashSetLinq(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSetLinq_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.HashSetLinq(ids, customers);

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

            var result = _exclusiveFilterBenchmarks.HashSetLinq(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
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

            var result = _exclusiveFilterBenchmarks.HashSetLinq(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _exclusiveFilterBenchmarks.HashSetLinq(ids, customers);

            Assert.IsTrue(result.Count == 3);
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

            var result = _exclusiveFilterBenchmarks.HashSetLinq(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _exclusiveFilterBenchmarks.BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void BinarySearch_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void BinarySearch_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.BinarySearch(ids, customers);

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

            var result = _exclusiveFilterBenchmarks.BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
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

            var result = _exclusiveFilterBenchmarks.BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _exclusiveFilterBenchmarks.BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 3);
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

            var result = _exclusiveFilterBenchmarks.BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void ExceptBy_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.ExceptBy(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void ExceptBy_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.ExceptBy(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void ExceptBy_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.ExceptBy(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void ExceptBy_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.ExceptBy(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
        }

        [TestMethod]
        public void ExceptBy_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _exclusiveFilterBenchmarks.ExceptBy(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void ExceptBy_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.ExceptBy(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void ExceptBy_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _exclusiveFilterBenchmarks.ExceptBy(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }
    }
}
