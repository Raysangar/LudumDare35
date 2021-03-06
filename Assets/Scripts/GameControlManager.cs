﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameControlManager : MonoBehaviour {

  [SerializeField]
  private CurtineController curtineController;

  [SerializeField]
  private FocusController focusController;

  [SerializeField]
  private TutorialController[] tutorials;

  [SerializeField]
  public float TimeToInit;

	[SerializeField]
	public int indexAction;

  private bool gameStarted = false;
  private bool tutorialShown;

	public AudioSource startAudio;
	public AudioSource endAudio;

  public delegate void GameStartEventHandler ();
  public event GameStartEventHandler OnGameStart = delegate {};

  public delegate void OnGameAwakeEventHandler ();
  public event OnGameAwakeEventHandler OnGameAwake = delegate {};

  private static GameControlManager instance;

  public static GameControlManager Instance {
    get { return instance; }
  }

	void Awake(){
		instance = this;
	}

  void Start () {
		startAudio.Play();
    LifeController.Instance.OnGameOver += OnGameOver;
    TimeManager.Instance.OnGameFinished += OnGameFinished;
    tutorialShown = PlayerPrefs.GetInt("tutorial", 0) == 1;
  }

  void Update () {
    if (Input.anyKeyDown && !gameStarted) {
      gameStarted = true;
      StartGame();
    }
  }

  public void StartGame () {
    curtineController.OpenCurtine();
	focusController.StopFocus();
    if (tutorialShown) {
      OnStart();
    } else {
      OnGameAwake();
      foreach (TutorialController tutorial in tutorials) {
        tutorial.ShowTutorial();
      }
      tutorials[0].OnTutorialHidden += OnStart;
    }
  }

  public void OnStart () {
    #if TEST
    TimeManager.Instance.InitTimeAt(TimeToInit,indexAction);
    #else
    TimeManager.Instance.InitTime();
    #endif
    OnGameStart();
  }

  public void OnGameOver () {
		endAudio.Play();
    curtineController.CloseCurtine();
    TimeManager.Instance.StopTime();
    StartCoroutine(WaitAndReload(0));
  }

  public void OnGameFinished () {
    TimeManager.Instance.StopTime();
    StartCoroutine(WaitAndReload(1));
  }

	private IEnumerator WaitAndReload (int sceneIndex) {
		
    yield return new WaitForSeconds(3);
		SceneManager.LoadScene(sceneIndex);
  }

}
