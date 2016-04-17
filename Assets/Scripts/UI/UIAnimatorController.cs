using UnityEngine;
using UnityEngine.UI;

public class UIAnimatorController : MonoBehaviour {

  RectTransform recTransform;
  Animator animator;
  private bool uiShown = false;

	void Start () {
    recTransform = GetComponent<RectTransform>();
    animator = GetComponent<Animator>();
	}

  void OnEnable () {
    LifeController.Instance.OnGameOver += OnGameOver;
    GameControlManager.Instance.OnGameStart += OnPlay;
    GameControlManager.Instance.OnGameAwake += OnPlay;
    TimeManager.Instance.OnGameFinished += OnGameFinished;
  }

  void OnDisable () {
    LifeController.Instance.OnGameOver -= OnGameOver;
    TimeManager.Instance.OnGameFinished -= OnGameFinished;
    GameControlManager.Instance.OnGameStart -= OnPlay;
    GameControlManager.Instance.OnGameAwake -= OnPlay;
  }
	
  public void OnPlay () {
    if (!uiShown) {
      animator.CrossFade("ShowUI", 0);
      uiShown = true;
    }
  }

  public void OnGameOver () {
    animator.CrossFade("HideUI", 0);
    uiShown = false;
  }

  public void OnGameFinished () {
    animator.CrossFade("HideUI", 0);
    uiShown = false;
  }
}
