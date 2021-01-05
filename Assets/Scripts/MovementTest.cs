using System;
using UnityEngine;

public class MovementTest : MonoBehaviour
{

    public Transform[] przesuwajki;
    
    private float scrollSpeed = 2.5f;
        
    private void Update()
    {
        for (int i = 0; i < przesuwajki.Length; i++)
        {
            Vector3 pos = przesuwajki[i].localPosition;
            pos.x -= scrollSpeed * Time.deltaTime;
            przesuwajki[i].localPosition = pos;
        }
    }
}