using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject gameOver;

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

}
