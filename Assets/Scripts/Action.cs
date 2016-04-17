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
	public Vector3 RotationDegrees;
	public Vector3 Movement;

	public AnimationType TypeOfAnimation;
	public ActionType TypeOfAction;
	public SoundType TypeOfSound;
	public UI.ActionList UIActionList;
	public BuildType TypeOfBuild;
	public CurtineActions ActionsOfCurtine;
}

public enum ActionType { Move, PlayAnimation, PlayParticle, PlaySound, ChangeCostume, Rotate, Build, Curtine, Clean }
public enum BuildType {Cardboard, Wood, Brick}
public enum CurtineActions {Open, Close}
public enum ActorType { Wolf, Pig1, Pig2, Pig3, Director, Constructor }
public enum AnimationType {Walk, Run, Afraid, Death, Idle, Blow}
public enum SoundType {Laugh, SmokeBomb, Clap00, Clap01, Boo00, Boo01, Act01Track, Act02Track, Act03Track, WolfScare, WolfBlow, PigYell, PigLaugh, House}
