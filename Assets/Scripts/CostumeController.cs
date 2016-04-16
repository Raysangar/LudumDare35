using UnityEngine;
using System.Collections;

public class CostumeController : MonoBehaviour {

	public GameObject Head;
	public GameObject Tail;

	[ContextMenu("Activate Costume")]
	public void ActivateCostume(){
		Head.SetActive(true);
		Tail.SetActive(true);
	}

	[ContextMenu("Desactivate Costume")]
	public void DesactivateCostume(){
		Head.SetActive(false);
		Tail.SetActive(false);
	}
}
