using UnityEngine;
using System.Collections.Generic;

namespace UI {
  public class EventManager : MonoBehaviour {

    public enum ActionType {
      Pig1, Pig2, Pig3, Wolf
    };

    [SerializeField]
    private int timeWindowDisplayed;

    [SerializeField]
    private int eventWidthPerSecond;

    [SerializeField]
    private RectTransform[] eventPrefabs;

    [SerializeField]
    private Sprite[] eventSprites;

    [SerializeField]
    private RectTransform currentTimeMark;

    private List<Event> events;
    private Transform eventParent;
    private static EventManager instance;

    void Awake () {
      instance = this;
    }

    void Start () {
      eventParent = transform.FindChild("EventSlider").GetComponent<Transform>();
      events = new List<Event>();
      AddEvent(new List<Action>(){new Action(1, 0)}, ActionType.Pig1);
    }

    void Update () {
      foreach (Event graphicEvent in events) {
        graphicEvent.Move(eventWidthPerSecond * Time.deltaTime * 4);
        graphicEvent.DisableIfPasses(currentTimeMark.localPosition.x);
      }
    }

    public void AddEvent (List<Action> actions, ActionType actionType) {
      for (int i = 0; i < actions.Count; ++i) {
        float initPosition = Screen.width/2 + eventPrefabs[0].rect.width/2 + actions[i].offset;
        Event actionEvent = new Event(eventPrefabs[(int)actionType], eventParent, initPosition, actions[0].width, actionType);
        actionEvent.DestroyController.OnOutsideOfCamera += OnEventDestroyed;
        events.Add(actionEvent);

      }
    }

    public void OnEventDestroyed (RectTransform rectTransform) {
      events.RemoveAll(e => e.EventTransform == rectTransform);
    }

    public bool CheckEventMatches (ActionType actionType) {
      Event graphicEvent = events.Find(e => e.IsInTimeWindow(currentTimeMark.localPosition.x));
      if (graphicEvent != null) {
        if (graphicEvent.IsActionPending) {
          graphicEvent.Disable();
          return graphicEvent.ActionType == actionType;
        }
      }
      return false;
    }

    public static EventManager Instance {
      get { return instance; }
    }

  }
}

