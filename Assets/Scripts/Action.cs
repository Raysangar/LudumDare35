﻿using UnityEngine;
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
	public Vector3 RotationDegrees;

	public AnimationType TypeOfAnimation;
	public ActionType TypeOfAction;
	public SoundType TypeOfSound;
	public UI.ActionList UIActionList;
}

public enum ActionType { Move, PlayAnimation, PlayParticle, PlaySound, ChangeCostume, Rotate }
public enum ActorType { Wolf, Pig1, Pig2, Pig3 }
public enum AnimationType {Walk, Run, Afraid, Death, Idle, Blow}
public enum SoundType {Laugh}
