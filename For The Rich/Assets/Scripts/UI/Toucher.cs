using UnityEngine;
using System.Collections;

public class Toucher : MonoBehaviour  {

	public BladeRotate bladeL;
	public BladeRotate1 bladeR;
	public float scissorsClosePercent;

	float gainedPercent, screenPercent;

	void Awake(){
		gainedPercent = 0f;
		screenPercent = Screen.height / 100;
	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
			gainedPercent += Input.GetTouch(0).deltaPosition.y / screenPercent * 100;
			if (gainedPercent > scissorsClosePercent){
				gainedPercent = scissorsClosePercent;
			}
			if (gainedPercent < 0){
				gainedPercent = 0;
			}
			bladeL.StartRotate(gainedPercent);
			bladeR.StartRotate(gainedPercent);
		}
		if (Input.touchCount == 0 && gainedPercent > 0){
			gainedPercent -= Time.deltaTime * 1000;
			if (gainedPercent < 0){
				gainedPercent = 0;
			}
			bladeL.StartRotate(gainedPercent);
			bladeR.StartRotate(gainedPercent);
		}
	}
}
