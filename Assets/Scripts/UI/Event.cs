using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UI {
  public class Event {

    private RectTransform eventTransform;

    private EventManager.ActionType actionType;

    private bool actionPending;

    public Event (RectTransform eventPrefab, Transform parent, float eventInitPosition, float scaleFactor, EventManager.ActionType actionType) {
      this.actionType = actionType;
      actionPending = true;
      eventTransform = RectTransform.Instantiate(eventPrefab);
      setParent(parent);
      setInitPosition(eventInitPosition);
      setScale(scaleFactor);
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
      eventTransform.localPosition = position;
    }

    private void setScale (float scaleFactor) {
      Vector2 size = eventTransform.sizeDelta;
      size.x *= scaleFactor;
      eventTransform.sizeDelta = size;
    }

    public void DisableIfPasses (float currentTimeMarkPosition) {
      if ((eventTransform.localPosition.x + eventTransform.rect.width/2) < currentTimeMarkPosition && actionPending) {
        LifeController.Instance.OnEventTimeOut();
        actionPending = false;
      }
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

    public EventManager.ActionType ActionType {
      get { return actionType; }
    }
  }

}
