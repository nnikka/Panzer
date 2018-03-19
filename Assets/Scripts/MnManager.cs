using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class MnManager : MonoBehaviour {

	public static Color firstColor;
	public static Color secondColor;
	public static string firstName;
	public static string secondName;
	public static int firstScore;
	public static int secondScore;
	public static int scoreToWin;

    public InputField inputOne;
	public InputField inputTwo;
	public Text[] color1;
	public Text[] color2;
	public Text player1Header;
	public Text player2Header;
	public InputField Score;
	public Text scoreText;


    public void Start() {
		scoreToWin = 10;
		scoreText.text = "" + scoreToWin;
        inputOne.text = "Player 1";
        firstName = inputOne.text;
		inputTwo.text = "Player 2";
		secondName = inputTwo.text;
		firstColor = color1[0].color;
		secondColor = color2[4].color;
		player1Header.color = firstColor;
		player2Header.color = secondColor;
		for (int i = 0; i < color1.Length; i++) {
			Color cl = color1[i].color;
			color1[i].GetComponent<Button>().onClick.AddListener(
			  delegate() {
					changeFirstColor(cl);
			  }
			);
		}
		for (int i = 0; i < color2.Length; i++) {
			Color cl = color1[i].color;
			color2[i].GetComponent<Button>().onClick.AddListener(
			  delegate() {
					changeSecondColor(cl);
			  }
			);
		}
    }

    public void Update() {
		handleNames();
		handleScore();
    }

    private void handleScore() {
		Score.text = Regex.Replace(Score.text, @"[^0-9 ]", "");
		if (Score.text.Length > 0) {
			int cursc = int.Parse(Score.text);
			if (cursc > 30) {
				cursc = 30;
			}
			if (cursc <= 0) {
				cursc = 1;
			}
			scoreToWin = cursc;
			scoreText.text = "" + scoreToWin;
		}
    }

    private void handleNames() {
		if (validateName(inputOne.text)) {
			firstName = inputOne.text;
			player1Header.text = firstName;
       } else {
			firstName = "Player 1";
			player1Header.text = firstName;
       }
		if (validateName(inputTwo.text)) {
			secondName = inputTwo.text;
			player2Header.text = secondName;
       } else {
			secondName = "Player 2";
			player2Header.text = secondName;
       }
    }

	private void changeFirstColor (Color clr) {
		firstColor = clr;
		player1Header.color = firstColor;
	}

	private void changeSecondColor (Color clr) {
		secondColor = clr;
		player2Header.color = secondColor;
	}

	private bool validateName(string text) {
		 int counter = 0;
	     for (int i = 0; i < text.Length; i++) {
			if (i == 0 && text[i] == ' ') {
			    return false;
	        } 
	        if (text[i] != ' ') {
	           counter++;
	        }
	     }
		 if (counter >= 3) {
		   return true;
	     } else {
	       return false;
	     }
	}

	public void LoadLevel(string name) {
        SceneManager.LoadScene(name);
   }

   public void QuitRequest() {
       Application.Quit();
   }
}
