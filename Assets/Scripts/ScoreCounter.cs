using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText; // Metin nesnesinin TextMeshPro bileşenine referans
    
    void Start()
    {
        UpdateScoreText(); // Başlangıçta skor metnini güncelle
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString(); // Skor metnini güncelle
    }

    // Skoru artıran bir fonksiyon örneği
    public void IncreaseScore(int amount)
    {
        score += amount; // Skoru artır
        UpdateScoreText(); // Skor metnini güncelle
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Score"))
        {
            IncreaseScore(1);
            col.gameObject.SetActive(false);
            Debug.Log(score);

        }
    }
}
