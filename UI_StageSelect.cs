using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StageSelect : MonoBehaviour {
	public Text highScore1;		//ハイスコアを表示するオブジェクト用

	void Update () {
		//ハイスコア系テキストの表示
		highScore1.text = PlayerPrefs.GetFloat("HighScore1").ToString("000.000") + "s";
	}
}
