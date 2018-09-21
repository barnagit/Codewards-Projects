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

            Assert.True(Finder.PathFinder(a));
        }

        [Fact]
        public void Test2() {

            string  b = ".W.\n" +
                        ".W.\n" +
                        "W..";

            Assert.False(Finder.PathFinder(b));
        }

        [Fact]
        public void Test3() {
            string  c = "......\n" +
                        "......\n" +
                        "......\n" +
                        "......\n" +
                        "......\n" +
                        "......";
            
            Assert.True(Finder.PathFinder(c));
        }

        [Fact]
        public void Test4() {

            string d =  "......\n" +
                        "......\n" +
                        "......\n" +
                        "......\n" +
                        ".....W\n" +
                        "....W.";

            Assert.False(Finder.PathFinder(d));
        }

        [Fact]
        public void Test5() {
            string e =  ".W....\n" +
                        ".W.W..\n" +
                        "...WW.\n" +
                        ".W.W..\n" +
                        ".W.W.W\n" +
                        "...W..\n";

            Assert.True(Finder.PathFinder(e));
        }
    }
}
