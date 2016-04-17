using UnityEngine;
using System.Collections;
using UnityStandardAssets.Utility;

public class Actor : MonoBehaviour {

	public Transform resetPosition;

	public void CleanActor(){
		transform.position = resetPosition.position;
		GetComponent<AutoMoveAndRotate>().isMoving = false;
	}
}
