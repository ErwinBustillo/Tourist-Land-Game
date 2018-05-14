using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof (AudioSource))]
public class AudioManager : MonoBehaviour {

	public AudioClip[] soundtracks; 
	private AudioSource audioSource;
	int index = 0;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.clip = soundtracks [index];
		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!audioSource.isPlaying) {
			index = Random.Range (0, soundtracks.Length) % soundtracks.Length;
			audioSource.clip = soundtracks [index];
			audioSource.Play ();
		}
	}
}
