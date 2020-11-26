using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
  

    void DestroyCollectable()
    {
        gameObject.SetActive(false);
    }
}
