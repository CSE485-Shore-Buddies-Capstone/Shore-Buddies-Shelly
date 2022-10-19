using UnityEditor;
using UnityEngine;
 
 [CustomEditor(typeof(HoldButton))]
 public class HoldButtonEditor : Editor
 {
	SerializedProperty onPointerUp;

	void OnEnable()
    {
		onPointerUp = serializedObject.FindProperty("onPointerUp");
    }

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
	}
 }