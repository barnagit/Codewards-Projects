namespace Take_a_Ten_Minute_Walk 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual(true, Program.IsValidWalk(new string[] {"n","s","n","s","n","s","n","s","n","s"}), "should return true");
      Assert.AreEqual(false, Program.IsValidWalk(new string[] {"w","e","w","e","w","e","w","e","w","e","w","e"}), "should return false");
      Assert.AreEqual(false, Program.IsValidWalk(new string[] {"w"}), "should return false");
      Assert.AreEqual(false, Program.IsValidWalk(new string[] {"n","n","n","s","n","s","n","s","n","s"}), "should return false");
    }
  }
}