using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    private PlayerMoveJoystick playerMove;


    void Start()
    {
        playerMove = GameObject.Find("Santa").GetComponent<PlayerMoveJoystick>();
    }
    public void OnPointerDown(PointerEventData data) //cand apasam butonul
    {
        if(gameObject.name == "Left")
        {
            playerMove.SetMoveLeft(true);
        }
        else
        {
            playerMove.SetMoveLeft(false);
        }
    }

    public void OnPointerUp(PointerEventData data) //cand nu mai e apasat butonul
    {
        playerMove.StopMoving();
    }
}
