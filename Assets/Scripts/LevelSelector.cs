using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnClick () {
		if (gameObject.tag == "Level1") {
			Debug.Log ("Level 1 selected");
			PlayerPrefs.SetInt ("level", 1);
			PlayerPrefs.Save ();
		}else if (gameObject.tag == "Level2") {
			Debug.Log ("Level 2 selected");
			PlayerPrefs.SetInt ("level", 2);
			PlayerPrefs.Save ();
		}else if (gameObject.tag == "Level3") {
			Debug.Log ("Level 3 selected");
			PlayerPrefs.SetInt ("level", 3);
			PlayerPrefs.Save ();
		}else if (gameObject.tag == "Level4") {
			Debug.Log ("Level 4 selected");
			PlayerPrefs.SetInt ("level", 4);
			PlayerPrefs.Save ();
		}else if (gameObject.tag == "Level5") {
			Debug.Log ("Level 5 selected");
			PlayerPrefs.SetInt ("level", 5);
			PlayerPrefs.Save ();
		}else if (gameObject.tag == "Level6") {
			Debug.Log ("Level 6 selected");
			PlayerPrefs.SetInt ("level", 6);
			PlayerPrefs.Save ();
		}
		SceneManager.LoadScene ("Game");
		//Application.LoadLevel ("Game");
	}
}
