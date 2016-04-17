using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

  [SerializeField]
  private AudioSource ambient;

  [SerializeField]
  private AudioSource applause1;

  [SerializeField]
  private AudioSource applause2;

  [SerializeField]
  private AudioSource boo1;

  [SerializeField]
  private AudioSource boo2;

  [SerializeField]
  private AudioSource silence;

  [SerializeField]
  private AudioSource crowd;

  [SerializeField]
  private AudioSource lose;

  [SerializeField]
  private AudioSource[] wins;

  [SerializeField]
  private AudioSource correctInput;

  private static SoundManager instance;
  private LifeController lifeController;

  void Awake () {
    instance = this;
  }

  void Start () {
    lifeController = LifeController.Instance;
    GameControlManager.Instance.OnGameStart += OnGameStart;
    TimeManager.Instance.OnGameFinished += OnGameFinished;
    LifeController.Instance.OnGameOver += OnGameLost;
  }

  public static SoundManager Instance {
    get { return instance; }
  }

  void Update () {
    crowd.volume =  (lifeController.MaxLife/2 - lifeController.CurrentLife) / (lifeController.MaxLife/2);
  }

  public void OnGameStart () {
    StartCoroutine(fadeAmbient());
  }

  private IEnumerator fadeAmbient () {
    while (ambient.volume > 0) {
      yield return 0;
    }
    ambient.Stop();
  }

  public void PlayApplause() {
    if (lifeController.MaxLife * 0.8f < lifeController.CurrentLife) {
      if (!applause2.isPlaying)
        applause2.Play();
    } else if (lifeController.MaxLife * 0.6f < lifeController.CurrentLife) {
      if (!applause1.isPlaying)
        applause1.Play();
    }
  }

  public void PlayBoo() {
    if (lifeController.MaxLife * 0.2f > lifeController.CurrentLife) {
      if (!boo2.isPlaying) {
        boo2.Play();
      }
    } else if (lifeController.MaxLife * 0.4f > lifeController.CurrentLife) {
      if (!boo1.isPlaying) {
        boo1.Play();
      } 
    }
  }

  public void PlayCorrectInputFeedback () {
    correctInput.Play();
  }

  public void OnGameLost () {
    lose.Play();
  }

  public void OnGameFinished () {
    if (lifeController.MaxLife * 0.8f < lifeController.CurrentLife) {
      wins[3].Play();
    } else if (lifeController.MaxLife * 0.6f < lifeController.CurrentLife) {
      wins[2].Play();
    } else if (lifeController.MaxLife * 0.4f < lifeController.CurrentLife) {
      wins[1].Play();
    } else {
      wins[0].Play();
    }
    
  }

}
