using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using UnityEngine;
using XNode;

public class Choise : Node {
	[Input] public bool input;
	[Output (dynamicPortList = true)] public string[] choise;
	protected override void Init() {
		base.Init();
		
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		if (port.fieldName == "choise") {
			int index = int.Parse(port.fieldName.Replace("choise ", ""));
			return choise[index];
		}
		return null;
	}
}