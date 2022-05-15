using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickTest : MonoBehaviour
{
    public void OnMouseDown()
    {
        print("Clicked");
    }

    //public void OnPointerClick(PointerEventData pointerEventData)
    //{
    //    Debug.Log("Clicked");
    //}
}
