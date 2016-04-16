using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Action {

	public string Name;
	public float ExecuteTime;
	public ActorType Actor;
	public Transform EffectPosition;
	public Transform EndPosition;
	public bool IsPlayable;

	public AnimationType TypeOfAnimation;
	public ActionType TypeOfAction;
	public SoundType TypeOfSound;
	public List<UI.Action> UIActions;
}

public enum ActionType { Move, PlayAnimation, PlayParticle, PlaySound }
public enum ActorType { Wolf, Pig1, Pig2, Pig3 }
public enum AnimationType {Walk, Run, Afraid, Death, Idle, Blow}
public enum SoundType {Laugh}
