using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quitGame : MonoBehaviour
{

  public void QuitGame (){

  	Debug.Log("QUIT"); //lets us know if its quit properly

  	//UnityEditor.EditorApplication.isPlaying = false; ONLY DO THIS IF YOU WANT TO QUIT IN THE EDITOR ONLY. THIS WILL NOT RUN IN THE BUILD.
  	Application.Quit();

  }
}
