namespace Rot13 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("test")]
    public void testTest()
    {
      Assert.AreEqual("grfg", Program.Rot13("test"), String.Format("Input: test, Expected Output: Grfg, Actual Output: {0}", Program.Rot13("test")));
    }
    
    [Test, Description("Test")]
    public void TestTest()
    {
      Assert.AreEqual("Grfg", Program.Rot13("Test"), String.Format("Input: Test, Expected Output: grfg, Actual Output: {0}", Program.Rot13("Test")));
    }
  }
  
}
