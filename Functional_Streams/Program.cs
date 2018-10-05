using System;
using System.Collections.Generic;

namespace Functional_Streams
{
    
/*
    A Stream is an infinite sequence of items. It is defined recursively
    as a head item followed by the tail, which is another stream.
    Consequently, the tail has to be wrapped with Lazy to prevent
    evaluation.
*/
public class Stream<T>
{
  public readonly T Head;
  public readonly Lazy<Stream<T>> Tail;

  public Stream(T head, Lazy<Stream<T>> tail)
  {
    Head = head;
    Tail = tail;
  }
}

static class Stream
{
  /*
      Your first task is to define a utility function which constructs a
      Stream given a head and a function returning a tail.
  */
  public static Stream<T> Cons<T>(T h, Func<Stream<T>> t)
  {
      return new Stream<T>(h, new Lazy<Stream<T>>(t));
  }

  // .------------------------------.
  // | Static constructor functions |
  // '------------------------------'

  // Construct a stream by repeating a value.
  public static Stream<T> Repeat<T>(T x)
  {      
      return Cons(x,()=>Repeat(x));
  }

  // Construct a stream by repeatedly applying a function.
  public static Stream<T> Iterate<T>(Func<T, T> f, T x)
  {
      return  Cons(x,()=>Iterate(f,f(x)));
  }

  // Construct a stream by repeating an enumeration forever.
  public static Stream<T> Cycle<T>(IEnumerable<T> a)
  {
      IEnumerator<T> e = a.GetEnumerator();
      e.MoveNext();
      return Cons(e.Current,()=>Cycle(e));
  }
  private static Stream<T> Cycle<T>(IEnumerator<T> e)
  {
    if (e.MoveNext()) return Cons(e.Current,()=>Cycle(e));
    else {
        e.Reset();
        e.MoveNext();
        return Cons(e.Current,()=>Cycle(e));
    }
  }

  // Construct a stream by counting numbers starting from a given one.
  public static Stream<int> From(int x)
  {
      return Cons(x,()=>From(x+1));
  }
  
  // Same as From but count with a given step width.
  public static Stream<int> FromThen(int x, int d)
  {
      return Cons(x,()=>FromThen(x+d,d));
  }

  // .------------------------------------------.
  // | Stream reduction and modification (pure) |
  // '------------------------------------------'

  /*
      Being applied to a stream (x1, x2, x3, ...), Foldr shall return
      f(x1, f(x2, f(x3, ...))). Foldr is a right-associative fold.
      Thus applications of f are nested to the right.
  */
  public static U Foldr<T,U>(this Stream<T> s, Func<T, Func<U>, U> f)
  {
    return f(s.Head,()=>Foldr(s.Tail.Value,f));
  }

  // Filter stream with a predicate function.
  public static Stream<T> Filter<T>(this Stream<T> s, Predicate<T> p)
  {
    while (!p(s.Head)) {
      s = s.Tail.Value;
    }
    return Cons(s.Head,()=>s.Tail.Value.Filter(p));
  }

  // Returns a given amount of elements from the stream.
  public static IEnumerable<T> Take<T>(this Stream<T> s, int n)
  {
      if (s.Head == null || n < 1) return new T[0];
      T[] a = new T[n];
      Stream<T> ss = s;
      for (int i = 0; i < n; i++) {
        a[i]=ss.Head;
        ss=ss.Tail.Value;
      }
      return a;
  }

  // Drop a given amount of elements from the stream.
  public static Stream<T> Drop<T>(this Stream<T> s, int n)
  {
    for (int i = 0; i < n; i++) {
      if (s.Tail != null)
        s = s.Tail.Value;
      else return null;
    }
    return s;
  }

  // Combine 2 streams with a function.
  public static Stream<R> ZipWith<T, U, R>(this Stream<T> s, Func<T, U, R> f, Stream<U> other)
  {
    return Cons(f(s.Head,other.Head),()=>ZipWith(s.Tail.Value,f,other.Tail.Value));
  }

  // Map every value of the stream with a function, returning a new stream.
  public static Stream<U> FMap<T, U>(this Stream<T> s, Func<T, U> f)
  {
    return Cons(f(s.Head),()=>FMap(s.Tail.Value,f));
  }

  // Return the stream of all fibonacci numbers.
  // 0 1 1 2 3 5 8 13 21 34
  public static Stream<int> Fib()
  {
    return Cons(0,()=>Cons(1,()=>FHelper(0,1)));
  }

  private static Stream<int> FHelper(int a, int b)
  {
    return Cons(a+b , ()=> FHelper(b, a+b));
  }

  // Return the stream of all prime numbers.
  public static Stream<int> Primes()
  {
    return Cons(2,()=>FromThen(3,2).Filter((p)=>IsPrime(p)));
  }

  private static bool IsPrime(int oddNumber)
  {
    // not needed given the usage
    /*
    if ((number & 1) == 0)
    {
      return (number == 2);
    }
    */

    int limit = (int) Math.Sqrt(oddNumber);

    for (int i = 3; i <= limit; i += 2)
    {
      if ((oddNumber % i) == 0)
      {
        return false;
      }
    }
    return true;
  }

}
}
