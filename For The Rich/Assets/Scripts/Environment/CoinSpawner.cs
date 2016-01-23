using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour {

	public GameObject[] coins;
	public float spawnTime;
	
	float timer;
	Vector3 randomPos;
	
	// Use this for initialization
	void Awake () {
		timer = spawnTime;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > spawnTime){
			randomPos = new Vector3 (Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
			Instantiate(coins[Random.Range(0, coins.Length)], randomPos, Quaternion.identity);
			timer = 0f;
		}
	}
}
