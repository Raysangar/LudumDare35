using UnityEngine;
using System.Collections.Generic;
using UI;

namespace UI {
  public class EventManager : MonoBehaviour {

    public class Action {
      public RectTransform rectTransform;
      public bool completed;

      public Action (RectTransform recTransform) {
        this.rectTransform = recTransform;
        completed = false;
      }
    }

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
    private List<List<Action>> actionsCompletedBySequence;

    void Awake() {
      instance = this;
      actionsCompletedBySequence = new List<List<Action>>();
    }

    void Start() {
      eventParent = transform.FindChild("EventSlider").GetComponent<Transform>();
      events = new List<Event>();
      defaultWidth = eventPrefabs [0].rect.width;
    }

    void OnEnable() {
      ActionManager.OnActionPlayable += AddEvent;
    }

    void OnDisable() {
      ActionManager.OnActionPlayable -= AddEvent;
    }

    void Update() {
      foreach (Event graphicEvent in events) {
        graphicEvent.Move(eventPrefabs [0].rect.width * Time.deltaTime * currentDifficulty);
        if (graphicEvent.DisableIfPasses(currentTimeMark.localPosition.x)) {
          removeSequenceIfLastAction(graphicEvent.EventTransform);
        }
      }
    }

    public void AddEvent(ActionList actions) {
      currentDifficulty = actions.difficulty;
      actionsCompletedBySequence.Add(new List<Action>());
      for (int i = 0; i < actions.Sequence.Count; ++i) {
        float initPosition;
        float width = actions.Sequence [i].width * currentDifficulty * defaultWidth;
        if (events.Count <= 0 || events [events.Count - 1].EventTransform.localPosition.x < (Screen.width / 2 - events [events.Count - 1].EventTransform.rect.width)) {
          initPosition = Screen.width / 2 + width / 2 + (defaultWidth * actions.Sequence [i].offset * currentDifficulty);
        } else {
          initPosition = (events [events.Count - 1].EventTransform.localPosition.x + events [events.Count - 1].EventTransform.rect.width / 2) + width / 2 + defaultWidth * actions.Sequence [i].offset * currentDifficulty;
        }
        Event actionEvent = new Event(eventPrefabs [(int)actions.Sequence [i].actionType], eventParent, initPosition, width, actions.Sequence [i].actionType);
        actionEvent.DestroyController.OnOutsideOfCamera += OnEventDestroyed;
        events.Add(actionEvent);
        actionsCompletedBySequence[actionsCompletedBySequence.Count - 1].Add(new Action(actionEvent.EventTransform));
      }
    }

    public void OnEventDestroyed(RectTransform rectTransform) {
      
      events.RemoveAll(e => e.EventTransform == rectTransform);
    }

    public bool CheckEventMatches(ActionType actionType) {
      Event graphicEvent = events.Find(e => e.IsInTimeWindow(currentTimeMark.localPosition.x));
      if (graphicEvent != null) {
        if (graphicEvent.IsActionPending) {
          graphicEvent.Disable();
          if (actionType == graphicEvent.ActionType) {
            setActionToCompleted(graphicEvent);
            List<Action> sequence = actionsCompletedBySequence.Find(a => a[a.Count - 1].rectTransform == graphicEvent.EventTransform);
            if (sequence != null) {
              playApplauseIfSequenceCompletedSuccesfully(sequence);
              actionsCompletedBySequence.Remove(sequence);
            }
          }
          return graphicEvent.ActionType == actionType;
        }
      }
      return false;
    }

    public static EventManager Instance {
      get { return instance; }
    }

    private void setActionToCompleted (Event graphicEvent) {
      foreach (List<Action> sequence in actionsCompletedBySequence) {
        foreach (Action action in sequence) {
          if (graphicEvent.EventTransform == action.rectTransform) { action.completed = true; }
        }
      }
    }

    private void playApplauseIfSequenceCompletedSuccesfully (List<Action> sequence) {
      Debug.Log("Check");
      foreach (Action action in sequence) {
        if (!action.completed) return;
      }
      Debug.Log("Finished");
      SoundManager.Instance.PlayApplause();
    }

    private void removeSequenceIfLastAction (RectTransform rectTransform) {
      actionsCompletedBySequence.RemoveAll(a => a[a.Count - 1].rectTransform == rectTransform);
    }
  }
}

