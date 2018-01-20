using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingBehaviour : MonoBehaviour {

	[Header("Flock Settings")]
	public int flockSize;
	public Vector3 spawnLocation;
	public int spawnRadius;
	public float spawnInterval;
	public bool spawnOnSelf;
	public GameObject lemming;

	private List<GameObject> lemmings;
	private float remainingTime;


	// Use this for initialization
	void Start () {

		if(spawnOnSelf) {
			spawnLocation = transform.position;
		}

		lemmings = new List<GameObject>();
		Spawn();
	}
	
	// Update is called once per frame
	void Update () {
		if(spawnInterval != 0) {
			remainingTime -= Time.deltaTime;
			if(remainingTime <= 0.0f) {
				Spawn();
			}
		}
	}

	void Spawn() {
		for(int i = 0; i < flockSize; i++) {
			GameObject tempLemming = GameObject.Instantiate(lemming);
			tempLemming.transform.position = new Vector3(
				Random.Range(spawnLocation.x - spawnRadius, spawnLocation.x + spawnRadius), 
				spawnLocation.y, 
				Random.Range(spawnLocation.z - spawnRadius, spawnLocation.z + spawnRadius));
			lemmings.Add(tempLemming);
		}

		remainingTime = spawnInterval;

	}
}
