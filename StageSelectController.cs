using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectController : MonoBehaviour {

	void Start () {
		//ハイスコアの初期値チェック
		//何もデータが無かったら初期値を代入
		if(PlayerPrefs.GetFloat("HighScore1") == 0f){	PlayerPrefs.SetFloat("HighScore1", 120.0f);	}
		if(PlayerPrefs.GetFloat("HighScore2") == 0f){	PlayerPrefs.SetFloat("HighScore2", 120.0f);	}
		if(PlayerPrefs.GetFloat("HighScore3") == 0f){	PlayerPrefs.SetFloat("HighScore3", 120.0f);	}
		if(PlayerPrefs.GetFloat("HighScore4") == 0f){	PlayerPrefs.SetFloat("HighScore4", 120.0f);	}
		if(PlayerPrefs.GetFloat("HighScore5") == 0f){	PlayerPrefs.SetFloat("HighScore5", 120.0f);	}
		if(PlayerPrefs.GetFloat("HighScore6") == 0f){	PlayerPrefs.SetFloat("HighScore6", 120.0f);	}
		if(PlayerPrefs.GetFloat("HighScore7") == 0f){	PlayerPrefs.SetFloat("HighScore7", 120.0f);	}
		if(PlayerPrefs.GetFloat("HighScore8") == 0f){	PlayerPrefs.SetFloat("HighScore8", 120.0f);	}
		if(PlayerPrefs.GetFloat("HighScore9") == 0f){	PlayerPrefs.SetFloat("HighScore9", 120.0f);	}
		if(PlayerPrefs.GetFloat("HighScore10") == 0f){	PlayerPrefs.SetFloat("HighScore10", 120.0f);}
		if(PlayerPrefs.GetFloat("HighScore11") == 0f){	PlayerPrefs.SetFloat("HighScore11", 120.0f);}
		if(PlayerPrefs.GetFloat("HighScore12") == 0f){	PlayerPrefs.SetFloat("HighScore12", 120.0f);}
//		Debug.Log("HighScore1:" + PlayerPrefs.GetFloat("HighScore1"));
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
//		SceneManager.LoadScene("Main7");	//シーンのロード
		SceneManager.LoadScene("Main7yoko");	//シーンのロード
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
