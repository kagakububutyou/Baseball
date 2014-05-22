using UnityEngine;
using System.Collections;

public class HR : MonoBehaviour {

	public float HRCount = 0;

	public GameObject Tama; // 弾のオブジェクト

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

	}
}
