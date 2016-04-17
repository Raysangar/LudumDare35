using UnityEngine;
using System.Collections;

public class AnimController : MonoBehaviour {

	private Animator animator;

	void Awake(){
		animator = GetComponent<Animator>();
	}

	public void Walk(){
		animator.CrossFade("Walk",0.0f);		
	}

	public void Run(){
		animator.CrossFade("Run",0.0f);	
	}

	public void Afraid(){
		animator.CrossFade("Afraid",0.0f);
	}

	public void Idle(){
		animator.CrossFade("Idle",0.0f);	
	}

	public void Dead(){
		animator.CrossFade("Dead",0.0f);	
	}

	public void Blow(){
		animator.CrossFade("Blow",0.0f);	
	}

	public void Arbol(){
		animator.CrossFade("Arbol",0.0f);	
	}

	public void PlayTransitionTo(AnimationType animType){
		switch (animType){
		case AnimationType.Idle:
				Idle();
				break;
		case AnimationType.Walk:
				Walk();
				break;
		case AnimationType.Run:
				Run();
				break;
		case AnimationType.Afraid:
				Afraid();
				break;
		case AnimationType.Death:
			Dead();
			break;
		case AnimationType.Blow:
			Blow();
			break;
		case AnimationType.Arbol:
			Arbol();
			break;
		}
	}
}
