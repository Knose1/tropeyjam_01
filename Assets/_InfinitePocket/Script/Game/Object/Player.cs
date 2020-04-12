///-----------------------------------------------------------------
/// Author : #DEVELOPER_NAME#
/// Date : #DATE#
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.Github.Knose1.InfinitePocket.Game.Object
{
	[AddComponentMenu("_InfinitePocket/Game/Object/" + nameof(Player))]
	public class Player : MonoBehaviour {

		[SerializeField] private float speed = 1;
		[SerializeField] private float headSpeed = 1;
		[SerializeField] private Transform head = null;

		[SerializeField] private string Horizontal = "Horizontal";
		[SerializeField] private string Vertical = "Vertical";
		[SerializeField] private string MouseX = "MouseX";
		[SerializeField] private string MouseY = "MouseY";

		[SerializeField] private Rigidbody rb = null;

		[SerializeField] private float xRotation = 0;
		[SerializeField] private float yRotation = 0;
		[SerializeField] private float yClampMin = -360;
		[SerializeField] private float yClampMax = 360;

		private void Start () {}
		
		private void Update ()
		{
			Vector3 lMove = transform.forward * Input.GetAxis(Vertical) + transform.right * Input.GetAxis(Horizontal);
			rb.position += lMove * speed * Time.deltaTime;
			
			Rotate();
		}

		private void Rotate()
		{
			xRotation += Input.GetAxis(MouseX) * headSpeed;
			yRotation += -Input.GetAxis(MouseY) * headSpeed;

			xRotation = xRotation % 360;
			yRotation = yRotation % 360;

			float ySign = Mathf.Sign(yRotation);
			yRotation = Mathf.Clamp(yRotation, yClampMin, yClampMax);

			transform.rotation = Quaternion.AngleAxis(xRotation, Vector3.up);
			head.localRotation = Quaternion.AngleAxis(yRotation, Vector3.right);
		}

		private void OnValidate()
		{
			Rotate();
		}
	}
}