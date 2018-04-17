using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource audioSource;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
	}
	
	void Start (){
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	// Update is called once per frame
	void OnLevelWasLoaded (int level) {
		AudioClip thisLvlMusic = levelMusicChangeArray[level];
		if (thisLvlMusic) { //if music is attached to this level
			audioSource.clip = thisLvlMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	
	public void ChangeVolume (float vol) {
		audioSource.volume = vol;
	}
}


//    <>