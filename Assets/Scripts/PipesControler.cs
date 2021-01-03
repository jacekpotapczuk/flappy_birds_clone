using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PipesControler : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)]
    private float scrollSpeed = 1f;

    [SerializeField] private Transform[] pipes;
    
    private const float leftCutoff = -3.5f;
    private const float rightCutoff = 3.5f;
    
    private void Update()
    {
        foreach (Transform pipe in pipes)
        {
            Vector3 pos = pipe.position;
            pos.x -= scrollSpeed * Time.deltaTime;
            pipe.position = pos;
        }
        
        // Nastpene kroki:
        // odpowiednie zapętlenie pipes
        // skalowanie sie poziopmu trudnosci
        // umieranie 
        // score i wyswiuetlanie na ekranie
        // dodanie assetow
        // game menus
        // dzwiek
        // dodatkowe efekty wizualne
    }
}