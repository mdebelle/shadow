using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {


	public GameObject		piece1;

	// Use this for initialization
	void Start () {
		Vector3 euler = transform.eulerAngles;
		euler.y = Random.Range(0f, 360f);
		piece1.transform.eulerAngles = euler;

	}
	
	// Update is called once per frame
	void Update () {
	


	}
}
