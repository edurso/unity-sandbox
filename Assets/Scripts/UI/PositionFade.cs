using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Fades to a new position within a 3D scene (uses main camera).
 * Usage: `StartCoroutine(GameObject.GetComponent<PositionFade>().FadeAndMove(newPos, newRot));`
 */
public class PositionFade : MonoBehaviour
{

	public GameObject fadeImage;

	/**
	 * Fades screen and moves main camera to a new position.
	 * The lower the fade speed, the longer the fade will take.
	 */ 
	public IEnumerator FadeAndMove(Vector3 newPos, Vector3 newRot, int fadeSpeed = 1)
	{

		Color objColor = fadeImage.GetComponent<Image>().color;
		float newAlpha;
		
		// Fade Out
		while (fadeImage.GetComponent<Image>().color.a < 1)
		{
			newAlpha = objColor.a + (fadeSpeed * Time.deltaTime);
			objColor = new Color(objColor.r, objColor.g, objColor.b, newAlpha);
			fadeImage.GetComponent<Image>().color = objColor;
			yield return null;
		}

		// Change Camera Position
		Camera.main.transform.position = newPos; // set new camera position
		Camera.main.transform.rotation = Quaternion.Euler(newRot); // set new camera rotation

		// Fade Screen Back In
		while (fadeImage.GetComponent<Image>().color.a > 0)
		{
			newAlpha = objColor.a - (fadeSpeed * Time.deltaTime);
			objColor = new Color(objColor.r, objColor.g, objColor.b, newAlpha);
			fadeImage.GetComponent<Image>().color = objColor;
			yield return null;
		}

	}
	
}
