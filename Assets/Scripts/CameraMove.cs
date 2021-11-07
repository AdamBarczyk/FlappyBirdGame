using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Hero heroCharacter;
    private void Start()
    {
        heroCharacter = FindObjectOfType<Hero>();
    }
    void Update()
    {
        // przechwytuje X'ową hero i porusza kamerą względem tej wspolrzednej, innymi slowy X'owa kamery jest zawsze taki sam jak X'owa hero
        transform.position = new Vector3(heroCharacter.transform.position.x, transform.position.y, transform.position.z);
    }
}
