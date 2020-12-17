# Burst.Delegates

A set of Burst-compatible struct APIs to use instead of C# delegates.

## Examples

Here are a couple examples showcasing how to write struct-based delegates

### Creating Delegates

Delegate:
```cs
Func<int, int, bool> greaterThan = (int a, int b) => a > b;
```

Value Delegate:
```cs
public struct GreaterThanFunc : IFunc<int, int, bool>
{
  public bool Invoke(int a, int b) => a > b;
}

var greaterThan = ValueFunc<int, int, bool>.New<GreaterThanFunc>();
```

Burst Delegate:
```cs
[BurstCompile]
public static bool GreaterThan(int a, int b) => a > b;

BurstFunc<int, int, bool> greaterThan = BurstFunc<int, int, bool>.Compile(GreaterThan);
```

### Referencing Delegates

System.Delegate:
```cs
public class MyClass
{
  public static List<int> CompareNextVal(List<int> vals, Func<int, int, int> comparer)
  {
    // ...
  }
}
```

Value Delegate:
```cs
public class MyClass
{
  public static List<int> CompareNextVal<TComparer>(List<int> vals, ValueFunc<int, int, int>.Struct<TComparer> comparer)
  {
    // ...
  }
}
```

Burst Delegate:
```cs
public class MyClass
{
  public static List<int> CompareNextVal(List<int> vals, BurstFunc<int, int, int> comparer)
  {
    // ...
  }
}
```

### Usage in a Job

```cs
public struct AggregateJob<TAggregator> : IJob
  where TAggregator : struct, IFunc<int, int, int>
{
  public ValueFunc<int, int, int>.Struct<TAggregator> Aggregator;
  public NativeArray<int> Input;
  public NativeArray<int> Output;

  public void Execute()
  {
    for (var i = 0; i < Input.Length; i++)
      Output[0] = Aggregator.Invoke(Input[i], Output[0]);
  }
}

[BurstCompile]
public class MyClass
{
  [BurstCompile]
  public static int Sum(int a, int b) => a + b;

  public static readonly BurstFunc<int, int, int> SumFunc = BurstFunc<int, int, int>.Compile(Sum);

  public static int SumSomeNumbers(int[] numbers)
  {
    using(var input = new NativeArray<int>(numbers, Allocator.Persistent))
    using(var output = new NativeArray<int>(1, Allocator.Persistent))
    {
      var job = new AggregateJob<BurstFunc<int, int, int>>
      {
        Aggregator = SumFunc, // BurstFunc has an implicit operator to ValueFunc
        Input = input,
        Output = output
      };
      job.Run();
      return output[0];
    }
  }
}
```
