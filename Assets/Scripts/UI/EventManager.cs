using UnityEngine;
using System.Collections.Generic;
using UI;

namespace UI {
  public class EventManager : MonoBehaviour {

    [SerializeField]
    private int timeWindowDisplayed;

    [SerializeField]
    private RectTransform[] eventPrefabs;

    [SerializeField]
    private Sprite[] eventSprites;

    [SerializeField]
    private RectTransform currentTimeMark;

    private List<Event> events;
    private Transform eventParent;
    private int currentDifficulty;
    private static EventManager instance;
    private float defaultWidth;

    void Awake () {
      instance = this;
    }

    void Start () {
      eventParent = transform.FindChild("EventSlider").GetComponent<Transform>();
      events = new List<Event>();
      defaultWidth = eventPrefabs[0].rect.width;
    }

	void OnEnable(){
		ActionManager.OnActionPlayable += AddEvent;
	}

	void OnDisable(){
		ActionManager.OnActionPlayable -= AddEvent;
	}

    void Update () {
      foreach (Event graphicEvent in events) {
        graphicEvent.Move(eventPrefabs[0].rect.width * Time.deltaTime * currentDifficulty);
        graphicEvent.DisableIfPasses(currentTimeMark.localPosition.x);
      }
    }

	public void AddEvent (ActionList actions) {
      currentDifficulty = actions.difficulty;
		for (int i = 0; i < actions.Sequence.Count; ++i) {
        float initPosition;
        float width = actions.Sequence[i].width * currentDifficulty * defaultWidth;
        if (events.Count <= 0 || events[events.Count -1].EventTransform.localPosition.x < (Screen.width/2 - events[events.Count - 1].EventTransform.rect.width)) {
          initPosition = Screen.width/2 + width/2 + (defaultWidth * actions.Sequence[i].offset * currentDifficulty);
        } else {
          initPosition = (events[events.Count -1].EventTransform.localPosition.x + events[events.Count -1].EventTransform.rect.width/2) + width/2 + defaultWidth * actions.Sequence[i].offset * currentDifficulty;
        }
        Event actionEvent = new Event(eventPrefabs[(int)actions.Sequence[i].actionType], eventParent, initPosition, width, actions.Sequence[i].actionType);
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

