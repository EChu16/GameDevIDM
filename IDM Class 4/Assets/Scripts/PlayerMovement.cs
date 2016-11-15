using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
  private Transform myTransform;
  Vector3 forward;

  public float playerSpeed = 20;

  // Use this for initialization
  void Start () {
    myTransform = GetComponent<Transform>();
  }

  // Update is called once per frame
  void Update () {
    // Key movement
    if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
      myTransform.position += transform.forward * Time.deltaTime * playerSpeed;
    }
    if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
      myTransform.position -= transform.right * Time.deltaTime * playerSpeed;
    }
    if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
      myTransform.position -= transform.forward * Time.deltaTime * playerSpeed;
    }
    if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
      myTransform.position += transform.right * Time.deltaTime * playerSpeed;
    }
  }
}
