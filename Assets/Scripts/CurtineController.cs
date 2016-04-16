using UnityEngine;
using System.Collections;

public class CurtineController : MonoBehaviour {

	public Animator anim;

	[ContextMenu("Open Curtine")]
	public void OpenCurtine(){
		anim.CrossFade("Open",0.0f);
	}

	[ContextMenu("Close Curtine")]
	public void CloseCurtine(){
		anim.CrossFade("Close",0.0f);
	}
}
