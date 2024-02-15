using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DialogStart : Node {
	[Input] public bool input;
	[Output] public bool output;
	[SerializeField] public Personage personage;
	[SerializeField] public Vector2 personagePosition;
	[SerializeField] [TextArea(5, 10)] private string text;


	public string Name => name;
	public string Text => text;
	// Use this for initialization
	protected override void Init() {
		base.Init();
		
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null; // Replace this
	}
}