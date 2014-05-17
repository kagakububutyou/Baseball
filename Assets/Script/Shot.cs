using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
	
	public GameObject Tama; // 弾のオブジェクト

	public  int count = 10; // 発射間隔

	private int frame; // フレーム

	//	弾の座標
	private const float Tama_x = 125.0436f;
	private const float Tama_y = 0.5f;
	private const float Tama_z = 146.1412f;

	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start () 
	{
		frame = 0;
	}
	// 毎フレーム呼ばれます
	void Update () 
	{
		frame ++; // フレームをカウント
		
		//	Aボタンをおした時かつcountfフレームごと
		//if(Input.GetButtonDown("ButtanA") && frame % count == 0)
		if(Input.GetButtonDown("ButtanA"))
		{
			// 発射位置に弾を生成します 
			Instantiate(Tama,new Vector3(Tama_x,Tama_y,Tama_z),Quaternion.identity); 
		}
	}
}
