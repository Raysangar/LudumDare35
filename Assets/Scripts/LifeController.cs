using UnityEngine;
using System.Collections;

public class LifeController : MonoBehaviour {

  [SerializeField]
  private int maxLife;

  [SerializeField]
  private int eventTimeoutPenalty;

  [SerializeField]
  private int eventFailedPenalty;

  [SerializeField]
  private int eventBlindlyFailedPenalty;

  [SerializeField]
  private int eventSuccessReward;

  private int currentLife;

  private static LifeController instance;

  public delegate void GameOverEventHandler();
  public event GameOverEventHandler OnGameOver = delegate{};

  void Awake () {
    instance = this;
    currentLife = maxLife/2;
  }

  public static LifeController Instance {
    get { return instance; }
  }

  public int MaxLife {
    get { return maxLife; }
  }

  public int CurrentLife {
    get { return currentLife; }
  }

  public void OnEventSuccess () {
    Debug.Log("Success");
    currentLife = (currentLife + eventSuccessReward) % maxLife;
  }

  public void OnEventFailed () {
    Debug.Log("Failed");
    decreaseLife(eventFailedPenalty);
		SoundManager.Instance.PlayBoo();
  }
 
  public void OnEventTimeOut () {
    Debug.Log("Timeout");
		decreaseLife(eventTimeoutPenalty);
		SoundManager.Instance.PlayBoo();
  }

  private void decreaseLife (int lifeDecresed) {
    currentLife -= lifeDecresed;
    if (currentLife <= 0)
      OnGameOver();
  }
}
