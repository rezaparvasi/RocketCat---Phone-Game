using UnityEngine;
using System.Collections;

public class ParticleSortingLayerFIx : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Player";
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = -1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
