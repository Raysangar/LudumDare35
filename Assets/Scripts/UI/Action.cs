using UnityEngine;
using System.Collections.Generic;

namespace UI {
  [System.Serializable]
  public class Action {

    public float width;

    public float offset;

    public ActionType actionType;

    public Action (float width, float offset, ActionType actionType) {
      this.width = width;
      this.offset = offset;
      this.actionType = actionType;
    }
  }

  public enum ActionType {
    Pig1, Pig2, Pig3, Wolf
  }
}

