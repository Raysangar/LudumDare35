using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InputController : MonoBehaviour {

  private LifeController lifeController;
  private SoundManager soundManager;

  private Dictionary<string, UI.ActionType> actionsDictionary = new Dictionary<string, UI.ActionType>() {
    { "Characters/Pig1", UI.ActionType.Pig1 },
    { "Characters/Pig2", UI.ActionType.Pig2 },
    { "Characters/Pig3", UI.ActionType.Pig3 },
    { "Characters/Wolf", UI.ActionType.Wolf },
  };

  void Start () {
    lifeController = LifeController.Instance;
    soundManager = SoundManager.Instance;
  }

  public void OnActionClicked (string buttonName) {
    if (checkAction(buttonName)) {
      lifeController.OnEventSuccess();
      soundManager.PlayApplause();
    } else {
      lifeController.OnEventFailed();
      soundManager.PlayBoo();
    }
  }

  public bool checkAction (string actionName) {
    return UI.EventManager.Instance.CheckEventMatches(actionsDictionary[actionName]);
  }

}
