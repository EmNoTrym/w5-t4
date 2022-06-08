using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Cannon : MonoBehaviour
{
    public int score;

    [SerializeField] GameObject cannonball;
    [SerializeField] Transform firepoint;
    [SerializeField] Transform rotatePoint;

    [SerializeField] Texture2D crosshair;
    [SerializeField] CursorMode cursorMode = CursorMode.Auto;
    [SerializeField] Vector2 hotSpot = Vector2.zero;

    [SerializeField] Slider forcebar;
    [SerializeField] TextMeshProUGUI cannoballLeft;
    [SerializeField] TextMeshProUGUI yourScore;
    [SerializeField] GameObject gameover;

    private float cannonballFired = 0;


    private void Start()
    {
        Cursor.SetCursor(crosshair,hotSpot,cursorMode);
        cannonballFired = 0;
        score = 0;
        SetCannonballLeftText();
        gameover.SetActive(false);
    }

    private void Update()
    {
        if (cannonballFired < 10)
        {
            float rotateLRCannon = Input.GetAxis("Mouse X");
            float rotateUDCannon = Input.GetAxis("Mouse Y");

            rotatePoint.Rotate(-rotateUDCannon, 0, 0);
            transform.Rotate(0, rotateLRCannon, 0);

            if (Input.GetButton("Fire1"))
            {
                forcebar.value += 0.5f;
            }

            else if (Input.GetButtonUp("Fire1"))
            {
                fireCannonball();
                forcebar.value = 0;
                SetCannonballLeftText();
            }
        }

        else
        {
            SetYourScoreText();
            gameover.SetActive(true);
        }
    }

    private void fireCannonball()
    {
        GameObject ball = Instantiate(cannonball, firepoint.position, Quaternion.identity);

        Rigidbody rb = ball.GetComponent<Rigidbody>();

        rb.velocity = forcebar.value * firepoint.up;

        cannonballFired++;
    }

    private void SetCannonballLeftText()
    {
        cannoballLeft.text = "Cannonballs Left:" + (10 - cannonballFired);
    }
    private void SetYourScoreText()
    {
        yourScore.text = "Your Score:" + score;
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
