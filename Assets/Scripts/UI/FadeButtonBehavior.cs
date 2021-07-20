using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeButtonBehavior : MonoBehaviour
{

    #region FIELDS
    public GameObject ButtonManager;
    #endregion

    public void OnButtonPress()
    {

        // New Position for Camera
        Vector3 newPos = new Vector3(0, 10, -10);
        Vector3 newRot = new Vector3(0, 0, 0);

        // Use Fade Movement Script
        StartCoroutine(ButtonManager.GetComponent<PositionFade>().FadeAndMove(newPos, newRot));

    }

}
