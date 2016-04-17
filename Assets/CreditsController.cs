using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CreditsController : MonoBehaviour {

  [SerializeField]
  private CurtineController curtineController;

	void Start () {
    StartCoroutine(waitAndLoadGame());
	}
	
	void Update () {
    if (Input.anyKeyDown) {
      StartCoroutine(closeAndLoad());
    }
	}

  private IEnumerator waitAndLoadGame() {
    yield return new WaitForSeconds(10);
    curtineController.CloseCurtine();
    yield return new WaitForSeconds(5);
    SceneManager.LoadScene(0);
  }

  private IEnumerator closeAndLoad() {
    curtineController.CloseCurtine();
    yield return new WaitForSeconds(2);
    SceneManager.LoadScene(0);
  }
}
