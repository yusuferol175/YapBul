using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;


public class master : MonoBehaviour
{
    public static GameObject master_obje;

    public GameObject yanlis_panel;
    public GameObject dogru_panel;
    public GameObject final_panel;
    public GameObject telefon_panel;
    public GameObject seyirci_panel;
    public GameObject final_bilgi_panel;

    public GameObject yari_jkr;
    public GameObject telefon_jkr;
    public GameObject ikix_jkr;
    public GameObject syrc_jkr;

    public GameObject final_but;
    public GameObject final_next;
    public GameObject yb1;
    public GameObject yb2;
    public GameObject yb3;
    public GameObject yb4;
    public GameObject yb5;
    public GameObject yb6;
    public GameObject yb7;
    public GameObject yb8;
    public GameObject yb9;

    public TextMeshProUGUI soru_txt;
    public TextAsset metin_belgesi;
    string[] sorular;

    public Button[] cevap_butonlari;

    string cevap;

    int ilksatir= 0;
    int sonsatir= 5;

    public static int dogrucevap = 1;
    public static int odulparasi = 0;
    int artis=1000;


    public int soruid;
    public int yboz_id;

    public Text odulparasi_text;
    public Text odul_kznm_text;
    public Text odul_kznm_dogru_text;
    public Text odul_kznm_final_text;

    public GameObject cevapla_but;

    void soru_ekle(int ilk,int son)
    {
        //B:
        // soruid = Random.Range(0,109);
        // foreach (var item in soruidlist)
        // {
        //     if (soruid==item)
        //     {
        //         goto B;
        //     }
        // }
        // soruidlist.Add(soruid);

        
        if (PlayerPrefs.GetInt("soru_id") == 268)
        {
            PlayerPrefs.SetInt("soru_id", 0);
        }
        int soruid = PlayerPrefs.GetInt("soru_id");
        ilk = soruid*6;
        son = ilk + 5;
        
        PlayerPrefs.SetInt("soru_id", soruid + 1);




        soru_txt.text = dogrucevap + sorular[ilk];
            cevap = sorular[son];

            cevap_butonlari[0].name = sorular[ilk + 1];
            cevap_butonlari[1].name = sorular[ilk + 2];
            cevap_butonlari[2].name = sorular[ilk + 3];
            cevap_butonlari[3].name = sorular[ilk + 4];

            cevap_butonlari[0].GetComponentInChildren<TextMeshProUGUI>().text = sorular[ilk + 1];
            cevap_butonlari[1].GetComponentInChildren<TextMeshProUGUI>().text = sorular[ilk + 2];
            cevap_butonlari[2].GetComponentInChildren<TextMeshProUGUI>().text = sorular[ilk + 3];
            cevap_butonlari[3].GetComponentInChildren<TextMeshProUGUI>().text = sorular[ilk + 4];

            
            
           

    }

    public Image a;
    public Image b;
    public Image c;
    public Image d;

    public Image[] barlar;
    public void bilgi_tamam_but()
    {
        final_bilgi_panel.SetActive(false);
    }
    public void seyirci_joker()
    {
        seyirci_panel.SetActive(true);
        int syrcrast = Random.Range(1, 3);
        if (syrcrast==1)
        {
            float yuzde_rast = Random.Range(75.0f, 96.0f);
            for (int i = 0; i < cevap_butonlari.Length; i++)
            {
                if (cevap_butonlari[i].name==cevap)
                {
                    barlar[i].fillAmount = yuzde_rast / 100.0f;
                }
                else
                {
                    float yuzde_rast_1 = Random.Range(1.0f, 8.0f);
                    barlar[i].fillAmount = yuzde_rast_1 / 100.0f;
                }
            }
        }
        else if (syrcrast==2)
        {
            for (int i = 0; i < cevap_butonlari.Length; i++)
            {
                
                    float yuzde_rast_1 = Random.Range(1.0f, 33.0f);
                    barlar[i].fillAmount = yuzde_rast_1 / 100.0f;
                
            }
        }
    }
    public void syrc_tamam_bt()
    {
        seyirci_panel.SetActive(false);
        syrc_jkr.SetActive(false);
       
    }
    public Text bilgi_text;
    public void telefon_joker()
    {
        telefon_panel.SetActive(true);
        int telrast = Random.Range(1, 4);
        if (telrast == 1)
        {
            bilgi_text.text = "+Maalesef, cevabý bilmiyorum.";
        }
        else if (telrast == 2)
        {
            bilgi_text.text = "+Cevabý biliyorum, cevap: "+ cevap;
        }
        else if (telrast == 3)
        {
            int bilemem = Random.Range(1, 3);
            if (bilemem == 1)
            {
                bilgi_text.text = "+Emin deðilim, ama: "+cevap+" olabilir.";
            }
            else if (bilemem == 2)
            {
                foreach (Button bt in cevap_butonlari)
                {
                    if (bt.name!=cevap)
                    {
                        bilgi_text.text = "+Emin deðilim, ama: " + bt.name + " olabilir.";

                        break;
                    }
                }
                
            }
        }
    }
    public void tlfn_tamam_bt()
    {
        telefon_panel.SetActive(false);
        telefon_jkr.SetActive(false);
    }
    public void yari_joker()
    {
        yari_jkr.SetActive(false);
        int silinen_cevap = 0;
        foreach (var bt in cevap_butonlari)
        {
            if (bt.name!=cevap)
            {
                bt.GetComponentInChildren<TextMeshProUGUI>().text = null;
                silinen_cevap++;
            }

            if (silinen_cevap==2)
            {
                break;
            }
        }
    }

