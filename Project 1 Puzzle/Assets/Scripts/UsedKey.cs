using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedKey : MonoBehaviour
{
    public void usethekey()
    {
        bool playerhaskey = gameObject.GetComponentInParent<PlayerPlusGhost>().usedKey;
        if (playerhaskey == true)
        {
            gameObject.GetComponentInChildren<Key>().gameObject.SetActive(false);
            playerhaskey = false;
        }
    }
}
