using UnityEngine;
using System.Collections;

public class OUT : MonoBehaviour {

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

	//	弾がとっ待った時にファールゾーンにあったら
	private void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.name == "Ball(Clone)" && IsHitBatt == true)
		{
			Debug.Log("アウト");
			
			IsHitBatt = false;
			
			//	ファールカウント関数を呼ぶ
			GameObject.Find("GameManager").SendMessage("GetOUT");
		}
	}
}
