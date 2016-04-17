using UnityEngine;
using System.Collections;

public class CameraAnimation : MonoBehaviour {

  [SerializeField]
  Transform origin;

  [SerializeField]
  Transform target;
	
  void OnEnable () {
    GameControlManager.Instance.OnGameStart += OnPlay;
  }

  void OnDisable () {
    GameControlManager.Instance.OnGameStart -= OnPlay;
  }

  public void OnPlay () {
    
  }

}
