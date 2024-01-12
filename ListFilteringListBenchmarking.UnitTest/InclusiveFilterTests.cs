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
        public void Where_Any_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.Where_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_Any_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.Where_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_Any_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.Where_Any(ids, customers);

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

            var result = _inclusiveFilterBenchmarks.Where_Any(ids, customers);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
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

            var result = _inclusiveFilterBenchmarks.Where_Any(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
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

            var result = _inclusiveFilterBenchmarks.Where_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _inclusiveFilterBenchmarks.Where_Any(ids, customers);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
            Assert.IsTrue(result[2].Id == 3);
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

            var result = _inclusiveFilterBenchmarks.Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_Contains_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_Contains_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.Where_Contains(ids, customers);

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

            var result = _inclusiveFilterBenchmarks.Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
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

            var result = _inclusiveFilterBenchmarks.Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
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

            var result = _inclusiveFilterBenchmarks.Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _inclusiveFilterBenchmarks.Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
            Assert.IsTrue(result[2].Id == 3);
        }

        [TestMethod]
        public void Join_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.Join(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Join_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.Join(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Join_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.Join(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Join_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.Join(ids, customers);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
        }

        [TestMethod]
        public void Join_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _inclusiveFilterBenchmarks.Join(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
        }

        [TestMethod]
        public void Join_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.Join(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Join_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _inclusiveFilterBenchmarks.Join(ids, customers);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
            Assert.IsTrue(result[2].Id == 3);
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

            var result = _inclusiveFilterBenchmarks.FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FindAll_Contains_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FindAll_Contains_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.FindAll_Contains(ids, customers);

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

            var result = _inclusiveFilterBenchmarks.FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
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

            var result = _inclusiveFilterBenchmarks.FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
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

            var result = _inclusiveFilterBenchmarks.FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _inclusiveFilterBenchmarks.FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
            Assert.IsTrue(result[2].Id == 3);
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

            var result = _inclusiveFilterBenchmarks.FindAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FindAll_Any_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.FindAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FindAll_Any_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.FindAll_Any(ids, customers);

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

            var result = _inclusiveFilterBenchmarks.FindAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
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

            var result = _inclusiveFilterBenchmarks.FindAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
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

            var result = _inclusiveFilterBenchmarks.FindAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _inclusiveFilterBenchmarks.FindAll_Any(ids, customers);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
            Assert.IsTrue(result[2].Id == 3);
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

            var result = _inclusiveFilterBenchmarks.HashSet_Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSet_Where_Contains_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.HashSet_Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSet_Where_Contains_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.HashSet_Where_Contains(ids, customers);

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

            var result = _inclusiveFilterBenchmarks.HashSet_Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
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

            var result = _inclusiveFilterBenchmarks.HashSet_Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
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

            var result = _inclusiveFilterBenchmarks.HashSet_Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _inclusiveFilterBenchmarks.HashSet_Where_Contains(ids, customers);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
            Assert.IsTrue(result[2].Id == 3);
        }

        [TestMethod]
        public void HashSet_FindAll_Contains_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.HashSet_FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSet_FindAll_Contains_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.HashSet_FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSet_FindAll_Contains_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.HashSet_FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSet_FindAll_Contains_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.HashSet_FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
        }

        [TestMethod]
        public void HashSet_FindAll_Contains_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _inclusiveFilterBenchmarks.HashSet_FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
        }

        [TestMethod]
        public void HashSet_FindAll_Contains_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.HashSet_FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void HashSet_FindAll_Contains_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _inclusiveFilterBenchmarks.HashSet_FindAll_Contains(ids, customers);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
            Assert.IsTrue(result[2].Id == 3);
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

            var result = _inclusiveFilterBenchmarks.Where_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_BinarySearch_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.Where_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Where_BinarySearch_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.Where_BinarySearch(ids, customers);

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

            var result = _inclusiveFilterBenchmarks.Where_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
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

            var result = _inclusiveFilterBenchmarks.Where_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
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

            var result = _inclusiveFilterBenchmarks.Where_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
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

            var result = _inclusiveFilterBenchmarks.Where_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
            Assert.IsTrue(result[2].Id == 3);
        }

        [TestMethod]
        public void FindAll_BinarySearch_EmptyIds()
        {
            var ids = Enumerable.Empty<int>().ToList();
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.FindAll_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FindAll_BinarySearch_EmptyCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.FindAll_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FindAll_BinarySearch_EmptyIdsAndCustomers()
        {
            var ids = new List<int>();
            var customers = new List<Customer>();

            var result = _inclusiveFilterBenchmarks.FindAll_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FindAll_BinarySearch_SmallerIdCount()
        {
            var ids = new List<int> { 1 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.FindAll_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
        }

        [TestMethod]
        public void FindAll_BinarySearch_LargerIdCount()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
            };

            var result = _inclusiveFilterBenchmarks.FindAll_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
        }

        [TestMethod]
        public void FindAll_BinarySearch_NoIdsMatchCustomers()
        {
            var ids = new List<int> { 4, 5, 6 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 }
            };

            var result = _inclusiveFilterBenchmarks.FindAll_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void FindAll_BinarySearch_AllIdsMatchCustomers()
        {
            var ids = new List<int> { 1, 2, 3 };
            var customers = new List<Customer>
            {
                new() { Id = 1 },
                new() { Id = 2 },
                new() { Id = 3 },
            };

            var result = _inclusiveFilterBenchmarks.FindAll_BinarySearch(ids, customers);

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0].Id == 1);
            Assert.IsTrue(result[1].Id == 2);
            Assert.IsTrue(result[2].Id == 3);
        }
    }
}