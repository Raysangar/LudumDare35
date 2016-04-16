using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameControlManager : MonoBehaviour {

  [SerializeField]
  private CurtineController curtineController;

  [SerializeField]
  private FocusController focusController;

  private bool gameStarted = false;

  public delegate void GameStartEventHandler ();
  public event GameStartEventHandler OnGameStart = delegate {};

  private static GameControlManager instance;

  public static GameControlManager Instance {
    get { return instance; }
  }

	void Awake(){
		instance = this;
	}

  void Start () {
    LifeController.Instance.OnGameOver += OnGameOver;
    TimeManager.Instance.OnGameFinished += OnGameFinished;
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
    TimeManager.Instance.InitTime();
    OnGameStart();
  }

  public void OnGameOver () {
    curtineController.CloseCurtine();
    TimeManager.Instance.StopTime();
    StartCoroutine(WaitAndReload());
  }

  public void OnGameFinished () {
    TimeManager.Instance.StopTime();
    curtineController.CloseCurtine();
    StartCoroutine(WaitAndReload());
  }

  private IEnumerator WaitAndReload () {
    yield return new WaitForSeconds(3);
    SceneManager.LoadScene(0);
  }

}
