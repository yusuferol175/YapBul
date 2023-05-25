using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class butonolaymenu : MonoBehaviour
{
    public GameObject nasiloynanir;
    public GameObject geridon;

    public void oyna()
    {
        SceneManager.LoadScene("oyun");
    }
    public void nasil_but()
    {
        nasiloynanir.SetActive(true);
        geridon.SetActive(true);
    }
    public void geridon_but()
    {
        nasiloynanir.SetActive(false);
        geridon.SetActive(false);
    }





    // Start is called before the first frame update
    void Start()
    {
        nasiloynanir.SetActive(false);
        geridon.SetActive(false);
    }
}
