using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOut : MonoBehaviour {

	public float fadeOutTime;
	
	private Image fadePanel;
	private Color currentColor = Color.black;
	
	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image>();
		currentColor.a = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeOutTime) {
			float alphaChange = Time.deltaTime /fadeOutTime;
			currentColor.a += alphaChange;
			fadePanel.color = currentColor;
		}else {
			gameObject.SetActive (false);
		}
	}
}
