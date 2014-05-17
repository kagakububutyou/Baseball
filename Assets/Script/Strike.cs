using UnityEngine;
using System.Collections;

public class Strike : MonoBehaviour {

	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start () 
	{
	
	}
	
	// 毎フレーム呼ばれます
	void Update () 
	{
	
	}

	// 衝突した相手オブジェクトを削除する
	private void OnCollisionEnter(Collision collision)
	{
		Destroy(collision.gameObject);
	}
}
