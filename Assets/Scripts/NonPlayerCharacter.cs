using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour {
  private float _timerDisplay;

  public float DisplayTime = 4.0f;
  public GameObject DialogBox;

  // Start is called before the first frame update
  private void Start() {
    DialogBox.SetActive(false);
    _timerDisplay = -1.0f;
  }

  // Update is called once per frame
  private void Update() {
    if (_timerDisplay >= 0) {
      _timerDisplay -= Time.deltaTime;
      if (_timerDisplay < 0) {
        DialogBox.SetActive(false);
      }
    }
  }

  internal void DisplayDialog() {
    _timerDisplay = DisplayTime;
    DialogBox.SetActive(true);
  }
}
