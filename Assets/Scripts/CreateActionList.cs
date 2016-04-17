using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CreateActionList {

//	[MenuItem("Assets/Create/Action List")]
	public static ActionList  Create()
	{
		#if UNITY_EDITOR
		ActionList asset = ScriptableObject.CreateInstance<ActionList>();

		AssetDatabase.CreateAsset(asset, "Assets/ActionList.asset");
		AssetDatabase.SaveAssets();
		return asset;
		#endif
		return null;
	}
}
