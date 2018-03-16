using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Nanmonme : MonoBehaviour {
	public GameObject gameController;	//GameController取得
	public Text nanmonmeText;			//Textコンポーネント取得用
	
	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//テキスト表示
		nanmonmeText.text = "Question " + gc.syutudaiNumNow;
//		nanmonmeText.text = "第 " + gc.syutudaiNumNow + " 問";
	}
}
