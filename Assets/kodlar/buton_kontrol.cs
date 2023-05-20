using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buton_kontrol : MonoBehaviour
{
    master mstr;

    public static GameObject tklnbtn;
    private void Start()
    {
        mstr = GameObject.Find("master").GetComponent<master>();

    }

    public void tikla()
    {
        tklnbtn = gameObject;
        mstr.cevap_kontrol(gameObject.name);
        
    }
}
