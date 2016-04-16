using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

  [SerializeField]
  private AudioSource aplauso1;

  [SerializeField]
  private AudioSource aplauso2;

  [SerializeField]
  private AudioSource abucheo1;

  [SerializeField]
  private AudioSource abucheo2;

  [SerializeField]
  private AudioSource silence;

  private static SoundManager instance;

  void Awake () {
    instance = this;
  }

  public static SoundManager Instance {
    get { return instance; }
  }

}
