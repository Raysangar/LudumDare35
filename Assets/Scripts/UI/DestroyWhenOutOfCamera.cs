using UnityEngine;
using System.Collections;

public class DestroyWhenOutOfCamera : MonoBehaviour {

  private float screenWidth;

  private RectTransform rectTransform;

  public delegate void OutsideOfCameraEventHandler(RectTransform rectTransform);
  public event OutsideOfCameraEventHandler OnOutsideOfCamera = delegate{};

  void Start () {
    rectTransform = GetComponent<RectTransform>();
    screenWidth = Screen.width;
  }

  void FixedUpdate () {
    if (rectTransform.localPosition.x < - (Screen.width/2 + rectTransform.rect.width)) {
      OnOutsideOfCamera(rectTransform);
      GameObject.Destroy(gameObject);
    }
  }
}
