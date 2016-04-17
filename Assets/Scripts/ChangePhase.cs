using UnityEngine;
using System.Collections;

public class ChangePhase : MonoBehaviour {

  [SerializeField]
  private string animationToExecute = "Idle";

	void Start () {
    GetComponent<Animator>().Play(animationToExecute, 0, Random.value);
	}
}
