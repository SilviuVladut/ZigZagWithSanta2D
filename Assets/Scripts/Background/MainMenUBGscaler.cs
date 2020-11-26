using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenUBGscaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        
        Vector3 tempScale = transform.localScale;

        float width = sr.sprite.bounds.size.x; //asta ne da latimea de la MainCamera(dreptunghiul ala) ca sa facem bg-ul full-width

        float worldHeight = Camera.main.orthographicSize * 2.0f;
        float worldWidth = worldHeight / Screen.height * Screen.width;

        tempScale.x = worldWidth / width;

        transform.localScale = tempScale;
    }

  
}
