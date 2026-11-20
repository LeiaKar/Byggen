using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changescene : MonoBehaviour
{
    [Tooltip("This is the scene to load")]
    [SerializeField] public string ScenetoChangeinto;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(ScenetoChangeinto);
        }
    }
}