using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
	public int calcNum;				//計算させるpanelの個数
	public int panelNumLimit;		//出現数字の上限
	public int syutudaiNum;			//出題数
	public int syutudaiNumNow;		//現在の出題数
	public int[] panelNum;			//計算用配列
	public int panelNumTotal;		//合計
	public int panelDestroyNum;		//生成後に削除したpanel数
	public bool isAnser;			//解答したフラグ
	public bool isSeikai;			//正解フラグ
	public int[] seigo;				//解答の正誤保存flag配列 1=正解 2=不正解 0=初期値；
	public int seikaiNum;			//正解数
	public int imageUse;			//画像パネルの使用flag(0:数字のみ,1:ランダム,2:画像のみ)
	public int sliderMaxValue;		//スライダー入力の最大値
	public float panelSpeed;		//panelのスピード
	public int panelRotateSpeed;	//panelの回転speed。0だと回転しない
	public int panelRotateFlag;		//panelの回転するかどうかランダム数で判定する
	public bool isKamifubuki;		//紙吹雪エフェクトフラグ
	public float timePlaying;		//play時間
	public float timeClear;			//Clearした時間
	public float timeBest;			//ハイスコア時間
	public bool isTimeCount;		//timeのカウント開始flag

	public float startTime = 1.5f;		//UIのSTARTを表示する時間
	float time = 0f;					//UIのSTARTを表示する時間用の変数
	public float resultTime = 1.5f;		//UIの〇✖を表示する時間
	public float allResultTime = 3.0f;	//UIのリザルトを表示する時間
	float time_marubatu = 0f;			//UIの〇✖を表示する時間用の変数
	float time_finish = 0f;				//UIのFINISHを表示する時間用の変数

	public Canvas startCamvas;		//Canvas_Start
	public Canvas inputCamvas;		//Canvas_Input
	public Canvas maruCamvas;		//Canvas_Maru
	public Canvas batuCamvas;		//Canvas_Batu
	public Canvas finishCamvas;		//Canvas_Finish
	public Canvas playCamvas;		//Canvas_Play
	public Canvas timeCamvas;		//Canvas_Time
	public Canvas highScoreCamvas;	//Canvas_HighScore
	public PanelSpawn ps;			//PanelSpawn1

	AudioSource audioSource;		//AudioSourceコンポーネント取得用
	public AudioClip audioClipMaru;	//Maru SE
	public AudioClip audioClipBatu;	//Batu SE
	public AudioClip audioClipMiss;	//Miss SE
	public AudioClip audioClipOk;	//Ok SE
	private bool seGo;				//SE再生一回だけフラグ


	void Start () {
		startCamvas.enabled = true;		//StartUI表示
		inputCamvas.enabled = false;	//InputUI非表示
		maruCamvas.enabled = false;		//maruUI非表示
		batuCamvas.enabled = false;		//batuUI非表示
		finishCamvas.enabled = false;	//finishUI非表示
		playCamvas.enabled = false;		//playUI非表示
		highScoreCamvas.enabled = false;//highScoreUI非表示
		timeCamvas.enabled = true;		//TimeUI表示
		audioSource = gameObject.GetComponent<AudioSource>();		//AudioSourceコンポーネント取得
		seGo = false;												//SE再生用
		isKamifubuki = false;			//effectのフラグ初期化
		isTimeCount = false;


		//各ステージの固有値初期設定
		//数字のみ
//		if(SceneManager.GetActiveScene ().name == "Main1"){
		if(SceneManager.GetActiveScene ().name == "Main1yoko"){
			calcNum = 2;				//計算する個数
			syutudaiNum = 3;			//出題数の設定
			imageUse = 0;				//画像パネルの使用判定(0:数字のみ,1:ランダム,2:画像のみ)
			sliderMaxValue = 10;		//スライダー入力の最大値
			panelNumLimit = 3;			//出現数字の上限
			panelSpeed = -20.0f;		//panelのスピード
			panelRotateSpeed = 0;		//panelの回転設定
			panelRotateFlag = 4;		//panelの回転ランダムflag
		}
		if(SceneManager.GetActiveScene ().name == "Main2"){
			calcNum = 3;				//計算する個数
			syutudaiNum = 5;			//出題数の設定
			imageUse = 0;				//画像パネルの使用判定(0:数字のみ,1:ランダム,2:画像のみ)
			sliderMaxValue = 15;		//スライダー入力の最大値
			panelNumLimit = 4;			//出現数字の上限
			panelSpeed = -20.0f;		//panelのスピード
			panelRotateSpeed = 0;		//panelの回転設定
			panelRotateFlag = 4;		//panelの回転ランダムflag
		}
		if(SceneManager.GetActiveScene ().name == "Main3"){
			calcNum = 5;				//計算する個数
			syutudaiNum = 5;			//出題数の設定
			imageUse = 0;				//画像パネルの使用判定(0:数字のみ,1:ランダム,2:画像のみ)
			sliderMaxValue = 30;		//スライダー入力の最大値
			panelNumLimit = 5;			//出現数字の上限
			panelSpeed = -25.0f;		//panelのスピード
			panelRotateSpeed = 0;		//panelの回転設定
			panelRotateFlag = 4;		//panelの回転ランダムflag
		}
		if(SceneManager.GetActiveScene ().name == "Main4"){
			calcNum = 2;				//計算する個数
			syutudaiNum = 10;			//出題数の設定
			imageUse = 0;				//画像パネルの使用判定(0:数字のみ,1:ランダム,2:画像のみ)
			sliderMaxValue = 15;		//スライダー入力の最大値
			panelNumLimit = 7;			//出現数字の上限
			panelSpeed = -25.0f;		//panelのスピード
			panelRotateSpeed = 0;		//panelの回転設定
			panelRotateFlag = 4;		//panelの回転ランダムflag
		}
		if(SceneManager.GetActiveScene ().name == "Main5"){
			calcNum = 3;				//計算する個数
			syutudaiNum = 10;			//出題数の設定
			imageUse = 0;				//画像パネルの使用判定(0:数字のみ,1:ランダム,2:画像のみ)
			sliderMaxValue = 25;		//スライダー入力の最大値
			panelNumLimit = 8;			//出現数字の上限
			panelSpeed = -30.0f;		//panelのスピード
			panelRotateSpeed = 0;		//panelの回転設定
			panelRotateFlag = 4;		//panelの回転ランダムflag
		}
		if(SceneManager.GetActiveScene ().name == "Main6"){
			calcNum = 5;				//計算する個数
			syutudaiNum = 10;			//出題数の設定
			imageUse = 0;				//画像パネルの使用判定(0:数字のみ,1:ランダム,2:画像のみ)
			sliderMaxValue = 50;		//スライダー入力の最大値
			panelNumLimit = 10;			//出現数字の上限
			panelSpeed = -30.0f;		//panelのスピード
			panelRotateSpeed = 0;		//panelの回転設定
			panelRotateFlag = 4;		//panelの回転ランダムflag
		}
		//数字と画像
		if(SceneManager.GetActiveScene ().name == "Main7"){
			calcNum = 2;				//計算する個数
			syutudaiNum = 5;			//出題数の設定
			imageUse = 1;				//画像パネルの使用判定(0:数字のみ,1:ランダム,2:画像のみ)
			sliderMaxValue = 10;		//スライダー入力の最大値
			panelNumLimit = 3;			//出現数字の上限
			panelSpeed = -20.0f;		//panelのスピード
			panelRotateSpeed = 0;		//panelの回転設定
			panelRotateFlag = 4;		//panelの回転ランダムflag
		}
		if(SceneManager.GetActiveScene ().name == "Main8"){
			calcNum = 3;				//計算する個数
			syutudaiNum = 5;			//出題数の設定
			imageUse = 1;				//画像パネルの使用判定(0:数字のみ,1:ランダム,2:画像のみ)
			sliderMaxValue = 15;		//スライダー入力の最大値
			panelNumLimit = 4;			//出現数字の上限
			panelSpeed = -20.0f;		//panelのスピード
			panelRotateSpeed = 0;		//panelの回転設定
			panelRotateFlag = 4;		//panelの回転ランダムflag
		}
		if(SceneManager.GetActiveScene ().name == "Main9"){
			calcNum = 5;				//計算する個数
			syutudaiNum = 5;			//出題数の設定
			imageUse = 1;				//画像パネルの使用判定(0:数字のみ,1:ランダム,2:画像のみ)
			sliderMaxValue = 30;		//スライダー入力の最大値
			panelNumLimit = 5;			//出現数字の上限
			panelSpeed = -25.0f;		//panelのスピード
			panelRotateSpeed = 0;		//panelの回転設定
			panelRotateFlag = 4;		//panelの回転ランダムflag
		}
		if(SceneManager.GetActiveScene ().name == "Main10"){
			calcNum = 2;				//計算する個数
			syutudaiNum = 10;			//出題数の設定
			imageUse = 1;				//画像パネルの使用判定(0:数字のみ,1:ランダム,2:画像のみ)
			sliderMaxValue = 15;		//スライダー入力の最大値
			panelNumLimit = 7;			//出現数字の上限
			panelSpeed = -25.0f;		//panelのスピード
			panelRotateSpeed = 0;		//panelの回転設定
			panelRotateFlag = 4;		//panelの回転ランダムflag
		}
		if(SceneManager.GetActiveScene ().name == "Main11"){
			calcNum = 3;				//計算する個数
			syutudaiNum = 10;			//出題数の設定
			imageUse = 1;				//画像パネルの使用判定(0:数字のみ,1:ランダム,2:画像のみ)
			sliderMaxValue = 25;		//スライダー入力の最大値
			panelNumLimit = 8;			//出現数字の上限
			panelSpeed = -30.0f;		//panelのスピード
			panelRotateSpeed = 0;		//panelの回転設定
			panelRotateFlag = 4;		//panelの回転ランダムflag
		}
		if(SceneManager.GetActiveScene ().name == "Main12"){
			calcNum = 5;				//計算する個数
			syutudaiNum = 10;			//出題数の設定
			imageUse = 1;				//画像パネルの使用判定(0:数字のみ,1:ランダム,2:画像のみ)
			sliderMaxValue = 50;		//スライダー入力の最大値
			panelNumLimit = 10;			//出現数字の上限
			panelSpeed = -30.0f;		//panelのスピード
			panelRotateSpeed = 0;		//panelの回転設定
			panelRotateFlag = 4;		//panelの回転ランダムflag
		}
		Debug.Log("Stage:" + SceneManager.GetActiveScene ().name);

		//配列の初期化
		panelNum = new int[calcNum];
		seigo = new int[syutudaiNum];

		//panel数値の初期化
		for(int i = 0; i < panelNum.Length; i++){
			panelNum[i] = 0;				//配列に初期値0を入れておく
//			Debug.Log("配列番号[" + i + "]  = " + panelNum[i]);
		}

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
				playCamvas.enabled = true;			//playUI表示
				ps.panelSpawn = true;				//panel生成するフラグon
				isAnser = false;					//
				isTimeCount = true;					//timeカウント開始
				//panel出現数と削除数を比較
				if(calcNum == panelDestroyNum){
//					playCamvas.enabled = false;		//playUI非表示
					syutudaiNumNow += 1;			//現在の出題数をインクリメント
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
					playCamvas.enabled = false;		//playUI非表示
					Result();	//ステート変更
					Debug.Log("State.Result");
				}
				break;
			//〇✖表示
			case State.Result:
				isTimeCount = false;		//timeカウント停止
				//ここで〇✖の表示をする
				if(isSeikai){
					maruCamvas.enabled = true;			//maruUI表示
					if(seGo == false){
						audioSource.clip = audioClipMaru;	//SE決定
						audioSource.Play ();				//SE再生
						seGo = true;
					}
				}else{
					batuCamvas.enabled = true;			//batuUI表示
					if(seGo == false){
						audioSource.clip = audioClipBatu;	//SE決定
						audioSource.Play ();				//SE再生
						seGo = true;
					}
				}
				inputCamvas.enabled = false;		//InputUI非表示

				//指定時間で〇✖を非表示にする
				time_marubatu += Time.deltaTime;
				if(time_marubatu > resultTime){
					playCamvas.enabled = false;		//playUI非表示
					maruCamvas.enabled = false;		//maruUI非表示
					batuCamvas.enabled = false;		//batuUI非表示
					seGo = false;					//SE一回だけ処理終わり

					//ここで出題数に達しているか判定なのかな
					if(syutudaiNumNow == syutudaiNum){
//						isTimeCount = false;		//timeカウント停止
						timeClear = timePlaying;	//全問解答に要した時間
//						Debug.Log("CLEAR TIME:" + timeClear);
						//最後の結果画面のstateにここから移動する
						AllResult();	//ステート変更
					}else{
						//イロイロ初期化
						panelDestroyNum = 0;			//panel削除数を初期化
						ps.panelTotalNum = 0;			//panelの総数を初期化
						time_marubatu = 0;				//〇✖表示時間を初期化
						for(int i = 0; i < panelNum.Length; i++){
							panelNum[i] = 0;			//配列に初期値0を入れておく
						}

						Play();	//ステート変更
					}
				}
				break;
			//全問解答
			case State.AllResult:
				timeCamvas.enabled = false;				//TimeUI非表示
				finishCamvas.enabled = true;			//finishUI表示
				time_finish += Time.deltaTime;
				
				//正解数でSEを鳴らしわける
				if(seikaiNum == syutudaiNum){
					if(seGo == false){
						Debug.Log("正解数" + seikaiNum);
						Debug.Log("出題数" + syutudaiNum);
		//				Debug.Log("HighScore:" + timeBest);
						Debug.Log("ClearScore:" + timeClear);

						//ハイスコア判定
						if(PlayerPrefs.GetFloat("HighScore1") > timeClear){
							highScoreCamvas.enabled = true;	//highScoreUI表示
							timeBest = timeClear;			//ハイスコア更新
							Debug.Log("HighScore更新:" + timeBest);

							//【予定】各ステージ毎にセーブする
							PlayerPrefs.SetFloat("HighScore1", timeBest);

						}else{
							Debug.Log("HighScore更新NG:");
						}
						isKamifubuki = true;			//紙吹雪エフェクトon
						audioSource.clip = audioClipOk;	//SE決定
						audioSource.Play ();			//SE再生
						seGo = true;
					}
				}else if(seikaiNum != 0){
					if(seGo == false){
						isKamifubuki = true;			//紙吹雪エフェクトon
						audioSource.clip = audioClipOk;	//SE決定
						audioSource.Play ();			//SE再生
						seGo = true;
					}
				}else{
					if(seGo == false){
						audioSource.clip = audioClipMiss;	//SE決定
						audioSource.Play ();				//SE再生
						seGo = true;
					}
				}

				if(time_finish > allResultTime){
					finishCamvas.enabled = false;		//finishUI非表示
					seGo = false;
					SceneManager.LoadScene("Select_yoko");	//シーンのロード
				}
				break;
		}
	}

	void Update () {
		//play時間チェック
		if(isTimeCount == true){
			timePlaying += Time.deltaTime;	//play時間の保存
		}
	}

	void Ready(){
		state = State.Ready;
	}

	void Play(){
		state = State.Play;
	}

	void Anser(){
		state = State.Anser;
		panelNumTotal = 0;		//初期化
		//合計を計算
		for(int i = 0; i < panelNum.Length; i++){
			panelNumTotal = panelNumTotal + panelNum[i];		//
//			Debug.Log("配列番号[" + i + "]  = " + panelNum[i]);
		}
		Debug.Log("Goukei = " + panelNumTotal);

		//ここで掛け算も可能
	}

	void Result(){
		state = State.Result;
	}

	void AllResult(){
		Debug.Log("全部出題したはずー！");
		state = State.AllResult;
	}

	//セレクト画面に戻るボタン用の制御関数
	public void OnReturnSelectButtonClicked(){
		//イロイロ初期化
		panelDestroyNum = 0;			//panel削除数を初期化
		ps.panelTotalNum = 0;			//panelの総数を初期化
		time_marubatu = 0;				//〇✖表示時間を初期化
		for(int i = 0; i < panelNum.Length; i++){
			panelNum[i] = 0;			//配列に初期値0を入れておく
		}
		SceneManager.LoadScene("Select_yoko");	//シーンのロード
//		SceneManager.LoadScene("Select");	//シーンのロード
	}
}
