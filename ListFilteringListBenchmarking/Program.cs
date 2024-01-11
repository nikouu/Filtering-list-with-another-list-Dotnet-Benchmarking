using BenchmarkDotNet.Running;



BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

//var g = new ExclusiveFilterBenchmarks().RemoveAllAny();
//var f = new ExclusiveFilterBenchmarks().RemoveAllContains();

//var results = new List<List<Customer>>
//{
//    new InclusiveFilterBenchmarks().ForEach(),
//    new InclusiveFilterBenchmarks().LinqAny(),
//    new InclusiveFilterBenchmarks().LinqContains(),
//    new InclusiveFilterBenchmarks().LinqJoin(),
//    new InclusiveFilterBenchmarks().LinqFindAllContains(),
//    new InclusiveFilterBenchmarks().LinqFindAllAny(),
//    new InclusiveFilterBenchmarks().HashSetLinq()
//};

//Console.Read();

//new ExclusiveFilterBenchmarks().ForRemoveAt();

//var results = new List<List<Customer>>
//{
//    new ExclusiveFilterBenchmarks().ForRemoveAt(),
//    new ExclusiveFilterBenchmarks().LinqExceptBy(),
//    new ExclusiveFilterBenchmarks().RemoveAll(),
//    new ExclusiveFilterBenchmarks().LinqAny(),
//    new ExclusiveFilterBenchmarks().LinqContains(),
//    new ExclusiveFilterBenchmarks().LinqFindAllContains(),
//    new ExclusiveFilterBenchmarks().LinqFindAllAny(),
//    new ExclusiveFilterBenchmarks().HashSetLinq(),
//    new ExclusiveFilterBenchmarks().BinarySearch(),

//};

//Console.Read();