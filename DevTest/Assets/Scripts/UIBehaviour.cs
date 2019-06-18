using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
  public GameObject user;
  public Canvas canvas;
  public RectTransform rectTransform;

  private enum UIType { NULL, WORLD, SCREEN };
  private UIType uiType = UIType.SCREEN;

  // Start is called before the first frame update
  void Start(){
    SwitchScreenUI();
  }

  // Update is called once per frame
  void Update(){

  }

  #region Button Methods

  public void OnSwitchUIPress() {

    if (uiType == UIType.SCREEN){
      SwitchWorldUI();
    }
    else if (uiType == UIType.WORLD) {
      SwitchScreenUI();
    }

  }

  #endregion

  #region Private Methods

  private void UserInput() {

    if (Input.GetKeyDown(KeyCode.P)) {
      OnSwitchUIPress();
    }
  }

  private void SwitchWorldUI() {
    uiType = UIType.WORLD;
    canvas.renderMode = RenderMode.WorldSpace;

    //Set positon and scale of canvas
    rectTransform.position = user.transform.position + (Vector3.forward * 2) ;
    rectTransform.rotation = user.transform.rotation;
    rectTransform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
  }

  private void SwitchScreenUI() {
    uiType = UIType.SCREEN;
    canvas.renderMode = RenderMode.ScreenSpaceOverlay;
  }

  #endregion
}
