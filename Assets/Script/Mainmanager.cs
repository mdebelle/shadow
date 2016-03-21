using UnityEngine;
using System.Collections;

public class Mainmanager : MonoBehaviour {

	public	GameObject[]	Levels;
	bool					slide;

	float					mousex;
	int						currentlevel;


	// Use this for initialization
	void Start () {

		if (PlayerPrefs.GetInt("Ok") != 1){
			setDefaultData();
		} else {
			getDefaultData();
		}

		slide = false;

	}
	
	void	setDefaultData(){
		return;
	}
	
	void	getDefaultData(){

		
		for (int i = 0; i < Levels.Length; i++) {
			Levels[i].GetComponent<levelselector>().setlevelinfo(PlayerPrefs.GetInt ("Level"+i));
		}
		return;
	}


	public void		resetAllData(){

		PlayerPrefs.DeleteAll();
		PlayerPrefs.Save ();
		
		PlayerPrefs.SetInt ("Level0", 0);
		PlayerPrefs.SetInt ("Level1", -1);
		PlayerPrefs.SetInt ("Level2", -1);
		PlayerPrefs.SetInt ("Level3", -1);

		PlayerPrefs.SetInt("Ok", 1);
		PlayerPrefs.Save ();
		return;
	}

	// Update is called once per frame
	void Update () {
	
	}

}
