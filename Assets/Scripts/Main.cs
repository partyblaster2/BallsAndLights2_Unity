using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Main : MonoBehaviour
{
    public Rigidbody ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // Vi bruger funktionen ScreenPointToRay på det nuværende hovedkamera
            // for at få en ray (stråle) i "verdens" koordinater ud fra musens
            // skærm koordinater.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Med vektor-regning flyttes position lidt væk fra kameraet, så 
            // vores nye kugle ikke starter for tæt på.
            // Prøv evt. at ændre tallet og se hvad der sker.
            // f'et er nødvendigt for at lave tallet til et såkaldt "float".
            Vector3 position = ray.origin + ray.direction * 2.0f;

            // Tilføj en ny kugle på den beregnede position. Quaternion.identity
            // bestemmer hvordan den er roteret i rummet.
            // For en kugle gør det naturligvis ingen forskel.
            Rigidbody body = Instantiate(ballPrefab, position, Quaternion.identity);

            // Sæt en fart i retning af strålen fra kameraet
            body.velocity = ray.direction * 5.0f;
            body.mass = 10.0f;
        }

    }
}
