using UnityEngine;
using System.Collections;

public class CurtineController : MonoBehaviour {

	private Animator anim;

	void Awake(){
		anim = GetComponent<Animator>();
	}

	[ContextMenu("Open Curtine")]
	public void OpenCurtine(){
		anim.CrossFade("Open",0.0f);
	}
}
