using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using XNode.Examples.StateGraph;

namespace XNodeEditor.Examples {
	[CustomNodeEditor(typeof(StateNodezxc))]
	public class StateNodeEditor : NodeEditor {

		public override void OnHeaderGUI() {
			GUI.color = Color.white;
			StateNodezxc nodezxc = target as StateNodezxc;
			StateGraph graph = nodezxc.graph as StateGraph;
			if (graph.current == nodezxc) GUI.color = Color.blue;
			string title = target.name;
			GUILayout.Label(title, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
			GUI.color = Color.white;
		}

		public override void OnBodyGUI() {
			base.OnBodyGUI();
			StateNodezxc nodezxc = target as StateNodezxc;
			StateGraph graph = nodezxc.graph as StateGraph;
			if (GUILayout.Button("MoveNext Node")) nodezxc.MoveNext();
			if (GUILayout.Button("Continue Graph")) graph.Continue();
			if (GUILayout.Button("Set as current")) graph.current = nodezxc;
		}
	}
}