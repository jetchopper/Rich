using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public FadeToBlack fade;

	AudioSource clickSound;

	void Awake(){
		//PlayerPrefs.DeleteAll();
		clickSound = GetComponent<AudioSource>();
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) 
			fade.Fade(-1); 
	}

	public void LoadSandboxLevel(){
		clickSound.Play();
		fade.Fade(1);
	}

	public void LoadTimeLevel(){
		clickSound.Play();
		fade.Fade(2);
	}
}
