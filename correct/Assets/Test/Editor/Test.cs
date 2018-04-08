using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class Test {

    [Test]
    public void Move_Along_x()
    {
        Assert.AreEqual(1, new MovementTest(1).movementCalc(1, 0, 1).x, 0.1f);
       
    }

    [Test]
    public void Move_Along_Z()
    {
        Assert.AreEqual(1, new MovementTest(1).movementCalc(0, 1, 1).z, 0.1f);
    }
}
