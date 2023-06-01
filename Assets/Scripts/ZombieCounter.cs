using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZombieCounter : MonoBehaviour
{
    [SerializeField] private GameObject enemies;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject winScreen;

    public void ChangeCount()
    {
        var currentEnemiesCount = enemies.GetComponentsInChildren<Rigidbody2D>();
        text.text = (currentEnemiesCount.Length - 1).ToString();

        if (currentEnemiesCount.Length - 1 == 0)
        {
            Win();
        }
    }

    private void Win()
    {
        winScreen.SetActive(true);
    }
}