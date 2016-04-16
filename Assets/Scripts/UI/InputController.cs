using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InputController : MonoBehaviour {

  private LifeController lifeController;

  private Dictionary<string, UI.EventManager.ActionType> actionsDictionary = new Dictionary<string, UI.EventManager.ActionType>() {
    { "Characters/Pig1", UI.EventManager.ActionType.Pig1 },
    { "Characters/Pig2", UI.EventManager.ActionType.Pig2 },
    { "Characters/Pig3", UI.EventManager.ActionType.Pig3 },
    { "Characters/Wolf", UI.EventManager.ActionType.Wolf },
  };

  void Start () {
    lifeController = LifeController.Instance;
  }

  public void OnActionClicked (string buttonName) {
    if (checkAction(buttonName))
      lifeController.OnEventSuccess();
    else
      lifeController.OnEventFailed();
  }

  private void activateIconOfButton (string buttonName) {
    transform.Find(buttonName + "/Image").GetComponent<Image>().enabled = true;
  }

  private bool isActionRevealed (string buttonName) {
    return transform.Find(buttonName + "/Image").GetComponent<Image>().enabled;
  }

  public bool checkAction (string actionName) {
    return UI.EventManager.Instance.CheckEventMatches(actionsDictionary[actionName]);
  }

}
