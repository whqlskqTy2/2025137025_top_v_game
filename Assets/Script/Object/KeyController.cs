using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public static bool hasKey = false; // ¿­¼è »óÅÂ ÀúÀå (Àü¿ª º¯¼ö)

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hasKey = true;
            Debug.Log("¿­¼è È¹µæ!");
            Destroy(gameObject); // ¿­¼è »ç¶óÁü
        }
    }
}