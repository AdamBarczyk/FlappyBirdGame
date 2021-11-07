using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagment : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI pointsText;
    float points;
    Hero hero;

    private void Start()
    {
        hero = FindObjectOfType<Hero>();
        pointsText = FindObjectOfType<TextMeshProUGUI>();
        Time.timeScale = 1f;
        pointsText.text = points.ToString();
    }

    private void Update()
    {
        if (hero.wereCollision == true)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void AddPoint()
    {
        points++;
        pointsText.text = points.ToString();
    }
}
