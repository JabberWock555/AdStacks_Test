using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewController : MonoBehaviour
{
    [SerializeField]private Material material;
    public static bool dropable = true;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<ObjectGrab>();
        material.color = Color.red;
        material.color.a.Equals(0.5f);
        dropable = false;

    }

    private void OnTriggerExit(Collider other)
    {
        dropable = true;
        material.color = Color.white;
        material.color.a.Equals(0.5f);
    }

}
