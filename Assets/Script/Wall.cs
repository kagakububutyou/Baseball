using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

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
			//	動きを止めて
			collision.rigidbody.velocity = Vector3.zero;
			//	回転を止める
			collision.rigidbody.angularVelocity = Vector3.zero;


			//	削除する
			//Destroy(collision.gameObject);
		}
	}
}