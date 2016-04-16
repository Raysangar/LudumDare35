using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Action {
  
  public float width;

  public float offset;

  public Action (float width, float offset) {
    this.width = width;
    this.offset = offset;
  }
}
