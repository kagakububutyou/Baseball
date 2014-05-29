using UnityEngine;
using System.Collections;

//	出塁関係のスクリプト
public class On_base : MonoBehaviour {

	public int OnBaseCount = 0;		//	出塁カウンター

	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start () 
	{
	
	}
	
	// 毎フレーム呼ばれます
	void Update () 
	{

	}

	//	出塁したら呼ばれる関数
	public void OnBase()
	{
		Debug.Log("出塁");

		OnBaseCount++;

		if(OnBaseCount <= 3)
		{
			GameObject.Find(OnBaseCount.ToString()).SendMessage("Gobase");
		}
	}
}
