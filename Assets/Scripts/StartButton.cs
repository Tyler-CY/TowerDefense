using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameManager gm;

    public void Ready()
    {
        gm.GetComponent<WaveSpawner>().Ready();
        Destroy(gameObject);
    }
}
