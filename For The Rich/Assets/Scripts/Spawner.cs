using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] cube;
	public float spawnTime;

	float timer;

	// Use this for initialization
	void Start () {
		timer = spawnTime;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > spawnTime){
			Instantiate(cube[Random.Range(0, cube.Length)]);
			timer = 0f;
		}
	}
}
