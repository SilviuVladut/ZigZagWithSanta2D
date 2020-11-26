using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    // asta e un cod pt responsive design, practic background-ul e responsive pe orice rezolutie
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer> ();
        Vector3 tempScale = transform.localScale;

        float width = sr.sprite.bounds.size.x; //asta ne da latimea de la MainCamera(dreptunghiul ala) ca sa facem bg-ul full-width

       float worldHeight = Camera.main.orthographicSize * 2.0f;
       float worldWidth = worldHeight / Screen.height * Screen.width;
        
       tempScale.x = worldWidth/width;

        transform.localScale = tempScale;
        
    }

   
}
