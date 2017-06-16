using UnityEngine;
using System.Collections;

public class Logo_Rotation : MonoBehaviour {
	public float Rotation_SPEED = 90.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate (0, 0, -1*Rotation_SPEED * Time.deltaTime);
	}
}
