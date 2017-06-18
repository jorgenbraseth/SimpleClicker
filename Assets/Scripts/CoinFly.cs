using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFly : MonoBehaviour {

	public AudioClip[] sounds;

	void Awake() {
		AudioSource audio = GetComponent<AudioSource> ();
		int chosenClip = Random.Range (0, sounds.Length - 1);
		audio.clip = sounds [chosenClip];
		audio.Play();
	
	}
	public void Die() {
		Destroy (gameObject);
	}
		
}
