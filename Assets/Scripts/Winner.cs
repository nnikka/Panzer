using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winner : MonoBehaviour {
	public static string winnerName;
	public static Color winnerColor;

    public Text winningText;

	// Use this for initialization
	void Start () {
		if (winnerName != null) {
			winningText.text = winnerName;
		}
		if (winnerColor != null) {
			winningText.color = winnerColor;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
