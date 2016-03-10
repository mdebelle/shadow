using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {
	
	public GameObject		piece1;
	public GameObject		piece2;
	public int				level;
	
	public GameObject		shadowhelp;
	bool					help;

	static public LevelManager lman;

	Dictionary<string, bool> axes = new Dictionary<string, bool>();

	// Use this for initialization
	void Start () {

		help = false;

		Vector3 euler = transform.eulerAngles;
		
		Vector3 position = Vector3.zero;

		euler.y = Random.Range(0f, 360f);
		
		if (level > 1 ) {
			euler.x = Random.Range(0f, 360f);
		}
		if (level > 2 ) {
			position.x = Random.Range(-5f, 5f);
			position.y = Random.Range(-5f, 5f);
		}
		
		piece1.transform.eulerAngles = euler;
		piece1.transform.position = position;
		
		axes.Add ("x", false);
		axes.Add ("y", false);
		axes.Add ("z", false);

		lman = this.GetComponent<LevelManager> ();

	}


	// Update is called once per frame
	void Update () {

		if (axes ["x"] == true && axes ["y"] == true && axes ["z"] == true) {

			piece1.GetComponent<Moveobject>().setsolved();
			Debug.Log ("You Win");

		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			changeHelpMode();
		}
	


	}

	void	changeHelpMode(){

		if (help == true) {
			help = false;
			shadowhelp.SetActive(false);
		} else {
			help = true;
			shadowhelp.SetActive(true);
		}
		return;
	}
	
	
	public void		setlock(string axe, bool state) {

		axes[axe] = state;

	}

	public bool		ishard()
	{
		if (level == 3)
			return true;
		else
			return false;
	}

	
	public bool		ismedium()
	{
		if (level >= 2)
			return true;
		else
			return false;
	}
}
