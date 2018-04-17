using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	// Use this for initialization
	public static void SetMasterVolume (float volume) {
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		}else {Debug.LogError("Master Volume out of range!");}
	}
	
	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}
	
	
	public static void UnlockLevel (int level) {
		if (level <= Application.levelCount -1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(), 1); //use 1 for true 0 for false
		}else {Debug.LogError("Trying to unlock level not in Build order - Out of range!");}
	}
	
	
	public static bool IsLevelUnlocked (int level) {
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString());
		bool bIsLevelUnlocked = (levelValue == 1);
		
		if (level <= Application.levelCount -1 ) {
			return bIsLevelUnlocked;
		}else {
		Debug.LogError("Trying to unlock level not in Build order - Out of range!");
		return false;
		}
	}
	
	
	public static void SetDifficulty (float diff) {
		if (diff >= 1f && diff <= 3f) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, diff);
		}else {Debug.LogError("Difficulty out of range!");}
	}
	
	public static float GetDifficulty () {
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}
	
	
}


//  <>