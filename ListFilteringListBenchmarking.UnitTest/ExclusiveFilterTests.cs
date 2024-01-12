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

        [TestMethod]
        public void RemoveAll_Any_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.RemoveAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void RemoveAll_Any_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.RemoveAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAll_Any_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.RemoveAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAll_Any_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.RemoveAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
        }

        [TestMethod]
        public void RemoveAll_Any_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _exclusiveFilterBenchmarks.RemoveAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAll_Any_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.RemoveAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void RemoveAll_Any_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _exclusiveFilterBenchmarks.RemoveAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAll_Contains_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.RemoveAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void RemoveAll_Contains_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.RemoveAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAll_Contains_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.RemoveAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAll_Contains_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.RemoveAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
        }

        [TestMethod]
        public void RemoveAll_Contains_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _exclusiveFilterBenchmarks.RemoveAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAll_Contains_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.RemoveAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void RemoveAll_Contains_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _exclusiveFilterBenchmarks.RemoveAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_Any_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.Where_Any(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void Where_Any_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.Where_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_Any_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.Where_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_Any_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.Where_Any(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
        }

        [TestMethod]
        public void Where_Any_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _exclusiveFilterBenchmarks.Where_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_Any_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.Where_Any(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void Where_Any_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _exclusiveFilterBenchmarks.Where_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_Contains_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void Where_Contains_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_Contains_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_Contains_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
        }

        [TestMethod]
        public void Where_Contains_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _exclusiveFilterBenchmarks.Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_Contains_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void Where_Contains_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _exclusiveFilterBenchmarks.Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FindAll_Contains_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void FindAll_Contains_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FindAll_Contains_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FindAll_Contains_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
        }

        [TestMethod]
        public void FindAll_Contains_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _exclusiveFilterBenchmarks.FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FindAll_Contains_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void FindAll_Contains_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _exclusiveFilterBenchmarks.FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FindAll_Any_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.FindAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void FindAll_Any_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.FindAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FindAll_Any_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.FindAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FindAll_Any_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.FindAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
        }

        [TestMethod]
        public void FindAll_Any_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _exclusiveFilterBenchmarks.FindAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FindAll_Any_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.FindAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void FindAll_Any_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _exclusiveFilterBenchmarks.FindAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSet_Where_Contains_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.HashSet_Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void HashSet_Where_Contains_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.HashSet_Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSet_Where_Contains_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.HashSet_Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSet_Where_Contains_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.HashSet_Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
        }

        [TestMethod]
        public void HashSet_Where_Contains_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _exclusiveFilterBenchmarks.HashSet_Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSet_Where_Contains_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.HashSet_Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void HashSet_Where_Contains_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _exclusiveFilterBenchmarks.HashSet_Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSet_RemoveAll_Contains_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.HashSet_RemoveAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void HashSet_RemoveAll_Contains_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.HashSet_RemoveAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSet_RemoveAll_Contains_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.HashSet_RemoveAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSet_RemoveAll_Contains_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.HashSet_RemoveAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
        }

        [TestMethod]
        public void HashSet_RemoveAll_Contains_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _exclusiveFilterBenchmarks.HashSet_RemoveAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSet_RemoveAll_Contains_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.HashSet_RemoveAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void HashSet_RemoveAll_Contains_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _exclusiveFilterBenchmarks.HashSet_RemoveAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_BinarySearch_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.Where_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void Where_BinarySearch_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.Where_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_BinarySearch_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.Where_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_BinarySearch_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.Where_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
        }

        [TestMethod]
        public void Where_BinarySearch_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _exclusiveFilterBenchmarks.Where_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_BinarySearch_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.Where_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void Where_BinarySearch_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _exclusiveFilterBenchmarks.Where_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAll_BinarySearch_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.RemoveAll_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void RemoveAll_BinarySearch_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.RemoveAll_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAll_BinarySearch_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _exclusiveFilterBenchmarks.RemoveAll_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAll_BinarySearch_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.RemoveAll_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 2);
            Assert.IsTrue(result[1].Id == 3);
        }

        [TestMethod]
        public void RemoveAll_BinarySearch_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _exclusiveFilterBenchmarks.RemoveAll_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void RemoveAll_BinarySearch_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _exclusiveFilterBenchmarks.RemoveAll_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void RemoveAll_BinarySearch_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _exclusiveFilterBenchmarks.RemoveAll_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }
    }
}
