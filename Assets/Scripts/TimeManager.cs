using UnityEngine;
using System.Collections.Generic;

public class TimeManager : MonoBehaviour {

	public ActionList ActionList;

	public float[] timesToTrigger;

	private float time;
	private bool initialized;
    private bool onGameFinishedLaunched = false;

	public delegate void OnTimeForAction(int index);
	public static OnTimeForAction OnActionLaunched;

    public delegate void GameFinishedEventHandler();
    public event GameFinishedEventHandler OnGameFinished = delegate{};

    private static TimeManager instance;

	private int index = 0;

	void Awake(){
    instance = this;
		timesToTrigger = new float[100];
		for (int i = 0; i < ActionList.Actions.Count; i++) {
			timesToTrigger[i] = ActionList.Actions[i].ExecuteTime;
		}
	}

	void Update(){
    if (index >= timesToTrigger.Length && !onGameFinishedLaunched) {
      onGameFinishedLaunched = true;
      OnGameFinished();
    } else {
      if(time >= timesToTrigger[index]){
        Debug.Log("Action numero " + index + " lanzada");
        OnActionLaunched(index);
        index++;
      }

      if(initialized){
		time += Time.deltaTime;
      }
    }
	}

  public static TimeManager Instance {
    get { return instance; }
  }

	public void InitTime(){
		initialized = true;
	}

	public void InitTimeAt(float timeAt, int indexAt){
		time = timeAt;
		index = indexAt;
		initialized = true;
	}

  public void StopTime () {
    initialized = false;
  }
}
