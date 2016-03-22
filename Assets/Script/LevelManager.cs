using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public int				nbpuzzle = 1;

	public GameObject		piece1;
	bool					p1 = false;
	public GameObject		piece2;
	bool					p2 = true;
	public int				level;
	
	public GameObject		shadowhelp;
	bool					help;

	public int						puzzle_number;

	static public LevelManager lman;

	Dictionary<string, bool> axes = new Dictionary<string, bool>();

	// Use this for initialization
	void Start () {

		help = false;

		axes.Add ("x1", false);
		axes.Add ("y1", false);
		axes.Add ("z1", false);
		
		piece1.transform.eulerAngles = setAngle (piece1);		
		piece1.transform.position = setPosition(piece1);

		if (nbpuzzle == 2) {

			axes.Add ("x2", false);
			axes.Add ("y2", false);
			axes.Add ("z2", false);

			piece2.transform.eulerAngles = setAngle (piece2);
			piece2.transform.position = setPosition(piece2);
			p2 = false;
		}
		lman = this.GetComponent<LevelManager> ();

	}


	// Update is called once per frame
	void Update () {
		
		if (axes ["x1"] == true && axes ["y1"] == true && axes ["z1"] == true) {
			piece1.GetComponent<Moveobject>().setsolved();
			Debug.Log ("yolo 1");
			p1 = true;
		}
		if (nbpuzzle == 2 && axes ["x2"] == true && axes ["y2"] == true && axes ["z2"] == true) {
			piece2.GetComponent<Moveobject>().setsolved();
			Debug.Log ("yolo 2");
			p2 = true;
		}

		if (p1 && p2) {
			
			if (PlayerPrefs.GetInt("chief") == 0) {
				PlayerPrefs.SetInt("Level"+puzzle_number, 1);
				if ( puzzle_number < 3 && PlayerPrefs.GetInt("Level"+(puzzle_number+1)) == -1) {
					PlayerPrefs.SetInt("Level"+(puzzle_number+1), 0);
				}
				PlayerPrefs.Save ();
			}
			Application.LoadLevel(0);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			changeHelpMode();
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel(0);
		}


	}

	//BACKGROUND
	// rgb(52, 73, 94)
	// rgb(44, 62, 80)

	//BLOCKED
	// rgb(231, 76, 60)
	// rgb(192, 57, 43)

	//CURRENT
	// rgb(241, 196, 15)
	// rgb(230, 126, 34)

	//SUCCED
	// rgb(26, 188, 156)
	// rgb(39, 174, 96)

	//CHIEF
	// rgb(142, 68, 173)
	// rgb(236, 240, 241)

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

	Vector3		setAngle(GameObject piece){

		Vector3 euler = piece.transform.eulerAngles;

		euler.y = Random.Range (0f, 360f);
		if (level > 1) {
			euler.x = Random.Range (0f, 360f);
		}
		
		return euler;
	}

	Vector3 	setPosition(GameObject piece){
	
		Vector3 position = piece.transform.position;

		if (level > 2 ) {
			position.x = Random.Range(-5f, 5f);
			position.y = Random.Range(-5f, 5f);
		}

		return position;
	}

	public void		setlock(string axe, int piecenbr, bool state) { 

		string key = axe + piecenbr;
		axes[key] = state;

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
