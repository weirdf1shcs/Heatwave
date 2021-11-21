using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioClip pilesOfSnow;
    [SerializeField] AudioClip vehicularCombat;
    [SerializeField] AudioClip Stardust;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
