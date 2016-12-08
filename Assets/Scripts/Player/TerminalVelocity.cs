using UnityEngine;
using System.Collections;

public class TerminalVelocity : MonoBehaviour {

    private Rigidbody2D rb; // the rigidbody of the object
    private Vector3 rbv; // the velocity of the rigidbody
    private bool xIsNegative;
    private bool yIsNegative;

    public float xMax; // the max value of the x velocity
    public float yMax; // the max value of the y velocity

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rbv = rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rbv);
        //checking if the x velocity is negative and temporarily making it positive if it is
        if (rbv.x < 0)
        {
            xIsNegative = true;
            rbv = new Vector3(-rbv.x, rbv.y, 0f);
        }
        else
        {
            xIsNegative = false;
        }
        //checking if the y velocity is negative and temporarily making it positive if it is
        if (rbv.y < 0)
        {
            yIsNegative = true;
            rbv = new Vector3(rbv.x, -rbv.y, 0f);
        }
        else
        {
            yIsNegative = false;
        }

        //checking the x velocity to see if its greater than the xmax and setting it to xmax if it is
        if (rbv.x > xMax)
        {
            rbv.x = xMax;
        }
        //checking the y velocity to see if its greater than the xmax and setting it to ymax if it is
        if (rbv.y > yMax)
        {
            rbv.y = yMax;
        }
        //if the x velocity is negative change it back to negative
        if (xIsNegative)
        {
            rbv = new Vector3(-rbv.x, rbv.y, 0f);
        }
        //if the y velocity is negative change it back to negative
        if (yIsNegative)
        {
            rbv = new Vector3(rbv.x, -rbv.y, 0f);
        }

    }
}
