using System;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneController : MonoBehaviour
{
    public bool isActive = false;
    public string altSahneAdi; // Alt sahnenin adı veya yüklemek istediğiniz sahnenin adı

    void Start()
    {
        SceneManager.LoadScene(altSahneAdi, LoadSceneMode.Additive); // Alt sahneyi yükle ve ana sahnenin üzerine bindir
    }

    private void Update()
    {
        bool sahneAktifMi = SceneManager.GetSceneByName(altSahneAdi).isLoaded;
        if (sahneAktifMi)
        {
            Time.timeScale = 0f;

        }
        else if (!sahneAktifMi)
        {
            Time.timeScale = 1f;

        }
        if (Input.GetMouseButtonDown(0) && sahneAktifMi)
        {
            BaslatButonu();
        }
        
        
    }

    public void BaslatButonu()
    {
        SceneManager.UnloadSceneAsync(altSahneAdi); // Alt sahneyi kaldır
        // İstediğiniz başlatma işlemlerini burada yapabilirsiniz
        
    }
}
