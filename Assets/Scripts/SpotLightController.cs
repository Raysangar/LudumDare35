using UnityEngine;
using System.Collections;

public class SpotLightController : MonoBehaviour {

	private Transform target;
	private Light light;

	void Awake(){
		light = GetComponent<Light>();
	}

	void OnEnable(){
		TimeManager.OnActionLaunched += OnActionLaunchedCallback;
	}

	void OnDisable(){
		TimeManager.OnActionLaunched -= OnActionLaunchedCallback;
	}

	// Update is called once per frame
	void Update () {
		
		if(target != null){
			transform.LookAt(target);
		}
	}

	void OnActionLaunchedCallback(int index){
		if(index < ActionManager.Instance.ActionList.Actions.Count){
			if(ActionManager.Instance.ActionList.Actions[index].Actor != null && ActionManager.Instance.ActionList.Actions[index].TypeOfAction == ActionType.Move)
			{
				light.enabled = true;
				target = ActionManager.Instance.GetActorOfType(ActionManager.Instance.ActionList.Actions[index].Actor).transform;
			}
		}
	}
}
