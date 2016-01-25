using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadyCountdown : MonoBehaviour {

	public Stopwatch stopwatch;

	float timer;
	Text text;

	// Use this for initialization
	void Awake () {
		timer = 0.5f;
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if ((int) timer == 1){
			text.text = "3";
		}
		if ((int) timer == 2){
			text.text = "2";
		}
		if ((int) timer == 3){
			text.text = "1";
		}
		if ((int) timer == 4){
			if (stopwatch != null){
			stopwatch.StartCountdown();
			}
			Destroy(gameObject);
		}
	}
}
