using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

  [SerializeField]
  private CurtineController curtineController;

  private bool gameStarted = false;

  public delegate void GameStartEventHandler ();
  public event GameStartEventHandler OnGameStart = delegate {};

  private static GameManager instance;

  public static GameManager Instance {
    get { return instance; }
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
