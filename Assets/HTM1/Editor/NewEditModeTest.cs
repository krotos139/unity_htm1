using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewEditModeTest {

	[Test]
	public void HW1() {
        string dbgout = "";
        // Use the Assert class to test conditions.
        Debug.Log("HELLO");
        //NewBehaviourScript nbs = new NewBehaviourScript();
        var componentsHolder = new GameObject();
        var nbs = componentsHolder.AddComponent<HTM1>();
        nbs.getA1();
        Debug.Log("RESULT: Done");

        
    }

}
