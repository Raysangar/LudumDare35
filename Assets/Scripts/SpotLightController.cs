using UnityEngine;
using System.Collections;

public class SpotLightController : MonoBehaviour {

	private Transform target;
	private Light lightComponent;

	public ActorType ActorToFollow;

	void Awake(){
		lightComponent = GetComponent<Light>();
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
			if(IsActionForFocus(ActionManager.Instance.ActionList.Actions[index].TypeOfAction))
			{
				lightComponent.enabled = true;
				target = ActionManager.Instance.GetActorOfType(ActorToFollow).transform;
			}
		}
	}

	public bool IsActionForFocus(ActionType actionType){
		switch (actionType){
		case ActionType.Move:
			return true;
		case ActionType.Rotate:
			return true;
		case ActionType.ChangeCostume:
			return true;
		case ActionType.PlayParticle:
			return false;
		case ActionType.PlayAnimation:
			return true;
		case ActionType.PlaySound:
			return false;
		case ActionType.Build:
			return false;
		case ActionType.Clean:
			return false;
		case ActionType.Curtine:
			return false;
		case ActionType.EndAction:
			return false;
		case ActionType.Credits:
			return false;
		default:
			break;
		}
		return false;
	}
}
