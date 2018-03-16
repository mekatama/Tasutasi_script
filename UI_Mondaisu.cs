using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Mondaisu : MonoBehaviour {
	public GameObject gameController;	//GameController取得
	public Text resultText;				//Textコンポーネント取得用
	
	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//結果テキスト表示
		resultText.text = "All " + gc.syutudaiNum + " Question";
//		resultText.text = "全 " + gc.syutudaiNum + " 問";
	}
}
