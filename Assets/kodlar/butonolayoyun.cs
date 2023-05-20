using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class butonolayoyun : MonoBehaviour
{
    public GameObject cekil_img;
    public GameObject sure_panel;
    public Text sayac;
    public static float zaman=30;

    public void cekil()
    {
        cekil_img.SetActive(true);
    }
    public void cekil_evet()
    {
        SceneManager.LoadScene("menu");
    }
    public void cekil_hayir()
    {
        cekil_img.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        zaman = 30;
        cekil_img.SetActive(false);
        sure_panel.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (zaman>0)
        {
            zaman -= Time.deltaTime;
            sayac.text = zaman.ToString("00");
        }
        else
        {
            sure_panel.SetActive(true);
        }
        
    }
}
