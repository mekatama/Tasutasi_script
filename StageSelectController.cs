using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectController : MonoBehaviour {
//	GameObject gameController;			//検索したオブジェクト入れる用

	void Start () {
		//ハイスコアの初期値チェック
		if(PlayerPrefs.GetFloat("HighScore1") == 0f){	//何もデータが無かったら
			PlayerPrefs.SetFloat("HighScore1", 120.0f);	//初期値を代入
		}
		Debug.Log("HighScore1:" + PlayerPrefs.GetFloat("HighScore1"));
/*
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す

		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		Debug.Log("Hiscore:" + gc.timeBest);
*/
	}

	//ステージ用の制御関数
	public void OnStage01ButtonClicked(){
//		SceneManager.LoadScene("Main1");	//シーンのロード
		SceneManager.LoadScene("Main1yoko");	//シーンのロード
	}
	public void OnStage02ButtonClicked(){
		SceneManager.LoadScene("Main2");	//シーンのロード
	}
	public void OnStage03ButtonClicked(){
		SceneManager.LoadScene("Main3");	//シーンのロード
	}
	public void OnStage04ButtonClicked(){
		SceneManager.LoadScene("Main4");	//シーンのロード
	}
	public void OnStage05ButtonClicked(){
		SceneManager.LoadScene("Main5");	//シーンのロード
	}
	public void OnStage06ButtonClicked(){
		SceneManager.LoadScene("Main6");	//シーンのロード
	}
	public void OnStage07ButtonClicked(){
		SceneManager.LoadScene("Main7");	//シーンのロード
	}
	public void OnStage08ButtonClicked(){
		SceneManager.LoadScene("Main8");	//シーンのロード
	}
	public void OnStage09ButtonClicked(){
		SceneManager.LoadScene("Main9");	//シーンのロード
	}
	public void OnStage10ButtonClicked(){
		SceneManager.LoadScene("Main10");	//シーンのロード
	}
	public void OnStage11ButtonClicked(){
		SceneManager.LoadScene("Main11");	//シーンのロード
	}
	public void OnStage12ButtonClicked(){
		SceneManager.LoadScene("Main12");	//シーンのロード
	}

	//タイトルに戻るボタン用の制御関数
	public void OnReturnTitleButtonClicked(){
		SceneManager.LoadScene("Title");	//シーンのロード
	}
}
