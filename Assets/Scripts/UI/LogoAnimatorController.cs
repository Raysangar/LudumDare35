using UnityEngine;
using UnityEngine.UI;

public class LogoAnimatorController : MonoBehaviour {

  RectTransform recTransform;
  Animator animator;

	void Start () {
    animator = GetComponent<Animator>();
	}

  void OnEnable () {
    GameControlManager.Instance.OnGameStart += OnPlay;
  }

  void OnDisable () {
    GameControlManager.Instance.OnGameStart -= OnPlay;
  }
	
  public void OnPlay () {
    animator.CrossFade("FadeOut", 0);
  }

}
