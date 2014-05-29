using UnityEngine;
using System.Collections;

//	ボールかどうか判定するスクリプト
public class BALL : MonoBehaviour {

	private bool IsHitBatt = false;

	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start ()
	{
		IsHitBatt = false;
	}
	
	// 毎フレーム呼ばれます
	void Update ()
	{
	
	}

	//	バットにあったったら呼ばれます
	public void HitBatt()
	{
		IsHitBatt = true;
	}

	// 衝突した弾を
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "Ball(Clone)" && IsHitBatt == false)
		{
			//	ボールを数えす関数を呼ぶ
			GameObject.Find("GameManager").SendMessage("GetBallCount");

			//	削除する
			Destroy(collision.gameObject);
		}
	}
}
