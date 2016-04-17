using UnityEngine;
using System.Collections;

public class ChangePhase : MonoBehaviour {
	void Start () {
    GetComponent<Animator>().Play("Idle", 0, Random.value);
	}
}
