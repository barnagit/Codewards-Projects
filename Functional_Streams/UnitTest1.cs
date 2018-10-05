using System;
using Xunit;
using System.Linq;

namespace Functional_Streams
{

  public class ConstructorTests
  {
    [Fact]
    public void Repeat()
    {
      var v = new Random().Next();
      var s = Stream.Repeat(v);
      for (var i = 0; i < 100; i++)
      {
        Assert.Equal(v, s.Head);//, "iterate with exponentiation of integers");
        s = s.Tail.Value;
      }
    }

    [Fact]
    public void Iterate()
    {
      long multiplier = new Random().Next(9);
      Func<long, long> multiply = x => x * multiplier;
      long multiplied = multiplier;
      var expStream = Stream.Iterate(multiply, multiplied);

      Func<string, string> concatenate = x => x + " ";
      var concatenated = "";
      var addWSStream = Stream.Iterate(concatenate, concatenated);

      for (var i = 0; i < 10; i++)
      {
        Assert.Equal(multiplied, expStream.Head);//, "iterate with exponentiation of integers");
        expStream = expStream.Tail.Value;
        multiplied = multiply(multiplied);

        Assert.Equal(concatenated, addWSStream.Head);//, "iterate with adding whitespaces");
        addWSStream = addWSStream.Tail.Value;
        concatenated = concatenate(concatenated);
      }
    }

    [Fact]
    public void Cycle()
    {
      var r = new Random();
      var a = Enumerable.Range(0, 20).Select(i => r.Next()).ToArray();
      var s = Stream.Cycle(a);
      for (var i = 0; i < 100; i++)
      {
        Assert.Equal(a[i % a.Length], s.Head);//, "cycle should repeat the enumerable");
        s = s.Tail.Value;
      }
    }

    [Fact]
    public void From()
    {
      var v = new Random().Next();
      var s = Stream.From(v);
      for (var i = v; i < v + 100; i++)
      {
        Assert.Equal(i, s.Head);//, "from should count");
        s = s.Tail.Value;
      }
    }

    [Fact]
    public void FromThen()
    {
      var r = new Random();
      var v = r.Next();
      var d = r.Next(200);
      var s = Stream.FromThen(v, d);
      for (var i = v; i < v + 100 * d; i += d)
      {
        Assert.Equal(i, s.Head);//, "fromThen should count by step");
        s = s.Tail.Value;
      }
    }
  }

  public class ReductionAndModificationTests
  {
    [Fact]
    public void Foldr()
    {
      var v = new Random().Next();
      var a = Stream.Repeat(v).Foldr<int,Stream<int>>((x, r) => Stream.Cons(x + 1, () => r())).Take(10).ToArray();
      for (var i = 0; i < 10; i++)
      {
        Assert.Equal(a[i], v+1);//, "folding should work, with lazy tail");
      }
    }

    [Fact]
    public void Filter()
    {
      var v = new Random().Next();
      var a = Stream.From(v).Filter(x => x % 2 == 0).Take(10).ToArray();
      foreach (var i in a)
      {
        Assert.Equal(0, i % 2);//, "filtering odds with Filter");
      }
    }

    [Fact]
    public void Take()
    {
      var s = Stream.From(0);
      for (var i = -2; i <= 2; i++)
      {
        Assert.Equal(Math.Max(0, i), s.Take(i).Count());//, "Take should get the correct size");
      }
    }

    [Fact]
    public void Drop()
    {
      var s = Stream.From(0);
      for (var i = -2; i <= 2; i++)
      {
        Assert.Equal(Math.Max(0, i), s.Drop(i).Head);//, "Drop should drop the correct amount");
      }
    }

    [Fact]
    public void ZipWith()
    {
      var s = Stream.From(0).ZipWith((x, y) => x * 2 + y, Stream.Repeat(42));
      var t = Stream.FromThen(42, 2);

      for (var i = 0; i < 20; i++)
      {
        Assert.Equal(t.Head, s.Head);//, "ZipWith should work");
        s = s.Tail.Value;
        t = t.Tail.Value;
      }
    }

    [Fact]
    public void FMap()
    {
      var s = Stream.FromThen(42, 2).FMap(x => (x - 42) / 2);
      var t = Stream.From(0);

      for (var i = 0; i < 20; i++)
      {
        Assert.Equal(t.Head, s.Head);//, "FMap should work");
        s = s.Tail.Value;
        t = t.Tail.Value;
      }
    }

    [Fact]
    public void Fib() {
      // 0 1 1 2 3 5 8 13 21 34
      var s = Stream.Fib().Take(10).ToArray();
      int p1 =0;
      int p2 =1;
      int t =0;
      for (int i = 2; i < s.Length; i++)
      {
        Assert.Equal(s[i], p1+p2);
        t = p1;
        p1 = p2;
        p2 += t;
      }
    }
  }
}
