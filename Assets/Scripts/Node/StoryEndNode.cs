﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class StoryEndNode : Node {

    [Input(ShowBackingValue.Never)] public bool enter;
    // Use this for initialization
    protected override void Init() {
		base.Init();
		
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null; // Replace this
	}
}