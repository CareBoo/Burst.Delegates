# Burst.Delegates

A set of Burst-compatible struct APIs to use instead of C# delegates.

## Examples

Here are a couple examples showcasing how to write struct-based delegates

### Creating Delegates

C#:
```cs
Func<int, int, bool> greaterThan = (int a, int b) => a > b;
```

Struct-based:
```cs
public struct GreaterThanFunc : IFunc<int, int, bool>
{
  public bool Invoke(int a, int b) => a > b;
}

var greaterThan = ValueFunc<int, int, bool>.New<GreaterThanFunc>();
```

### Referencing Delegates

C#:
```cs
public class MyClass
{
  public static List<int> CompareNextVal(List<int> vals, Func<int, int, int> comparer)
  {
    // ...
  }
}
```

Struct-based:
```cs
public class MyClass
{
  public static List<int> CompareNextVal<TComparer>(List<int> vals, ValueFunc<int, int, int>.Struct<TComparer> comparer)
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

public class MyClass
{
  struct SumFunc : IFunc<int, int, int>
  {
    public int Invoke(int a, int b) => a + b;
  }

  public static int SumSomeNumbers(int[] numbers)
  {
    using(var input = new NativeArray<int>(numbers, Allocator.Persistent))
    using(var output = new NativeArray<int>(1, Allocator.Persistent))
    {
      var sum = ValueFunc<int, int, int>.New<SumFunc>();
      var job = new AggregateJob<SumFunc> { Aggregator = sum, Input = input, Output = output };
      job.Run();
      return output[0];
    }
  }
}
```
