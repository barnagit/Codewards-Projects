using System;
using Xunit;
using Path_Finder_1.Src;

namespace Path_Finder_1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            string a =  ".W.\n" +
                        ".W.\n" +
                        "...";

            Assert.Equal(true, Finder.PathFinder(a));
        }

        [Fact]
        public void Test2() {

            string  b = ".W.\n" +
                        ".W.\n" +
                        "W..";

            Assert.Equal(false, Finder.PathFinder(b));
        }

        [Fact]
        public void Test3() {
            string  c = "......\n" +
                        "......\n" +
                        "......\n" +
                        "......\n" +
                        "......\n" +
                        "......";
            
            Assert.Equal(true, Finder.PathFinder(c));
        }

        [Fact]
        public void Test4() {

            string d =  "......\n" +
                        "......\n" +
                        "......\n" +
                        "......\n" +
                        ".....W\n" +
                        "....W.";

            Assert.Equal(false, Finder.PathFinder(d));
        }
    }
}
