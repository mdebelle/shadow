using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {


	public GameObject key;


	void	OnTriggerEnter(Collider other) {
		Debug.Log (other.name);
	}

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
}
