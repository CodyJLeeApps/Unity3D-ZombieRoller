using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject selectedZombie;
	public List<GameObject> zombies;
	public Vector3 selectedSize;
	public Vector3 defaultSize;
	public Text scoreText;

	private int selectedZombiePos = 0;
	private int score = 0;

	// Use this for initialization
	void Start () {

		// Initializing
		SelectZombie (zombies [selectedZombiePos]);
		scoreText.text = "Score: " + score;

	} // End of Start()
	
	// Update is called once per frame
	void Update () {

		// Getting user arrow key input
		if (Input.GetKeyDown ("left")) {
			getZombieLeft ();
		}
		if (Input.GetKeyDown ("right")) {
			getZombieRight ();
		}
		if (Input.GetKeyDown ("up")) {
			PushUp ();
		}
		if (Input.GetKeyDown ("down")) {
			// Do nothing for now
		}


	} // End of Update()


	// SelectZombie()
	void SelectZombie(GameObject newZombie) {
		
		selectedZombie.transform.localScale = defaultSize;	// old selected zombie
		selectedZombie = newZombie; // moving zombie reference to the newly selected zombie
		newZombie.transform.localScale = selectedSize;	// increasing the zombie size
		 
	} // End SelectZombie()

	// create buttonPressed Function

	void getZombieLeft() {

		GameObject newSelectedZombie;
		if (selectedZombiePos == 0) {	// If we have the leftmost zombie selected, select the last zombie
			selectedZombiePos = (zombies.Count - 1);			// point to the last item in the zombie aray
			newSelectedZombie = zombies [selectedZombiePos];	// point to the zombie in the last location of the array
			SelectZombie (newSelectedZombie);
		} else {	// otherwise, we want to select the zombie to the left of our current position
			selectedZombiePos = (selectedZombiePos - 1); 				// subtract 1 from the current position
			newSelectedZombie = zombies [selectedZombiePos];	// point to the zombie at the new location
			SelectZombie (newSelectedZombie);
		} // End of if(selectesZombiePos == 0)

	} // End of getZombieLeft()

	void getZombieRight() {

		GameObject newSelectedZombie;
		if (selectedZombiePos == (zombies.Count - 1)) {	// If we have the leftmost zombie selected, select the last zombie
			selectedZombiePos = 0;				// point to starting position
			newSelectedZombie = zombies [0];	// point at first zombie
			SelectZombie (newSelectedZombie);
		} else {	// otherwise, we want to select the zombie to the left of our current position
			selectedZombiePos = (selectedZombiePos + 1); 				// add 1 to the the current position
			newSelectedZombie = zombies [selectedZombiePos];	// point to the zombie at the new location
			SelectZombie (newSelectedZombie);
		} // End of if(selectesZombiePos == 0)

	} // End of getZombieLeft()

	void PushUp() {
		Rigidbody rb = selectedZombie.GetComponent<Rigidbody> ();	// grab the rigid body of the selectedZombie
		rb.AddForce(0,0,10, ForceMode.Impulse);
	}

	public void AddPoint() {

		score = score + 1;
		scoreText.text = "Score: " + score;

	}
}