    public bool birinci_hak = false;
    public void ikix_joker()
    {
        ikix_jkr.SetActive(false);
        birinci_hak = true;
    }
    public GameObject final_reklam_but;
    public void siradaki_soru()
    {
        final_reklam_but.SetActive(false);
        Time.timeScale = 1f;
        dogru_panel.SetActive(false);
        final_panel.SetActive(false);
        ilksatir = sonsatir + 1;
        sonsatir = ilksatir + 5;

        soru_ekle(ilksatir, sonsatir);
        butonolayoyun.zaman = 30;

        odulparasi_text.text = odulparasi.ToString();
    }
    List<int> ybozlist = new List<int>();
    List<int> soruidlist = new List<int>();
    public void cevap_kontrol(string deger)
    {

        if (deger==cevap)
        {
            birinci_hak = false;
            dogru_panel.SetActive(true);
           // Debug.Log("bildiniz");
            dogrucevap++;
            odulparasi += artis;
            Time.timeScale = 0f;
            odul_kznm_dogru_text.text = odulparasi.ToString();
           
            if (dogrucevap == 10 || dogrucevap == 13)
            {
                artis = 2000;
            }

            if (dogrucevap==4)
            {
                final_bilgi_panel.SetActive(true);
            }
            if (dogrucevap==4||dogrucevap==7|| dogrucevap == 10 || dogrucevap == 13 || dogrucevap == 16 || dogrucevap == 19 || dogrucevap == 22 || dogrucevap == 25 || dogrucevap == 28)
            {
                
                if (odulparasi!=0)
                {
                    cevapla_but.SetActive(true);
                }
                odul_kznm_final_text.text = odulparasi.ToString();
                A:
                yboz_id = Random.Range(0, 9);
                foreach (var item in ybozlist)
                {
                    if (item ==yboz_id)
                    {
                        goto A;
                    }
                    
                }
                ybozlist.Add(yboz_id);
                dogru_panel.SetActive(false);
                final_panel.SetActive(true);
                if (yboz_id==1)
                {
                    yb1.SetActive(false);
                }
                if (yboz_id == 2)
                {
                    yb2.SetActive(false);
                }
                if (yboz_id == 3)
                {
                    yb3.SetActive(false);
                }
                if (yboz_id == 4)
                {
                    yb4.SetActive(false);
                }
                if (yboz_id == 5)
                {
                    yb5.SetActive(false);
                }
                if (yboz_id == 6)
                {
                    yb6.SetActive(false);
                }
                if (yboz_id == 7)
                {
                    yb7.SetActive(false);
                }
                if (yboz_id == 8)
                {
                    yb8.SetActive(false);
                }
                if (yboz_id == 0)
                {
                    yb9.SetActive(false);
                }
            }
            if (dogrucevap==28)
            {
                
                final_next.SetActive(false);
            }
        }
        else
        {
            if (birinci_hak!=true)
            {
                int ynls_id = PlayerPrefs.GetInt("yanlýs_id")+1;
                PlayerPrefs.SetInt("yanlýs_id", ynls_id);
                if (PlayerPrefs.GetInt("yanlýs_id")==3)
                {
                    gecis_reklam_sc.gecis_obje.GetComponent<gecis_reklam_sc>().gecis_ad();
                    PlayerPrefs.SetInt("yanlýs_id", 0);
                }
                
                PlayerPrefs.SetInt("gecis_ad_durum", 1);
                odul_kznm_text.text = odulparasi.ToString();
               // Debug.Log("bilemediniz :(");
                yanlis_panel.SetActive(true);
            }
            else
            {
                buton_kontrol.tklnbtn.GetComponentInChildren<TextMeshProUGUI>().text = null;
                birinci_hak = false;
            }
            
        }
    }

    void Start()
    {
        dogrucevap = 1;
        odulparasi = 0;
        yanlis_panel.SetActive(false);
        dogru_panel.SetActive(false);
        final_panel.SetActive(false);
        telefon_panel.SetActive(false);
        seyirci_panel.SetActive(false);
        final_bilgi_panel.SetActive(false);

        sorular = metin_belgesi.text.Split("\n"[0]);

        soru_ekle(ilksatir, sonsatir);

         master_obje = gameObject;
    }

    
}
