using UnityEngine;
using System.Collections;

public class MoveBall : MonoBehaviour {

	private const int speed = -30; // 弾のスピード
	
	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start () 
	{
		// ホームベース向きに速度を渡してあげます
		rigidbody.velocity = new Vector3(speed, 0, speed);
	}

	// 毎フレーム呼ばれます
	void Update () 
	{

	}

	//	壁にあたったら
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "Wall")
		{
			//	動きを止めて
			rigidbody.velocity = Vector3.zero;
			//	回転を止める
			rigidbody.angularVelocity = Vector3.zero;
		}
	}
}