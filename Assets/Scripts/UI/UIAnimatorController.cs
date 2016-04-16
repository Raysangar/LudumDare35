using UnityEngine;
using UnityEngine.UI;

public class UIAnimatorController : MonoBehaviour {

  RectTransform recTransform;
  Animator animator;

	void Start () {
    recTransform = GetComponent<RectTransform>();
    animator = GetComponent<Animator>();
	}

  void OnEnable () {
    LifeController.Instance.OnGameOver += OnGameOver;
  }

  void OnDisable () {
    LifeController.Instance.OnGameOver -= OnGameOver;
  }
	
  public void OnPlay () {
    animator.CrossFade("ShowUI", 0);
  }

  public void OnGameOver () {
    animator.CrossFade("HideUI", 0);
  }

  public void OnGameFinished () {
    animator.CrossFade("HideUI", 0);
  }
}
