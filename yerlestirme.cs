using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yerlestirme : MonoBehaviour
{
    public GameObject player;
    public GameObject el;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("karakter");
        el = player.transform.GetChild(0).gameObject;
    }
    private void OnMouseDown()
    {
        if(player.GetComponent<Player>().elinde)
        {
            GameObject kup = el.transform.GetChild(0).gameObject;
            kup.transform.parent = null;
            kup.transform.position = gameObject.transform.position;
            kup.transform.eulerAngles = transform.eulerAngles;
        }
    }
}
