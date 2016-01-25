using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour {

	public int initTime;
	public Toucher toucher;
	public Text score;
	public FadeToBlack fade;

	AudioSource ding;
	Text text;
	float timer;
	bool start;

	// Use this for initialization
	void Awake () {
		ding = GetComponent<AudioSource>();
		text = GetComponent<Text>();
		text.text = "" + initTime;
		timer = 0f;
		start = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (start){
			timer += Time.deltaTime;
			text.text = "" + (initTime - (int) timer);
		}
		if (text.text.Equals("0")){
			toucher.enabled = false;
			start = false;
			if (score.text.Equals("")){
				score.text = "0";
			}
			if (PlayerPrefs.GetInt("timeRecord") < int.Parse(score.text)){
				PlayerPrefs.SetInt("timeRecord", int.Parse(score.text));
				fade.Fade(0);
			}else{
				fade.Fade(0);
			}
		}
	}

	public void StartCountdown(){
		start = true;
		ding.Play();
	}
}
