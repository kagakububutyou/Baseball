using UnityEngine;
using System.Collections;

public class GoBase : MonoBehaviour {

	public GameObject Runner;	//	弾があるかどうか
	
	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start () 
	{
		
	}
	
	// 毎フレーム呼ばれます
	void Update () 
	{
		
	}
	
	public void Gobase()
	{
		//	ベースにランナーを生成
		Instantiate(Runner,transform.position,transform.rotation);
	}
}
