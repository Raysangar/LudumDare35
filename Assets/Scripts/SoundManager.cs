using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

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
  private AudioSource crwod;

  private static SoundManager instance;
  private LifeController lifeController;

  void Awake () {
    instance = this;
  }

  void Start () {
    lifeController = LifeController.Instance;
  }

  public static SoundManager Instance {
    get { return instance; }
  }

  void Update () {
    crwod.volume =  (lifeController.MaxLife/2 - lifeController.CurrentLife) / (lifeController.MaxLife/2);
  }

  public void PlayApplause() {
    if (lifeController.MaxLife * 0.8f < lifeController.CurrentLife) {
      applause2.Play();
    } else if (lifeController.MaxLife * 0.6f < lifeController.CurrentLife) {
      applause1.Play();
    }
  }

  public void PlayBoo() {
    if (lifeController.MaxLife * 0.2f > lifeController.CurrentLife) {
      boo2.Play();
    } else if (lifeController.MaxLife * 0.4f > lifeController.CurrentLife) {
      boo1.Play();
    }
  }

}
