using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Tester
{
    // A Test behaves as an ordinary method
    [Test]
   public void checkYvelocity()
    {
        var MovInst = new DefaultVal();
        Assert.IsNotNull(MovInst.getY_vel()); //checks if default Y velocity is not zero

    }

    [Test]
    public void checkXvelocity()
    {
        var MovInst = new DefaultVal();
        Assert.IsNotNull(MovInst.getX_vel()); //checks if non-overridden value is not zero
    }

}
