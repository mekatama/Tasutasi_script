using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Result : MonoBehaviour {
	public GameObject gameController;	//GameController取得
	public Text resultText;				//Textコンポーネント取得用

	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//結果テキスト表示
		resultText.text = gc.syutudaiNum + "問中　" + gc.seikaiNum + "問正解";
	}
}
