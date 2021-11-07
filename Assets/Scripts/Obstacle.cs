using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PipesGenerator pipesGenerator;
    UIManagment managment;

    private void Start()
    {
        pipesGenerator = FindObjectOfType<PipesGenerator>();
        managment = FindObjectOfType<UIManagment>();
    }

    // wywoluje sie, gdy hero dotknie triggera(niewidocznego) pomiedzy pipesami, czyli udalo sie pokonac przeszkodę
    private void OnTriggerEnter(Collider collider)
    {
        pipesGenerator.CreateObstacle();
        managment.AddPoint();
    }
}
