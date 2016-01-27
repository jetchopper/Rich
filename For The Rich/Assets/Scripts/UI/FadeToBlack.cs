using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour {

	int nextLevel;
	Image image;
	bool open, close;

	// Use this for initialization
	void Awake () {
		image = GetComponent<Image>();
		open = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (open){
			image.enabled = true;
			image.color -= Color.black * Time.deltaTime;
			if (image.color.a <= 0){
				image.enabled = false;
				open = false;
			}
		}
		if (close){
			image.enabled = true;
			image.color += Color.black * Time.deltaTime;
			if (image.color.a >= 1){
				if(nextLevel < 0){
					Application.Quit();
				}else{
					close = false;
					Destroy(GameObject.FindGameObjectWithTag("Respawn"));
					Application.LoadLevel(nextLevel);
				}
			}
		}
	}

	public void Fade(int level){
		if (!open && !close){
			nextLevel = level;
			close = true;
		}
	}
}
