using UnityEngine;
using UnityEditor;
using System.Collections;

//[CanEditMultipleObjects] // 複数のオブジェクトを選択した状態での編集に対応している場合にはこの記述を行う
[CustomEditor(typeof(AreaAssumption))]
public class AreaAssumptionEditor : Editor
{

	private SerializedProperty xProp = null;
	private SerializedProperty yProp = null;
	private SerializedProperty magnificationProp = null;

	private void OnEnable()
	{
		// SerializedPropertyの値を取得

		// 最初の取得時には何故か null が返って来るので1度適当な値で読む
		serializedObject.FindProperty("__dummy__");
		xProp = serializedObject.FindProperty("x");
		yProp = serializedObject.FindProperty("y");
		magnificationProp = serializedObject.FindProperty("magnification");
	}

	public override void OnInspectorGUI()
	{
		// serializedPropertyの更新開始
		serializedObject.Update();


		// int型のデータ向けのスライダー(その他にfloat型向けの Slider も有ります)
		EditorGUILayout.PropertyField(xProp, new GUIContent("X"));
		// 複数選択時に選択したものの値が全て同じ場合にはプログレスバーを表示
		//if (!damageProp.hasMultipleDifferentValues)
		//	ProgressBar(damageProp.intValue / 100.0f, "Damage");

		EditorGUILayout.PropertyField(yProp, new GUIContent("Y"));
		//if (!armorProp.hasMultipleDifferentValues)
		//	ProgressBar(armorProp.intValue / 100.0f, "Armor");

		EditorGUILayout.IntSlider(magnificationProp, 1, 100, new GUIContent("倍率"));

		// serializedPropertyの更新を適用
		serializedObject.ApplyModifiedProperties();
	}

	// プログレスバーの描画
	void ProgressBar(float value, string label)
	{
		// Get a rect for the progress bar using the same margins as a textfield:
		Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
		EditorGUI.ProgressBar(rect, value, label);
		EditorGUILayout.Space();
	}
}