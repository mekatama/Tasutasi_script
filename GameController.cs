using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	//ゲームステート
	enum State{
		Ready,
		Play,
		Anser,
		Result,
		AllResult
	}

	State state;
	public int calcNum;				//計算させる数の個数
	public int syutudaiNum;			//出題数
	public int syutudaiNumNow;		//現在の出題数
	public int[] panelNum;			//計算用配列
	public int panelNumTotal;		//合計
	public int panelDestroyNum;		//生成後に削除したpanel数
	public bool isAnser;			//解答したフラグ
	public bool isSeikai;			//正解フラグ
	public int[] seigo;				//解答の正誤保存flag配列 1=正解 2=不正解 0=初期値；
	public int seikaiNum;			//正解数

	public float startTime = 1.5f;	//UIのSTARTを表示する時間
	float time = 0f;				//UIのSTARTを表示する時間用の変数
	public float resultTime = 1.5f;	//UIの〇✖を表示する時間
	float time_marubatu = 0f;		//UIの〇✖を表示する時間用の変数
	float time_finish = 0f;			//UIのFINISHを表示する時間用の変数

	public Canvas startCamvas;		//Canvas_Start
	public Canvas inputCamvas;		//Canvas_Input
	public Canvas maruCamvas;		//Canvas_Maru
	public Canvas batuCamvas;		//Canvas_Batu
	public Canvas finishCamvas;		//Canvas_Finish
	public PanelSpawn ps;			//PanelSpawn1

	void Start () {
		inputCamvas.enabled = false;	//InputUI非表示
		maruCamvas.enabled = false;		//maruUI非表示
		batuCamvas.enabled = false;		//batuUI非表示
		finishCamvas.enabled = false;	//finishUI非表示

		//各ステージの固有値初期設定
		//2個の足し算、問題数は5
		if(SceneManager.GetActiveScene ().name == "Main1"){
			calcNum = 2;				//計算する個数
			syutudaiNum = 5;			//出題数の設定
		}

		seigo = new int[syutudaiNum];	//配列の初期化

		//正誤flagの初期化
		for(int i = 0; i < seigo.Length; i++){
			seigo[i] = 0;				//配列に初期値0を入れておく
//			Debug.Log("配列番号[" + i + "]  = " + seigo[i]);
		}

		Ready();						//ステート変更
		time = 0;						//UIのSTARTを表示する時間用の変数の初期化
	}
	
	void LateUpdate () {
		//ステートの制御
		switch(state){
			//START表示
			case State.Ready:
				time += Time.deltaTime;
				if(time > startTime){
					startCamvas.enabled = false;	//StartUI非表示
					Play();							//ステート変更
					Debug.Log("State.Play");
					time_finish = 0f;				//初期化
				}
//				Debug.Log("State.Ready");
				break;
			//ゲーム中
			case State.Play:
				ps.panelSpawn = true;				//panel生成するフラグon
				isAnser = false;
				//panel出現数と削除数を比較
				if(calcNum == panelDestroyNum){
					//現在の出題数をインクリメント
					syutudaiNumNow += 1;
					Debug.Log(syutudaiNumNow);
					Anser();						//ステート変更
//					Debug.Log("State.Anser");
				}
				break;
			//回答中
			case State.Anser:
				inputCamvas.enabled = true;			//InputUI表示
				//解答したら、以下を呼び出せば良さそう
				if(isAnser == true){
					Result();	//ステート変更
					Debug.Log("State.Result");
				}
				break;
			//〇✖表示
			case State.Result:
				//ここで〇✖の表示をする
				if(isSeikai){
					maruCamvas.enabled = true;		//maruUI表示
				}else{
					batuCamvas.enabled = true;		//batuUI表示
				}
				inputCamvas.enabled = false;		//InputUI非表示

				//指定時間で〇✖を非表示にする
				time_marubatu += Time.deltaTime;
				if(time_marubatu > resultTime){
					maruCamvas.enabled = false;		//maruUI非表示
					batuCamvas.enabled = false;		//batuUI非表示

					//イロイロ初期化
//					panelDestroyNum = 0;			//panel削除数を初期化
//					ps.panelTotalNum = 0;			//panelの総数を初期化
//					panelNum[0] = 0;				//panelの数字を初期化
//					panelNum[1] = 0;				//panelの数字を初期化
//					time_marubatu = 0;				//〇✖表示時間を初期化

					//ここで出題数に達しているか判定なのかな
					if(syutudaiNumNow == syutudaiNum){
						//最後の結果画面のstateにここから移動する
						AllResult();	//ステート変更
					}else{
						//イロイロ初期化
						panelDestroyNum = 0;			//panel削除数を初期化
						ps.panelTotalNum = 0;			//panelの総数を初期化
						panelNum[0] = 0;				//panelの数字を初期化
						panelNum[1] = 0;				//panelの数字を初期化
						time_marubatu = 0;				//〇✖表示時間を初期化

						Play();	//ステート変更
					}
				}
				break;
			//全問解答
			case State.AllResult:
				finishCamvas.enabled = true;			//finishUI表示
				time_finish += Time.deltaTime;
				if(time_finish > resultTime){
					finishCamvas.enabled = false;		//finishUI非表示
					SceneManager.LoadScene("Select");	//シーンのロード
				}
				break;
		}
	}

	void Update () {
		//未使用
	}

	void Ready(){
		state = State.Ready;
	}

	void Play(){
		state = State.Play;
	}

	void Anser(){
		state = State.Anser;
		//合計を計算
		panelNumTotal = panelNum[0] + panelNum[1];
		Debug.Log("Goukei = " + panelNumTotal);
	}

	void Result(){
		state = State.Result;
	}

	void AllResult(){
		Debug.Log("全部出題したはずー！");
		state = State.AllResult;
	}
}
