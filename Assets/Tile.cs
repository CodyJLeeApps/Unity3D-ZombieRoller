using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public GameManager gameManager;
	public AudioClip hit;
	AudioSource source;

	// Use this for initialization
	void Start () {

		source = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		gameManager.AddPoint ();
		source.PlayOneShot (hit);
	}

}