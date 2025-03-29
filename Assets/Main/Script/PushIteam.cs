using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PushIteam : MonoBehaviour
{
    public float mass,force,acc;
    DialogueSensor dialogueSensor;

    public void PushThing()
    {
        acc = 1000f;
        CalFoce();
    }

    public void CalFoce()
    {
        mass = GetComponent<Rigidbody>().mass;
        force = mass * acc;
        Vector3 direction = new Vector3(force, 0f, 0f);

        GetComponent<Rigidbody>().AddForce(direction);
    }    
}
