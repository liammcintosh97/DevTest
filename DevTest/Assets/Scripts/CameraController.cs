using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  [Header("Movement")]
  public float maxSpeed;
  public float accel;
  [Space(6)]

  [Header("Camera")]
  public float lookSpeed;

  private float speed;

  #region Unity

  // Start is called before the first frame update
  void Start(){

  }

  // Update is called once per frame
  void FixedUpdate(){
    UserInput();
  }

  #endregion

  #region public Methods

  public void Move(Vector3 dir,float inputAxis) {
    Accelarate();
    transform.Translate((inputAxis * dir) * speed, Space.Self);
  }

  public void Look(Vector3 mousePos) {

    mousePos.z = 1f;
    Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);

    transform.LookAt(objectPos * 0.5f);
  }

  #endregion

  #region Private Methods

  private void UserInput() {

    float inputAxis = 0;

    //Vertical Input
    inputAxis = Input.GetAxis("Vertical");
    Move(Vector3.forward, inputAxis);

    //Horizontal Input
    inputAxis = Input.GetAxis("Horizontal");
    Move(Vector3.right, inputAxis);

    //Mouse Input
    if (Input.GetMouseButton(0)) {
      Look(Input.mousePosition);
    }

  }

  private void Accelarate() {
    speed += accel * Time.deltaTime;
    speed = Mathf.Clamp(speed, 0, maxSpeed);
  }

  #endregion
}
