using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Example());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Example()
    {

        yield return new WaitForSeconds(5);
		Destroy(gameObject);
    }
}
