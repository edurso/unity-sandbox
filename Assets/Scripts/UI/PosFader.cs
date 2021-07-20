using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

/**
 * Use to fade between positions in scene
 * Call `StartCoroutine(GameObject.FindObjectOfType<PosFader>().FadeAndMove(Vector3 newPos, Vector3 newRot));`
 */
public class PosFader : MonoBehaviour
{

	#region FIELDS
	public Image fadeOutUIImage;
	public float fadeSpeed = 0.8f; // can play around with this a bit

	public enum FadeDirection
	{
		In, // 1
		Out // 0
	}
	#endregion

	#region MONOBEHAVIOR
	void OnEnable()
	{
		StartCoroutine(Fade(FadeDirection.Out));
	}
	#endregion

	#region FADE
	private IEnumerator Fade(FadeDirection fadeDirection)
	{
		float alpha = (fadeDirection == FadeDirection.Out) ? 1 : 0;
		float fadeEndValue = (fadeDirection == FadeDirection.Out) ? 0 : 1;
		if (fadeDirection == FadeDirection.Out)
		{
			while (alpha >= fadeEndValue)
			{
				SetColorImage(ref alpha, fadeDirection);
				yield return null;
			}
			fadeOutUIImage.enabled = false;
		}
		else
		{
			fadeOutUIImage.enabled = true;
			while (alpha <= fadeEndValue)
			{
				SetColorImage(ref alpha, fadeDirection);
				yield return null;
			}
		}
	}
	#endregion

	#region UTILITY
	public IEnumerator FadeAndMove(Vector3 newPos, Vector3 newRot)
	{
		Camera.main.transform.position = newPos; // set new camera position
		Camera.main.transform.rotation = Quaternion.Euler(newRot); // set new camera rotation
		yield return Fade(FadeDirection.In); // fade into new position
	}

	private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
	{
		fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
		alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == FadeDirection.Out) ? -1 : 1);
	}
	#endregion

}
