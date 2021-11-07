using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float speed;
    public float jumpHigh;
    public bool wereCollision = false;
    float timer = 0;
    Rigidbody heroRigidbody;

    // komponent rigidbody kontroluje fizykę hero
    private void Start()
    {
        heroRigidbody = GetComponent<Rigidbody>();
    }

    // funkcja obsługuje przyspieszenie poruszania się hero wraz ze wzrostem upłyniętego czasu gry.
    // warunki odpowiadają za to, żeby hero nie przekroczył dolnej i górnej granicy kamery(ekranu)
    // jak dotknie dolnej -> to porusza się dalej po dolnej granicy
    // jak dotknie gornej -> to spada
    // jak gracz wcisnie spację -> to hero podskakuje w górę o jumpHigh (deklarowane w unity)
    private void Update()
    {
        timer += Time.deltaTime;
        heroRigidbody.velocity = new Vector3(speed + (timer / 3), heroRigidbody.velocity.y, heroRigidbody.velocity.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            heroRigidbody.velocity = new Vector3(heroRigidbody.velocity.x, heroRigidbody.velocity.y + jumpHigh, heroRigidbody.velocity.z);
        }
        if (transform.position.y > 6)
        {
            ChangeGravity(6);
        }
        else if (transform.position.y < -6)
        {
            ChangeGravity(-6);
        }
        transform.rotation = Quaternion.Euler((heroRigidbody.velocity.y * 2) - 60, -90, -90);
    }
    private void ChangeGravity(int gravity)
    {
        transform.position = new Vector3(transform.position.x, gravity, transform.position.z);
        heroRigidbody.velocity = new Vector3(heroRigidbody.velocity.x, 0, 0);
    }

    // wywoluje się, gdy nastąpi kolizja z pipem. Dotyczy obiektu, do którego podpięty jest skrypt
    private void OnCollisionEnter(Collision collision)
    {
        wereCollision = true;
    }
}
