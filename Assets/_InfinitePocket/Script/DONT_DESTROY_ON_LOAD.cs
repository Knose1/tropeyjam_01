///-----------------------------------------------------------------
/// Author : #DEVELOPER_NAME#
/// Date : #DATE#
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket {
	public class DONT_DESTROY_ON_LOAD : MonoBehaviour {
	
		private void Start () {
			DontDestroyOnLoad(gameObject);	
		}
	}
}