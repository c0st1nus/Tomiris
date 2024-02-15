﻿using UnityEngine;
using XNode;

public class Dialog : Node
{
	[Input] public bool input;
	[Output] public bool output;
	[SerializeField] public Personage personage;
	[SerializeField] public Vector2 personagePosition;
	[SerializeField] [TextArea(5, 10)] private string text;

	public string Name => name;
	public string Text => text;

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null; // Replace this
	}
}