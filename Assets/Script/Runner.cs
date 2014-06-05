using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

	public GameObject[] Base;

	public int Num = 0;

	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start ()
	{

	}
	
	// 毎フレーム呼ばれます
	void Update ()
	{
		
	}


	public void ThisDestroy()
	{
		Destroy(this);
	}


	public void OnBase()
	{
		if((GM.BaseOnBalls[Num] - 1) >= 0)
		{
			transform.position = (Base[GM.BaseOnBalls[Num] - 1].transform.position);
		}

		Debug.Log("＼(＾o＾)／");
	}
}
