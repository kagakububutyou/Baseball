using UnityEngine;
using System.Collections;

//	ボールかどうか判定するスクリプト
public class BALL : MonoBehaviour {

	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start ()
	{
		
	}
	
	// 毎フレーム呼ばれます
	void Update ()
	{
	
	}
	
	// 衝突した弾を
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "Ball(Clone)")
		{
			//	ボールを数えす関数を呼ぶ
			GameObject.Find("GameManager").SendMessage("GetBallCount");

			//	削除する
			Destroy(collision.gameObject);
		}
	}
}
