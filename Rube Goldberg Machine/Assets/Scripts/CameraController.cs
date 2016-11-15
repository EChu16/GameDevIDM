using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
  public GameObject[] Cameras;
  private int currentCam;

  void Start () {
    DeactivateCameras();
    Cameras[0].SetActive(true);
    currentCam = 0;
  }

  void Update () {
    if (Input.GetKeyDown(KeyCode.Return))
    {
      DeactivateCameras();
      if (currentCam < Cameras.Length - 1) {
        currentCam +=1;
      } else {
        currentCam = 0;
      }
      Cameras[currentCam].SetActive(true);
    }
  }

	public void activateCamera(int _camNumber){
    Cameras[_camNumber - 1].SetActive(true);
    currentCam = _camNumber - 1;
  }

  public void DeactivateCameras()
  {
    for (int i = 0; i < Cameras.Length; i++)
    {
      Cameras[i].SetActive(false);
    }
  }
}
