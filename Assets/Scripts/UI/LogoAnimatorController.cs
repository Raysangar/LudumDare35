using UnityEngine;
using UnityEngine.UI;

public class LogoAnimatorController : MonoBehaviour {

  RectTransform recTransform;
  Animator animator;
  private bool logoHidden = false;

	void Start () {
    animator = GetComponent<Animator>();
	}

  void OnEnable () {
    GameControlManager.Instance.OnGameStart += OnPlay;
    GameControlManager.Instance.OnGameAwake += OnPlay;
  }

  void OnDisable () {
    GameControlManager.Instance.OnGameStart -= OnPlay;
    GameControlManager.Instance.OnGameAwake -= OnPlay;
  }
	
  public void OnPlay () {
    if (!logoHidden) {
      logoHidden = true;
      animator.CrossFade("FadeOut", 0);
    }
  }

}
