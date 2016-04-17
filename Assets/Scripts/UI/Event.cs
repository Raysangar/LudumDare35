using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI {
  public class Event {

    private RectTransform eventTransform;

    private ActionType actionType;

    private bool actionPending;

    public Event (RectTransform eventPrefab, Transform parent, float eventInitPosition, float eventWidth, ActionType actionType) {
      this.actionType = actionType;
      actionPending = true;
      eventTransform = RectTransform.Instantiate(eventPrefab);
      setParent(parent);
      setInitPosition(eventInitPosition);
      setScale(eventWidth);
    }

    public void setParent (Transform parent) {
      eventTransform.SetParent(parent);
    }

    public RectTransform EventTransform {
      get { return eventTransform; }
    }

    public DestroyWhenOutOfCamera DestroyController {
      get { return eventTransform.GetComponent<DestroyWhenOutOfCamera>(); }
    }

    public void Move (float movement) {
      Vector3 newPosition = eventTransform.localPosition;
      newPosition.x -= movement;
      eventTransform.localPosition = newPosition;
    }

    private void setInitPosition (float initPosition) {
      Vector3 position = Vector3.zero;
      position.x = initPosition;
      position.y = 3;
      eventTransform.localPosition = position;
    }

    private void setScale (float width) {
      Vector2 size = eventTransform.sizeDelta;
      size.x = width;
      eventTransform.sizeDelta = size;
    }

    public bool DisableIfPasses (float currentTimeMarkPosition) {
      if ((eventTransform.localPosition.x + eventTransform.rect.width/2) < currentTimeMarkPosition && actionPending) {
        LifeController.Instance.OnEventTimeOut();
        actionPending = false;
        return true;
      }
      return false;
    }

    public void Disable () {
      actionPending = false;
    }

    public bool IsInTimeWindow (float currentTimeMarkPosition) {
      return currentTimeMarkPosition >= eventTransform.localPosition.x - eventTransform.rect.width/2 && 
        currentTimeMarkPosition <= eventTransform.localPosition.x + eventTransform.rect.width/2;
    }

    public bool IsActionPending {
      get { return actionPending; }
    }

    public ActionType ActionType {
      get { return actionType; }
    }
  }

}
