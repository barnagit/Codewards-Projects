using System;
using System.Collections.Generic;

namespace Functional_Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    
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
    throw new NotImplementedException();
  }

  // .------------------------------.
  // | Static constructor functions |
  // '------------------------------'

  // Construct a stream by repeating a value.
  public static Stream<T> Repeat<T>(T x)
  {
    throw new NotImplementedException();
  }

  // Construct a stream by repeatedly applying a function.
  public static Stream<T> Iterate<T>(Func<T, T> f, T x)
  {
    throw new NotImplementedException();
  }

  // Construct a stream by repeating an enumeration forever.
  public static Stream<T> Cycle<T>(IEnumerable<T> a)
  {
    throw new NotImplementedException();
  }

  // Construct a stream by counting numbers starting from a given one.
  public static Stream<int> From(int x)
  {
    throw new NotImplementedException();
  }
  
  // Same as From but count with a given step width.
  public static Stream<int> FromThen(int x, int d)
  {
    throw new NotImplementedException();
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
    throw new NotImplementedException();
  }

  // Filter stream with a predicate function.
  public static Stream<T> Filter<T>(this Stream<T> s, Predicate<T> p)
  {
    throw new NotImplementedException();
  }

  // Returns a given amount of elements from the stream.
  public static IEnumerable<T> Take<T>(this Stream<T> s, int n)
  {
    throw new NotImplementedException();
  }

  // Drop a given amount of elements from the stream.
  public static Stream<T> Drop<T>(this Stream<T> s, int n)
  {
    throw new NotImplementedException();
  }

  // Combine 2 streams with a function.
  public static Stream<R> ZipWith<T, U, R>(this Stream<T> s, Func<T, U, R> f, Stream<U> other)
  {
    throw new NotImplementedException();
  }

  // Map every value of the stream with a function, returning a new stream.
  public static Stream<U> FMap<T, U>(this Stream<T> s, Func<T, U> f)
  {
    throw new NotImplementedException();
  }

  // Return the stream of all fibonacci numbers.
  public static Stream<int> Fib()
  {
    throw new NotImplementedException();
  }

  // Return the stream of all prime numbers.
  public static Stream<int> Primes()
  {
    throw new NotImplementedException();
  }
}
}
