using UnityEngine;
using System.Collections.Generic;

public class TimeManager : MonoBehaviour {

	public ActionList ActionList;

	public float[] timesToTrigger;

	public delegate void OnTimeForAction(int index);
	public static OnTimeForAction OnActionLaunched;

	private int index = 0;

	void Awake(){
		timesToTrigger = new float[100];
		for (int i = 0; i < ActionList.Actions.Count; i++) {
			timesToTrigger[i] = ActionList.Actions[i].ExecuteTime;
		}
	}

	void Update(){
		if(Time.time >= timesToTrigger[index]){
			Debug.Log("Action numero " + index + " lanzada");
			OnActionLaunched(index);
			index++;
		}
	}
}
