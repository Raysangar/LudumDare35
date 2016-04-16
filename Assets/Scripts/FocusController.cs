using UnityEngine;
using System.Collections;

public class FocusController : MonoBehaviour {

	private Animator anim;

	void Awake(){
		anim = GetComponent<Animator>();
	}

	[ContextMenu("Stop Focus")]
	public void StopFocus(){
		anim.CrossFade("Diffumine",0.0f);
	}
}
