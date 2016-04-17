using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InputController : MonoBehaviour {

  private LifeController lifeController;
  private SoundManager soundManager;
  private bool gameStarted = false;

  private Dictionary<string, UI.ActionType> actionsDictionary = new Dictionary<string, UI.ActionType>() {
    { "Characters/Pig1", UI.ActionType.Pig1 },
    { "Characters/Pig2", UI.ActionType.Pig2 },
    { "Characters/Pig3", UI.ActionType.Pig3 },
    { "Characters/Wolf", UI.ActionType.Wolf },
  };

  private Dictionary<KeyCode, UI.ActionType> actionsKeyboardDictionary = new Dictionary<KeyCode, UI.ActionType>() {
    { KeyCode.Alpha1, UI.ActionType.Pig1 },
    { KeyCode.Alpha2, UI.ActionType.Pig2 },
    { KeyCode.Alpha3, UI.ActionType.Pig3 },
    { KeyCode.Alpha4, UI.ActionType.Wolf },
  };

  void Start () {
    lifeController = LifeController.Instance;
    soundManager = SoundManager.Instance;
    GameControlManager.Instance.OnGameStart += OnGameStart;
  }

  public void OnGameStart () {
    gameStarted = true;
  }

  void Update () {
    if (gameStarted) {
      foreach (KeyCode key in actionsKeyboardDictionary.Keys) {
        if (Input.GetKeyDown(key)) {
          onActionTriggered( actionsKeyboardDictionary[key]);
        }
      }
    }
  }

  public void OnActionClicked (string buttonName) {
    onActionTriggered(actionsDictionary[buttonName]);
  }

  private void onActionTriggered (UI.ActionType actionType) {
    if (UI.EventManager.Instance.CheckEventMatches(actionType)) {
      lifeController.OnEventSuccess();
      soundManager.PlayCorrectInputFeedback();
    } else {
      lifeController.OnEventFailed();
      soundManager.PlayBoo();
    }
  }
}
