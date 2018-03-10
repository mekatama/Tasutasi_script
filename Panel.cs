using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour {
	public int panelNum;				//panelの番号を入れる
	public GameObject gameController;	//GameController取得
	private int panelRot;				//ランダムで回転するかどうか決める

	void Start () {
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		panelRot = Random.Range(0, gc.panelRotateFlag);		//各panelが回転するかどうか判定
		Debug.Log("回転確率:" + panelRot);
	}

	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();

		//panel回転の設定
		if(gc.panelRotateSpeed > 0){	//speedが0以上だったら回転してもいい
			if(panelRot == 1){			//実際に回転するかどうか判定
				//パネルの回転処理
				//各ステージ設定で、回転の有無、回転速度を設定できるようにする
				transform.Rotate(new Vector3(0, 0, gc.panelRotateSpeed));
			}
		}
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "DestroyArea"){
			//gcって仮の変数にGameControllerのコンポーネントを入れる
			GameController gc = gameController.GetComponent<GameController>();

			//パネルの数字を保存
			gc.panelNum[gc.panelDestroyNum] = panelNum;

			//削除したパネル数カウント
			gc.panelDestroyNum ++;
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
		}
	}
}
