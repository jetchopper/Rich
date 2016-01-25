﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public GameObject cheererObj;

	public bool sandbox;

	static Text text;
	static float effectTimer;
	static bool scoreSet;
	static string sandOrTimer;

	RectTransform rect;
	Vector3 initScale;

	// Use this for initialization
	void Awake () {
		text = GetComponent<Text>();
		text.text = sandbox ? PlayerPrefs.GetString("score") : "";
		effectTimer = 0;
		rect = GetComponent<RectTransform>();
		initScale = rect.localScale;
		sandOrTimer = sandbox ? "score" : "empty";
	}

	void Update(){
		if (scoreSet){
			effectTimer += Time.deltaTime;
			if (effectTimer < 0.1f){
				rect.localScale += Vector3.one * Time.deltaTime;
			}
			if (effectTimer > 0.1f && effectTimer < 0.2f){
				rect.localScale -= Vector3.one * Time.deltaTime;
			}
			if (effectTimer > 0.2f){
				rect.localScale = initScale;
				effectTimer = 0f;
				scoreSet = false;
			}
		}
	}

	public static void SetScore(float cost){
		if (text.text.Equals("")){
			text.text = "0";
		}
		text.text = "" + (int.Parse(text.text) + (cost));
		PlayerPrefs.SetString(sandOrTimer, text.text);
		scoreSet = true;
		if (sandOrTimer.Equals("score")){
			Cheerer.SetCheerer(int.Parse(text.text));
		}
	}
}
