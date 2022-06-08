using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public Cannon cannon;

    private void Start()
    {
        cannon = GameObject.Find("Cannon").GetComponent<Cannon>();
    }

    private void Update()
    {
        if(gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red"))
        {
            cannon.AddScore(5);
        }
        else if (other.CompareTag("Blue"))
        {
            cannon.AddScore(2);
        }
        else if (other.CompareTag("Yellow"))
        {
            cannon.AddScore(1);
        }
    }
}
