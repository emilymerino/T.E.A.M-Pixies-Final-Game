using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDestroy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.6f);
    }
}
