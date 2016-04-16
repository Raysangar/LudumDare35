using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateActionList {

	[MenuItem("Assets/Create/Action List")]
	public static ActionList  Create()
	{
		ActionList asset = ScriptableObject.CreateInstance<ActionList>();

		AssetDatabase.CreateAsset(asset, "Assets/ActionList.asset");
		AssetDatabase.SaveAssets();
		return asset;
	}
}
