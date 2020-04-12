using Com.Github.Knose1.InfinitePocket.Game;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Github.Knose1.InfinitePocket.UI {

	[AddComponentMenu("_InfinitePocket/UI/" + nameof(UIManager))]
	public class UIManager : MonoBehaviour {

		[SerializeField] private KeyCode OpenInventory = KeyCode.I;
		[SerializeField] private InventoryScreen inventoryScreen = null;
		[SerializeField] private Image blackBackground = null;

		[SerializeField] private AnimationCurve alphaOverTime = null;
		[SerializeField] private float transitionDuration = 1;

		private float transitionStartTimeStamp;

		private Action doAction;

		private void Start()
		{
			GameManager.Instance.OnLevelSet += GameManager_OnLevelSet;
			SetModeTransition();
		}

		private void GameManager_OnLevelSet()
		{
			SetModeTransition();
		}

		private void OnDestroy()
		{
			GameManager.Instance.OnLevelSet -= GameManager_OnLevelSet;
		}

		private void DoActionNormal()
		{
			if (Input.GetKeyDown(OpenInventory))
			{
				inventoryScreen.gameObject.SetActive(!inventoryScreen.gameObject.activeSelf);
			}
		}
		private void DoActionTransition()
		{
			float ratio = (Time.time - transitionStartTimeStamp) / transitionDuration;
			if (ratio >= 1)
			{
				SetModeNormal();
				return;
			}

			Color color = blackBackground.color;
			color.a = alphaOverTime.Evaluate(ratio);
			blackBackground.color = color;
		}

		private void Update()
		{
			doAction();
		}

		private void SetModeNormal() => doAction = DoActionNormal;
		private void SetModeTransition()
		{

			inventoryScreen.gameObject.SetActive(false);
			transitionStartTimeStamp = Time.time;


			doAction = DoActionTransition;
		}

	}
}