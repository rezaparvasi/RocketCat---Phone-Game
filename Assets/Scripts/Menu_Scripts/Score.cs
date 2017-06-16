using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	//this.Texture = "hello";
	Text txt;
	// Use this for initialization
	void Start () {
		txt = gameObject.GetComponent<Text>(); 
		txt.text="Your score is: " + PlayerStats.Points.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
