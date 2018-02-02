using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawn : MonoBehaviour {
	public GameObject effectPrefab;		//effect取得
	public GameObject gameController;	//GameController取得
	private bool oneEffect;				//一回だけ処理

	void Start () {
		oneEffect = false;				//初期化
	}
	
	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		if(gc.isKamifubuki){
			//一回だけ処理を入れる
			if(oneEffect == false){
				EffectGo();
				oneEffect = true;
			}
		}
	}

	public void EffectGo(){
		//effectを生成する
		Instantiate(
			effectPrefab,		//生成するeffect
			transform.position,	//生成時の位置
			transform.rotation	//生成時の角度
		);
		Debug.Log("EffectGo!!");
	}
}
