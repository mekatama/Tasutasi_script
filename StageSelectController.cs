using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectController : MonoBehaviour {
	public Canvas stageButton2;		//Canvas_s2
	public Canvas stageButton3;		//Canvas_s3
	public Canvas stageButton4;		//Canvas_s4
	public Canvas stageButton5;		//Canvas_s5
	public Canvas stageButton6;		//Canvas_s6
	public Canvas stageButton7;		//Canvas_s7
	public Canvas stageButton8;		//Canvas_s8
	public Canvas stageButton9;		//Canvas_s9
	public Canvas stageButton10;	//Canvas_s10
	public Canvas stageButton11;	//Canvas_s11
	public Canvas stageButton12;	//Canvas_s12

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

		stageButton2.enabled = false;		//UI表示
		stageButton3.enabled = false;		//UI表示
		stageButton4.enabled = false;		//UI表示
		stageButton5.enabled = false;		//UI表示
		stageButton6.enabled = false;		//UI表示
		stageButton7.enabled = false;		//UI表示
		stageButton8.enabled = false;		//UI表示
		stageButton9.enabled = false;		//UI表示
		stageButton10.enabled = false;		//UI表示
		stageButton11.enabled = false;		//UI表示
		stageButton12.enabled = false;		//UI表示
		//■残りのボタンを非表示

		//ボタン表示制御の初期値
		if(PlayerPrefs.GetInt("StageOpen") == 0){	PlayerPrefs.SetInt("StageOpen", 1);}

		//■２以上の時の処理を入れ,UIを表示
		if(PlayerPrefs.GetInt("StageOpen") >= 2){	stageButton2.enabled = true;	}	//UI表示
		if(PlayerPrefs.GetInt("StageOpen") >= 3){	stageButton3.enabled = true;	}	//UI表示
		if(PlayerPrefs.GetInt("StageOpen") >= 4){	stageButton4.enabled = true;	}	//UI表示
		if(PlayerPrefs.GetInt("StageOpen") >= 5){	stageButton5.enabled = true;	}	//UI表示
		if(PlayerPrefs.GetInt("StageOpen") >= 6){	stageButton6.enabled = true;	}	//UI表示
		if(PlayerPrefs.GetInt("StageOpen") >= 7){	stageButton7.enabled = true;	}	//UI表示
		if(PlayerPrefs.GetInt("StageOpen") >= 8){	stageButton8.enabled = true;	}	//UI表示
		if(PlayerPrefs.GetInt("StageOpen") >= 9){	stageButton9.enabled = true;	}	//UI表示
		if(PlayerPrefs.GetInt("StageOpen") >= 10){	stageButton10.enabled = true;	}	//UI表示
		if(PlayerPrefs.GetInt("StageOpen") >= 11){	stageButton11.enabled = true;	}	//UI表示
		if(PlayerPrefs.GetInt("StageOpen") >= 12){	stageButton12.enabled = true;	}	//UI表示

		//StageOpenの保存処理を考える
		
	}

	void Update () {

	}

	//ステージ用の制御関数
	public void OnStage01ButtonClicked(){
//		SceneManager.LoadScene("Main1");	//シーンのロード
		SceneManager.LoadScene("Main1yoko");	//シーンのロード
	}
	public void OnStage02ButtonClicked(){
//		SceneManager.LoadScene("Main2");	//シーンのロード
		SceneManager.LoadScene("Main2yoko");	//シーンのロード
	}
	public void OnStage03ButtonClicked(){
//		SceneManager.LoadScene("Main3");	//シーンのロード
		SceneManager.LoadScene("Main3yoko");	//シーンのロード
	}
	public void OnStage04ButtonClicked(){
//		SceneManager.LoadScene("Main4");	//シーンのロード
		SceneManager.LoadScene("Main4yoko");	//シーンのロード
	}
	public void OnStage05ButtonClicked(){
//		SceneManager.LoadScene("Main5");	//シーンのロード
		SceneManager.LoadScene("Main5yoko");	//シーンのロード
	}
	public void OnStage06ButtonClicked(){
//		SceneManager.LoadScene("Main6");	//シーンのロード
		SceneManager.LoadScene("Main6yoko");	//シーンのロード
	}
	public void OnStage07ButtonClicked(){
//		SceneManager.LoadScene("Main7");	//シーンのロード
		SceneManager.LoadScene("Main7yoko");	//シーンのロード
	}
	public void OnStage08ButtonClicked(){
//		SceneManager.LoadScene("Main8");	//シーンのロード
		SceneManager.LoadScene("Main8yoko");	//シーンのロード
	}
	public void OnStage09ButtonClicked(){
//		SceneManager.LoadScene("Main9");	//シーンのロード
		SceneManager.LoadScene("Main9yoko");	//シーンのロード
	}
	public void OnStage10ButtonClicked(){
//		SceneManager.LoadScene("Main10");	//シーンのロード
		SceneManager.LoadScene("Main10yoko");	//シーンのロード
	}
	public void OnStage11ButtonClicked(){
//		SceneManager.LoadScene("Main11");	//シーンのロード
		SceneManager.LoadScene("Main11yoko");	//シーンのロード
	}
	public void OnStage12ButtonClicked(){
//		SceneManager.LoadScene("Main12");	//シーンのロード
		SceneManager.LoadScene("Main12yoko");	//シーンのロード
	}

	//タイトルに戻るボタン用の制御関数
	public void OnReturnTitleButtonClicked(){
		SceneManager.LoadScene("Title");	//シーンのロード
	}
}
