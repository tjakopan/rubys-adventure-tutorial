using System;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour {
  internal static UIHealthBar Instance { get; private set; }

  private float _originalSize;

  public Image Mask;

  private void Awake() {
    Instance = this;
  }

  // Start is called before the first frame update
  private void Start() {
    _originalSize = Mask.rectTransform.rect.width;
  }

  internal void SetValue(float value) {
    Mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _originalSize * value);
  }
}
