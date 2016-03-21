using UnityEngine;
using System.Collections;

public class cameramove : MonoBehaviour {

	float			mousex;
	int				current;
	int				target;
	public int		max;

	float			speed;

	float			posz;

	// Use this for initialization
	void Start () {
	
		current = 0;
		target = 0;
		speed = 3f;
		posz = transform.position.z;
	}



	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) {
			mousex = Input.mousePosition.x;
		}
		if (Input.GetMouseButtonUp (0)) {
			slidecamera(mousex - Input.mousePosition.x);
		}

		Vector3 t = new Vector3(transform.position.x, transform.position.y, target * 3f - 1f);
		transform.position = Vector3.MoveTowards (transform.position, t, speed * Time.deltaTime);

		if (posz == transform.position.z) {
			Mainmanager.mman.setslide(false);
			Mainmanager.mman.setcurrentlevelfocus(current);

		} else {
			posz = transform.position.z;
			Mainmanager.mman.setslide(true);
		}

	}

	void	slidecamera(float direction){

		if (direction < 0) {
			target = (current > 0) ? current - 1 : current;
		} else if (direction > 0) {
			target = (current < max) ? current + 1 : (max - 1);
		}
		current = target;
	}
}
