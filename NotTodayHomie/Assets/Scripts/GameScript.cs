using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {
  public AudioSource sfxSource;
  public AudioClip gunShots;
  public AudioClip codeLockBeep;
  public AudioClip codeLockError;

  private string choice_1;
  private string choice_2;
  private string choice_3;
  private string chosen_choice;
  private string restart = "Restart from the beginning and choose wisely this time.";

  private string currentScene;
  public string displayText;

  private bool enteredBathroomAlready = false;
  private bool hasKey = false;
  private bool isGateOpen = false;
  private bool seenGag = false;

  private bool inputtingCode = false;
  private string digit1 = "_";
  private string digit2 = "_";
  private string digit3 = "_";
  private string digit4 = "_";
  private string correctCode = "0420";

  private KeyCode[] keyCodes = {
    KeyCode.Alpha0,
    KeyCode.Alpha1,
    KeyCode.Alpha2,
    KeyCode.Alpha3,
    KeyCode.Alpha4,
    KeyCode.Alpha5,
    KeyCode.Alpha6,
    KeyCode.Alpha7,
    KeyCode.Alpha8,
    KeyCode.Alpha9,
  };


  // Use this for initializaion
  void Start () {
    // Start
    currentScene = "Title Screen";
  }

  // Update is called once per frame
  void Update () {
    choice_1 = "NULL";
    choice_2 = "NULL";
    choice_3 = "NULL";

    switch(currentScene) {
      case "Title Screen":
        displayText = "Not Today Homie \n By Erich Chu \n \n Press enter to begin";
        if(Input.GetKeyDown(KeyCode.Return)) {
          currentScene = "Jail Cell";
        }
        break;
      case "NULL":
        displayText = "Where you trying to go homie?";
        break;
      case "Jail Cell":
        choice_1 = "Yell out \"YO what's going on?\"";
        choice_2 = "Shake the bars violently";
        if(chosen_choice != choice_1 && chosen_choice != choice_2) {
          displayText = "An alarm blares in the hallway. Oh sh**! Something's happening. You get up from your bed in your jumpsuit and grab the cell bars.";
        }
        else if(chosen_choice == choice_1){
          currentScene = "Jail Cell Scenario 1";
        }
        else if(chosen_choice == choice_2) {
          currentScene = "Jail Cell Scenario 2";
        }
        break;
      case "Jail Cell Scenario 1":
        choice_1 = "Call out to the silhouette to break you out";
        choice_2 = "Sit back in bed cause you think its a security guard and you remember your last beating.";
        if(chosen_choice != choice_1 && chosen_choice != choice_2) {
          displayText = "An inmate in the cell next to you calls out. \" Yo Tyrone. Someone broke into prison and is trying to bail out people.\" ";
          displayText += "\n At that instant, the silhouette of a man appears.";
        }
        else if(chosen_choice == choice_1) {
          currentScene = "Jail Cell Continue";
        }
        else if(chosen_choice == choice_2) {
          displayText = "You tuck yourself in and miss the greatest chance to taste freedom.";
          choice_1 = restart;
          choice_2 = "NULL";
        }
        break;
      case "Jail Cell Scenario 2":
        displayText = "A security guard appears and tases you. Knocked out for tonight, you missed your greatest chance to escape.";
        choice_1 = restart;
        choice_2 = "NULL";
        break;
      case "Jail Cell Continue":
        choice_1 = "Step outside.";
        if(chosen_choice != choice_1 && chosen_choice != choice_2) {
          displayText = "A man appears and opens your cage. \n\"No questions. Just go and free yourself.\"";
        }
        else if(chosen_choice == choice_1) {
          currentScene = "Hallway";
        }
        break;
      case "Hallway":
        choice_1 = "Run to the left staircase.";
        choice_2 = "Run to the right staircase.";
        if(chosen_choice != choice_1 && chosen_choice != choice_2) {
          displayText = "You look left and right. Which way do you run to?";
        }
        else if(chosen_choice == choice_1) {
          currentScene = "Mid Left Hallway";
        }
        else if(chosen_choice == choice_2) {
          currentScene = "Right Staircase";
        }
        break;
      case "Mid Left Hallway":
        choice_1 = "Continue running to the left staircase.";
        choice_2 = "Enter the bathroom real quick.";
        if(chosen_choice != choice_1 && chosen_choice != choice_2) {
          if(!enteredBathroomAlready) {
            displayText = "As you're running to the left staircase, you spot the bathroom.";
          }
          else {
            displayText = "Inmates can be seen running around everywhere but you know what you need to do.";
          }
        }
        else if(chosen_choice == choice_1) {
          currentScene = "Left Staircase";
        }
        else if(chosen_choice == choice_2) {
          enteredBathroomAlready = true;
          currentScene = "Bathroom";
        }
        break;
      case "Left Staircase":
        choice_1 = "Hide in the bathroom.";
        choice_2 = "Go down the staircase anyways.";
        choice_3 = "Run towards the right staircase.";
        if(chosen_choice != choice_1 && chosen_choice != choice_2 && chosen_choice != choice_3) {
          displayText = "You hear gunshots echoing in the staircase.";
          sfxSource.clip = gunShots;
          if (!sfxSource.isPlaying) {
            sfxSource.Play();
          }
        }
        else if(chosen_choice == choice_1) {
          currentScene = "Bathroom";
          enteredBathroomAlready = true;
        }
        else if(chosen_choice == choice_2) {
          currentScene = "Bottom Floor";
        }
        else if(chosen_choice == choice_3) {
          currentScene = "Right Staircase";
        }
        break;
      case "Bathroom":
        choice_1 = "Exit the bathroom. ";
        if(!hasKey) {
          choice_1 += "I ain't reaching down there.";
          choice_2 = "Inspect the light.";
        }
        if(chosen_choice != choice_1 && chosen_choice != choice_2) {
          displayText = "You see a guard lying on the floor unconcious. Meh, you need to pee anyways. ";
          if(!hasKey) {
            displayText += "As you finish peeing, a flicker of light from the guard's pocket catches your eye.";
          }
        }
        else if(chosen_choice == choice_1) {
          currentScene = "Mid Left Hallway";
        }
        else if(chosen_choice == choice_2) {
          currentScene = "Found Key";
        }
        break;
      case "Found Key":
        choice_1 = "Stop touching the man and return.";
        if(!hasKey) {
          displayText = "You found a key! Might as well keep it for now.";
          hasKey = true;
        }
        else {
          displayText = "Could you stop harassing the very vulnerable man?";
        }
        if(chosen_choice == choice_1) {
          currentScene = "Bathroom";
        }
        break;
      case "Bottom Floor":
        if(!hasKey) {
          choice_1 = "Return upstairs to search for key.";
          if(chosen_choice != choice_1) {
            displayText = "You see a door with a padlock. It looks like it requires a key to open it.";
          }
          else {
            currentScene = "Left Staircase";
          }
        }
        else {
          if(!isGateOpen) {
            choice_1 = "Input Code";
            choice_2 = "Return upstairs to find clues on the code";
            if(chosen_choice != choice_1 && chosen_choice != choice_2) {
              displayText = "You reach the bottom floor and see a gate with a code lock. Enter the 4 digit code.";
            }
            else if(chosen_choice == choice_1) {
              inputtingCode = true;
              currentScene = "Input Code";
            }
            else if(chosen_choice == choice_2) {
              currentScene = "Left Staircase";
            }
          }
          else {
            currentScene = "Input Code";
          }
        }
        break;
      case "Input Code":
        if(inputtingCode) {
          displayText = "Please enter ONLY numeric digits. \n \n";
          displayText += digit1 + " " + digit2 + " " + digit3 + " " + digit4 + "\n";
        }
        else {
          string inputtedCode = digit1 + digit2 + digit3 + digit4;
          if(inputtedCode == correctCode) {
            isGateOpen = true;
            choice_1 = "Open the gate.";
            choice_2 = "I kind of miss my bed. Go back up.";
            if(chosen_choice != choice_1 && chosen_choice != choice_2) {
              displayText = "The code lock flashes green! You're in.";
            }
            else if(chosen_choice == choice_1) {
              currentScene = "Opened Gate";
            }
            else if(chosen_choice == choice_2) {
              currentScene = "Left Staircase";
            }
          }
          else {
            choice_1 = "Retry code.";
            choice_2 = "Return upstairs to look for code";
            digit1 = "_";
            digit2 = "_";
            digit3 = "_";
            digit4 = "_";
            if(chosen_choice != choice_1 && chosen_choice != choice_2) {
              sfxSource.clip = codeLockError;
              if (!sfxSource.isPlaying) {
                sfxSource.Play();
              }
              displayText = "The code lock flashes red. Try again.";
            }
            else if(chosen_choice == choice_1) {
              inputtingCode = true;
              chosen_choice = "NULL";
              currentScene = "Input Code";
            }
            else if(chosen_choice == choice_2) {
              currentScene = "Left Staircase";
            }
          }
        }
        break;
      case "Opened Gate":
        choice_1 = "Run outside to freedom.";
        if(chosen_choice != choice_1) {
          displayText = "You see a shimmering light pouring from the gate as it opens.";
        }
        else {
          currentScene = "Courtyard - Game Over";
        }
        break;
      case "Courtyard - Game Over":
        choice_1 = "What a shame. Start all over again.";
        if(chosen_choice != choice_1) {
          displayText = "A line of policemen are waiting outside. ";
          displayText += "One of them snickers and says \"He thought he was going to escape that easily\". ";
          displayText += "Another policeman laughs and says \"Not today homie...not today.\"";
        }
        if(chosen_choice == choice_1) {
          digit1 = "_";
          digit2 = "_";
          digit3 = "_";
          digit4 = "_";
          enteredBathroomAlready = false;
          hasKey = false;
          isGateOpen = false;
          seenGag = false;
          currentScene = "Jail Cell";
        }
        break;
      case "Right Staircase":
        choice_1 = "Check out the room.";
        choice_2 = "Go downstairs.";
        choice_3 = "Run towards the left staircase.";
        if(chosen_choice != choice_1 && chosen_choice != choice_2 && chosen_choice != choice_3) {
          displayText = "At the right staircase, you see a dim lit room. Gunshots are heard.";
          sfxSource.clip = gunShots;
          if (!sfxSource.isPlaying) {
            sfxSource.Play();
          }
        }
        else if(chosen_choice == choice_1) {
          currentScene = "Dim Lit Room";
        }
        else if(chosen_choice == choice_2) {
          currentScene = "Right Staircase Downstairs";
        }
        else if(chosen_choice == choice_3) {
          currentScene = "Mid Left Hallway";
        }
        break;
      case "Dim Lit Room":
        choice_1 = "Examine the first board.";
        choice_2 = "Examine the second board.";
        choice_3 = "Go back outside.";
        if(chosen_choice != choice_1 && chosen_choice != choice_2 && chosen_choice != choice_3) {
          displayText = "";
          if(seenGag) {
            displayText += "Hm I wish I could read... \n\n";
          }
          displayText += "The room is filled with boards and a bunch of clutter. ";
          displayText += "You're not exactly educated so all you understand are numbers.";
        }
        else if(chosen_choice == choice_1) {
          currentScene = "Examine Board 1";
        }
        else if(chosen_choice == choice_2) {
          currentScene = "Examine Board 2";
        }
        else if(chosen_choice == choice_3) {
          currentScene = "Right Staircase";
        }
        break;
      case "Examine Board 1":
        choice_1 = "Return";
        if(chosen_choice != choice_1) {
          displayText = "Today's agenda: \n";
          displayText += "1. Slap Tyrone for no reason. \n";
          displayText += "2. Today feels like a yelling day for the prisoners. \n";
          displayText += "3. Find keys.";
          seenGag = true;
        }
        else {
          currentScene = "Dim Lit Room";
        }
        break;
      case "Examine Board 2":
        choice_1 = "Return";
        if(chosen_choice != choice_1) {
          displayText = "Lorem ipsum dolor sit amet, 0consectetur adipiscing elit. Donec4 mollis ex et nunc2 mattis porta. 0Nulla sodales, enim id facilisis ultrices, nulla arcu luctus risus, in imperdiet nibh augue et ex. Nulla sit amet auctor dolor, et ultrices ipsum.";
        }
        else {
          currentScene = "Dim Lit Room";
        }
        break;
      case "Right Staircase Downstairs":
        choice_1 = "NOPE NOPE - going back upstairs.";
        choice_2 = "Open the door.";
        if(chosen_choice != choice_1 && chosen_choice != choice_2) {
          displayText = "You feel a draft of air coming from a slightly opened door... ";
          displayText += "but it feels unpleasant. Gunshots can still be heard.";
          sfxSource.clip = gunShots;
          if (!sfxSource.isPlaying) {
            sfxSource.Play();
          }
        }
        else if(chosen_choice == choice_1) {
          currentScene = "Right Staircase";
        }
        else if(chosen_choice == choice_2) {
          currentScene = "Back Entrance of Outside";
        }
        break;
      case "Back Entrance of Outside":
        choice_1 = restart;
        if(chosen_choice != choice_1) {
          displayText = "The last thing you remember hearing is the gun shots getting louder. You're dead.";
        }
        else {
          currentScene = "Jail Cell";
        }
        break;
    }

    displayText += "\n \n";

    // Display Menu Options
    if(choice_1 != "NULL") {
      displayText += "Press corresponding number to select choice: \n";
      displayText += "1. " + choice_1 + "\n";
    }
    if(choice_2 != "NULL") {
      displayText += "2. " + choice_2 + "\n";
    }
    if(choice_3 != "NULL") {
      displayText += "3. " + choice_3 + "\n";
    }

    if(inputtingCode) {
      sfxSource.clip = codeLockBeep;
      for(int i = 0; i < keyCodes.Length; i++) {
        if(Input.GetKeyDown(keyCodes[i])) {
          if(digit1 == "_") {
            if (!sfxSource.isPlaying) {
              sfxSource.Play();
            }
            digit1 = i.ToString();
          }
          else if(digit2 == "_") {
            if (!sfxSource.isPlaying) {
              sfxSource.Play();
            }
            digit2 = i.ToString();
          }
          else if(digit3 == "_") {
            if (!sfxSource.isPlaying) {
              sfxSource.Play();
            }
            digit3 = i.ToString();
          }
          else if(digit4 == "_") {
            if (!sfxSource.isPlaying) {
              sfxSource.Play();
            }
            digit4 = i.ToString();
            inputtingCode = false;
          }
        }
      }
    }
    else {
      // Choices are available
      if(choice_1 != "NULL") {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
          chosen_choice = choice_1;
          if(chosen_choice == restart) {
            currentScene = "Jail Cell";
          }
        }
      }
      if(choice_2 != "NULL") {
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
          chosen_choice = choice_2;
        }
      }
      if(choice_3 != "NULL") {
        if(Input.GetKeyDown(KeyCode.Alpha3)) {
          chosen_choice = choice_3;
        }
      }
    }
    GetComponent<Text>().text = displayText;
  }
}
