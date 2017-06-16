using UnityEngine;
using System.Collections;

public class DogController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		Invoke ("positionchange", 1.0f);

	}

	void positionchange(){

		transform.position= new Vector3 (transform.position.x + Random.Range (-5, 5),0,0);
	}
}
