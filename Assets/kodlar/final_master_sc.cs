using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class final_master_sc : MonoBehaviour
{
    public GameObject kazan_panel;
    public GameObject kaybet_panel;

    public TextAsset metin_belgesi;
    string[] sorular_final;

    
    public string final_cevap;
    public string final_cevap_bosluksuz;
    


    public Image resim;
    public List<Sprite> resim_id = new List<Sprite>();

    public TextMeshProUGUI final_soru_txt;

    public Text cevap_text;
    public string verilen_cevap;



    public Text kazanma_odul_text;
    
    public Text final_eksi_text;
    public Text final_normal_odul_text;

    public GameObject cevapla_buton;
    public GameObject reklam_buton;

    public int buyukodul;
    public void final_tm()
    {
        kaybet_panel.SetActive(false);
    }
   public void cevap_kontrol_final(string deger) {


        
        if (verilen_cevap == final_cevap_bosluksuz)
        {
            Debug.Log("500k kazandýn!");
            kazan_panel.SetActive(true);
            kazanma_odul_text.text = "Ödül parasý: " + (master.odulparasi + buyukodul).ToString() + " TL";
        }
        else
        {
            kaybet_panel.SetActive(true);
            master.odulparasi -= 3000;
            final_normal_odul_text.text = master.odulparasi.ToString();
            final_eksi_text.text = "Ödül parasý: " + (master.odulparasi).ToString() + " TL";
            Debug.Log("-3000 para gitti!");
            if (master.odulparasi == 0)
            {
                if (PlayerPrefs.GetInt("reklam_final_durum") ==0)
                {
                    reklam_buton.SetActive(true);
                }
                cevapla_buton.SetActive(false);
                
            }
        }
    }
    public void cevapla_bt()
    {
       

        if (master.dogrucevap == 4)
        {
            buyukodul = 1000000;
        }
        if (master.dogrucevap == 7)
        {
            buyukodul = 700000;
        }
        if (master.dogrucevap == 10)
        {
            buyukodul = 500000;
        }
        if (master.dogrucevap == 13)
        {
            buyukodul = 300000;
        }
        if (master.dogrucevap == 16)
        {
            buyukodul = 200000;
        }
        if (master.dogrucevap == 19)
        {
            buyukodul = 150000;
        }
        if (master.dogrucevap == 22)
        {
            buyukodul = 100000;
        }
        if (master.dogrucevap == 25)
        {
            buyukodul = 50000;
        }
        if (master.dogrucevap == 28)
        {
            buyukodul = 25000;
        }
        verilen_cevap = cevap_text.text;
        cevap_kontrol_final(verilen_cevap);



    }
 

    void Start()
    {
        
        reklam_buton.SetActive(false);
        if (PlayerPrefs.GetInt("soru_f_id")==150)
        {
            PlayerPrefs.SetInt("soru_f_id", 0);
        }
        kazan_panel.SetActive(false);
        kaybet_panel.SetActive(false);

        sorular_final = metin_belgesi.text.Split("\n"[0]);

        //int soru_final_id = Random.Range(0, 3)*3;
        int soru_final_id = PlayerPrefs.GetInt("soru_f_id");
        Debug.Log(soru_final_id);
        resim.sprite = resim_id[int.Parse(sorular_final[soru_final_id])];
        final_soru_txt.text =  sorular_final[soru_final_id+1];
        final_cevap = sorular_final[soru_final_id + 2];
        final_cevap_bosluksuz = final_cevap.TrimEnd();
        PlayerPrefs.SetInt("soru_f_id", soru_final_id + 3);
        
    }
}
