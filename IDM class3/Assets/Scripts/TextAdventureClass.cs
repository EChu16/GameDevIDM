using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextAdventureClass : MonoBehaviour {
  public string currentRoom;
  public Camera mainCam;
  private bool haskey = false;
  public AudioSource sfxSource;

  // Use this for initialization
  void Start () {
    //Hello
    GetComponent<Text>().text = "We ran our scene";
    currentRoom = "Initial";
  }
  // Update is called once per fram
  void Update () {
    if(Input.GetKeyDown(KeyCode.Space)) {
      if(currentRoom == "Initial") {
        GetComponent<Text>().text = "Welcome to the Lobby";
        currentRoom = "Lobby";
      }
      else if(currentRoom == "Lobby") {
        GetComponent<Text>().text = "You're back in the entryway";
        currentRoom = "Initial";
      }
      else if(currentRoom == "Kitchen") {
        currentRoom = "Kitchen";
      }
    }
    /*
    if get key, sfxSource.play()
    */
  }
}
