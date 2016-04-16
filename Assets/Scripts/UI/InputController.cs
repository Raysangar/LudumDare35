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

  private Dictionary<KeyCode, UI.ActionType> actionsKeyboardDictionary = new Dictionary<KeyCode, UI.ActionType>() {
    { KeyCode.Q, UI.ActionType.Pig1 },
    { KeyCode.W, UI.ActionType.Pig2 },
    { KeyCode.E, UI.ActionType.Pig3 },
    { KeyCode.R, UI.ActionType.Wolf },
  };

  void Start () {
    lifeController = LifeController.Instance;
    soundManager = SoundManager.Instance;
  }

  void Update () {
    foreach (KeyCode key in actionsKeyboardDictionary.Keys) {
      if (Input.GetKeyDown(key)) {
        onActionTriggered( actionsKeyboardDictionary[key]);
      }
    }
  }

  public void OnActionClicked (string buttonName) {
    onActionTriggered(actionsDictionary[buttonName]);
  }

  private void onActionTriggered (UI.ActionType actionType) {
    if (UI.EventManager.Instance.CheckEventMatches(actionType)) {
      lifeController.OnEventSuccess();
    } else {
      lifeController.OnEventFailed();
      soundManager.PlayBoo();
    }
  }
}
