using UnityEngine;
using System.Collections;
using UnityStandardAssets.Utility;

public class ActionManager : MonoBehaviour {

	public ActionList ActionList;
	public static ActionManager Instance;
	private GameObject pig1;
	private GameObject pig2;
	private GameObject pig3;
	private GameObject wolf;
	private GameObject director;
	private GameObject constructor;

	public Action CurrentAction = null;

	public bool[] ActionsState;

	public delegate void OnActionPlayableHanlder(UI.ActionList actionList);
	public static OnActionPlayableHanlder OnActionPlayable;

	void Awake(){
		if(Instance == null){
			Instance = this;
		}
	}

	void Start(){
		ActionsState = new bool[ActionList.Actions.Count];

		pig1 = GameObject.FindGameObjectWithTag("Pig1");
		pig2 = GameObject.FindGameObjectWithTag("Pig2");
		pig3 = GameObject.FindGameObjectWithTag("Pig3");
		wolf = GameObject.FindGameObjectWithTag("Wolf");
		director = GameObject.FindGameObjectWithTag("Director");
		constructor = GameObject.FindGameObjectWithTag("Constructor");
	}

	void OnEnable(){
		TimeManager.OnActionLaunched += OnActionLaunchedCallback;
	}

	void OnDisable(){
		TimeManager.OnActionLaunched -= OnActionLaunchedCallback;
	}

	void OnActionLaunchedCallback(int index){
		if(index < ActionList.Actions.Count){
			CurrentAction = ActionList.Actions[index];
			if(ActionList.Actions[index].Actor != null)
			{
				if(ActionList.Actions[index].IsPlayable){
					OnActionPlayable(ActionList.Actions[index].UIActionList);
				}
				ActionsState[index] = true;
				switch (ActionList.Actions[index].TypeOfAction){
				case ActionType.Move:
					if(!ActionList.Actions[index].MoveFirst){
						GetActorOfType(ActionList.Actions[index].Actor).GetComponent<AutoMoveAndRotate>().enabled = true;
						GetActorOfType(ActionList.Actions[index].Actor).GetComponent<AutoMoveAndRotate>().isMoving = true;
						GetActorOfType(ActionList.Actions[index].Actor).GetComponent<AutoMoveAndRotate>().stopPosition = ActionList.Actions[index].EndPosition;
					} else {
						GetActorOfType(ActionList.Actions[index].Actor).transform.position = ActionList.Actions[index].EffectPosition.position;
					}
					break;
				case ActionType.Rotate:
					GetActorOfType(ActionList.Actions[index].Actor).GetComponent<AutoMoveAndRotate>().enabled = true;
					GetActorOfType(ActionList.Actions[index].Actor).GetComponent<AutoMoveAndRotate>().isMoving = true;
					GetActorOfType(ActionList.Actions[index].Actor).GetComponent<AutoMoveAndRotate>().rotateDegreesPerSecond.value = ActionList.Actions[index].RotationDegrees;
					break;
				case ActionType.ChangeCostume:
					GetActorOfType(ActionList.Actions[index].Actor).GetComponent<CostumeController>().ActivateCostume();
					break;
				case ActionType.PlayParticle:
					GetActorOfType(ActionList.Actions[index].Actor).GetComponent<ParticleController>().ActivateParticle();
					break;
				case ActionType.PlayAnimation:
					GetActorOfType(ActionList.Actions[index].Actor).GetComponent<AutoMoveAndRotate>().enabled = false;
					GetActorOfType(ActionList.Actions[index].Actor).GetComponent<AutoMoveAndRotate>().isMoving = false;
					GetActorOfType(ActionList.Actions[index].Actor).GetComponent<AnimController>().PlayTransitionTo(ActionList.Actions[index].TypeOfAnimation);
					break;
				case ActionType.PlaySound:
						GetActorOfType(ActionList.Actions[index].Actor).GetComponent<SoundController>().PlayTransitionTo(ActionList.Actions[index].TypeOfSound);
					break;
				case ActionType.Build:
					GetActorOfType(ActionList.Actions[index].Actor).GetComponent<ConstructController>().ConstructHouseByType(ActionList.Actions[index].TypeOfBuild);
					break;
				case ActionType.Clean:
					if(GetActorOfType(ActionList.Actions[index].Actor).GetComponent<ConstructController>() != null){
						GetActorOfType(ActionList.Actions[index].Actor).GetComponent<ConstructController>().CleanHouses();
					}
					if(GetActorOfType(ActionList.Actions[index].Actor).GetComponent<Actor>() != null){
						GetActorOfType(ActionList.Actions[index].Actor).GetComponent<Actor>().CleanActor();
					}

					break;
				case ActionType.Curtine:
					if(ActionList.Actions[index].ActionsOfCurtine == CurtineActions.Close){
						GetActorOfType(ActionList.Actions[index].Actor).GetComponent<CurtineController>().CloseCurtine();
					} else {
						GetActorOfType(ActionList.Actions[index].Actor).GetComponent<CurtineController>().OpenCurtine();
					}
					break;
				case ActionType.EndAction:
					GetActorOfType(ActionList.Actions[index].Actor).GetComponent<EndActionController>().ActivateAttenuate();
					break;
				case ActionType.Credits:
					GameControlManager.Instance.OnGameFinished();
					break;
				default:
					break;
				}

			}
		}
	}

	public GameObject GetActorOfType(ActorType actorType){
		switch(actorType){
		case ActorType.Pig1:
			return pig1;
		case ActorType.Pig2:
			return pig2;
		case ActorType.Pig3:
			return pig3;
		case ActorType.Wolf:
			return wolf;
		case ActorType.Director:
			return director;
		case ActorType.Constructor:
			return constructor;
		}
		return null;
	}

}	
