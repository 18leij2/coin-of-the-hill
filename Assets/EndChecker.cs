using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndChecker : MonoBehaviour
{
    public GameObject endScreen;
    private void OnTriggerExit2D(Collider2D collision)
    {
        endScreen.SetActive(true);
    }
}
