using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public FadeToBlack fade;

	/*void Awake(){
		PlayerPrefs.DeleteAll();
	}*/

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) 
			fade.Fade(-1); 
	}

	public void LoadSandboxLevel(){
		fade.Fade(1);
	}

	public void LoadTimeLevel(){
		fade.Fade(2);
	}
}
