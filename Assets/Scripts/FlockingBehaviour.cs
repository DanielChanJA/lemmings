using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingBehaviour : MonoBehaviour {

	[Header("Flock Settings")]
	public int flockSize;
	public Vector3 spawnLocation;
	public int spawnRadius;
	public GameObject lemming;

	public List<GameObject> lemmings;
	

	// Use this for initialization
	void Start () {
		lemmings = new List<GameObject>();
		Debug.Log(lemmings);
		for(int i = 0; i < flockSize; i++) {
			GameObject tempLemming = GameObject.Instantiate(lemming);
			tempLemming.transform.position = new Vector3(
				Random.Range(spawnLocation.x - spawnRadius, spawnLocation.x + spawnRadius), 
				spawnLocation.y, 
				Random.Range(spawnLocation.z - spawnRadius, spawnLocation.z + spawnRadius));
			lemmings.Add(tempLemming);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
