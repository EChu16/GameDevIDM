using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {

  Vector3 destination;
  Vector3 move;

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {
    if(Input.GetMouseButton(0)) {
      RaycastHit hit;
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      if(Physics.Raycast(ray, out hit) && hit.collider.tag == "ground") {
        destination = hit.point;
        //transform.position = destination;
        transform.position = Vector3.Lerp(transform.position, destination, .2f);

        move = destination - transform.position;
        move = move.normalized;
      }
    }
    transform.position += move;
  }
}
