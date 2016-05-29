﻿using UnityEngine;
using System.Collections;

public class ClickScript : MonoBehaviour
{
     public bool clickedIs = false;

     void OnMouseDown()
     {
          clickedIs = true;
     }

     void OnMouseUp()
     {
          clickedIs = false;
     }
}