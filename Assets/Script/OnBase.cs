using UnityEngine;
using System.Collections;

public class OnBase : MonoBehaviour {

	public GameObject Object;
	
	// スクリプトが有効になったとき一回だけ呼ばれます
	void Start () 
	{
		
	}
	
	// 毎フレーム呼ばれます
	void Update () 
	{
		
	}

	public void ReturnBase()
	{
		return;
	}

	// ベースにランナーを生成します
	public void GoBase()
	{
		Instantiate(Object.gameObject,transform.position,transform.rotation);
	}
}
