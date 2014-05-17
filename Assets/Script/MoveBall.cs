using UnityEngine;
using System.Collections;

public class MoveBall : MonoBehaviour {

	public int speed = -20; // 弾のスピード
	
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
}