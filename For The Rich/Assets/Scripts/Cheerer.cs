using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cheerer : MonoBehaviour {

	static AudioSource ding;
	static Text text;
	static string[] cheers;
	static bool animate;

	float timer;

	// Use this for initialization
	void Start () {
		ding = GetComponent<AudioSource>();
		timer = 0f;
		text = GetComponent<Text>();
		cheers = new string[]{"", "GOOD START", "NOT BAD", "FEEL POWER", "NEED MORE", "YOU'RE RICH", 
			"LUXURY LIFE", "FAME&GLORY", "ALMOST PRESIDENT"};
	}

	void Update(){
		if (animate){
			text.enabled = true;
			timer += Time.deltaTime;
			if (timer > 1.8f){
				text.enabled = false;
				text.color = Color.white;
				timer = 0f;
				animate = false;
			}else{
				text.color -= Color.black * Time.deltaTime * 0.5f; 
			}
		}
	}

	public static void SetCheerer(int score){
		if (score < 1000){
			text.text = cheers[0];
			animate = true;
		}
		if (1000 <= score && score < 10000){
			text.text = cheers[1];
			if (!cheers[1].Equals("")){
				ding.Play();
			}
			cheers[1] = "";
			animate = true;
		}
		if (10000 <= score && score < 20000){
			text.text = cheers[2];
			if (!cheers[2].Equals("")){
				ding.Play();
			}
			cheers[2] = "";
			animate = true;
		}
		if (20000 <= score && score < 50000){
			text.text = cheers[3];
			if (!cheers[3].Equals("")){
				ding.Play();
			}
			cheers[3] = "";
			animate = true;
		}
		if (50000 <= score && score < 100000){
			text.text = cheers[4];
			if (!cheers[4].Equals("")){
				ding.Play();
			}
			cheers[4] = "";
			animate = true;
		}
		if (100000 <= score && score < 200000){
			text.text = cheers[5];
			if (!cheers[5].Equals("")){
				ding.Play();
			}
			cheers[5] = "";
			animate = true;
		}
		if (200000 <= score && score < 500000){
			text.text = cheers[6];
			if (!cheers[6].Equals("")){
				ding.Play();
			}
			cheers[6] = "";
			animate = true;
		}
		if (500000 < score && score < 1000000){
			text.text = cheers[7];
			if (!cheers[7].Equals("")){
				ding.Play();
			}
			cheers[7] = "";
			animate = true;
		}
	}
}
