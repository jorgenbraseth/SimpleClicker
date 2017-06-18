using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioClip error;
	public AudioClip build;
	public AudioClip upgrade;

	public void PlayError(){
		PlaySound (error);
	}

	public void PlayBuild(){
		PlaySound (build);
	}

	public void PlayUpgrade(){
		PlaySound (upgrade);
	}
	
	public void PlaySound(AudioClip sound) {
		GetComponent<AudioSource> ().clip = sound;
		GetComponent<AudioSource> ().Play ();

	}
}
