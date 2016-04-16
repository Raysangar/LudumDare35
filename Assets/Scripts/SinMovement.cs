using UnityEngine;
using System.Collections;

public class SinMovement : MonoBehaviour {


	public float  	xAmplitud;
	public float	xFrecuencia;

	public float  	yAmplitud;
	public float	yFrecuencia;

	private Transform 	myTr;
	private Vector3		initPosition;

	void Awake() {

		myTr = GetComponent<Transform>();
		initPosition = myTr.position;
	}

	void Update(){

		float xDisp = Mathf.Sin(Time.time * xAmplitud) * xFrecuencia;
		float yDisp = Mathf.Sin(Time.time * yAmplitud) * yFrecuencia;

		myTr.position = new Vector3((initPosition.x + xDisp), (initPosition.y + yDisp), initPosition.z); 
	}

}
