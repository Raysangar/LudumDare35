using UnityEngine;
using System.Collections;

public class TutorialController : MonoBehaviour {

  Animator animator;
  private bool tutorialShown = false; 


 
  public delegate void TutorialHiddenEventHandler();
  public event TutorialHiddenEventHandler OnTutorialHidden = delegate{};

  void Start () {
    animator = GetComponent<Animator>();
  }

  void Update () {
    if (tutorialShown && Input.anyKeyDown) {
      HideTutorial();
      tutorialShown = false;
    }
  }
    
  public void HideTutorial () {
    animator.CrossFade("HideTutorial", 0);
    OnTutorialHidden();
  }

  public void ShowTutorial () {
    animator.CrossFade("ShowTutorial", 0);
    tutorialShown = true;
    PlayerPrefs.SetInt("tutorial", 1);
    PlayerPrefs.Save();
  }
}
