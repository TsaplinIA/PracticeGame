using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[ExecuteInEditMode]
public class test : MonoBehaviour
{
    public bool isOk = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOk = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        isOk = true;
    }
}