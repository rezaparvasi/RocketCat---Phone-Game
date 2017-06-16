using UnityEngine;
using System.Collections;

public class WaitForSecondsExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Example());
	}

	public static IEnumerator Example() {
		print(Time.time);
		yield return new WaitForSeconds(2);
		print(Time.time);
	}

}
