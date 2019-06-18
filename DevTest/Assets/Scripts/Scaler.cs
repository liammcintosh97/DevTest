using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Scaler : MonoBehaviour
{
  public GameObject go;
  public Toggle toggle;
  [Space(6)]

  [Header("Variables")]
  public float minScale = 0;
  public float maxScale = 10;
  [Space(6)]

  [Header("Sliders")]
  public Slider xSlider;
  public Slider ySlider;
  public Slider zSlider;

  #region Unity
  // Start is called before the first frame update
  void Start(){
    InitSliders();
    InitToggle();
  }

  // Update is called once per frame
  void Update(){

  }
  #endregion

  #region Init

  private void InitSliders() {

    xSlider.minValue = minScale;
    ySlider.minValue = minScale;
    zSlider.minValue = minScale;

    xSlider.maxValue = maxScale;
    ySlider.maxValue = maxScale;
    zSlider.maxValue = maxScale;

    xSlider.value = 1;
    ySlider.value = 1;
    zSlider.value = 1;

    Scale();
  }

  private void InitToggle() {

    toggle.isOn = false;
  }
  #endregion

  #region Slider Methods

  public void OnXValueChange(){
    Scale();
  }

  public void OnYValueChange(){
    Scale();
  }

  public void OnZValueChange(){
    Scale();
  }

  public void OnXDrag(PointerEventData data)
  {
    Vector3 scale = go.transform.localScale;

    if (toggle.isOn)
    {
      float scaleDiff = scale.x - xSlider.value;

      ySlider.value += scaleDiff;
      zSlider.value += scaleDiff;
    }
  }

  public void OnYDrag(PointerEventData data)
  {
    Vector3 scale = go.transform.localScale;

    if (toggle.isOn)
    {
      float scaleDiff = scale.y - ySlider.value;

      zSlider.value += scaleDiff;
      xSlider.value += scaleDiff;
    }
  }

  public void OnZDrag(PointerEventData data){
    Vector3 scale = go.transform.localScale;

    if (toggle.isOn)
    {
      float scaleDiff = scale.z - zSlider.value;

      ySlider.value += scaleDiff;
      xSlider.value += scaleDiff;
    }
  }

  #endregion

  #region Private Methods

  private void Scale() {

    Vector3 scale = go.transform.localScale;
    Vector3 newScale = new Vector3(xSlider.value, ySlider.value, zSlider.value);

    go.transform.localScale = newScale;
  }

  #endregion
}
