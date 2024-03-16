using XNode;

// ReSharper disable once CheckNamespace
public class Choice : Node {
	[Input] public bool input;
	[Output (dynamicPortList = true)] public string[] choice;

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		if (port.fieldName == "choice") {
			int index = int.Parse(port.fieldName.Replace("choice ", ""));
			return choice[index];
		}
		return null;
	}
}