using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    CharacterController characterController;
    Rigidbody m_Rigidbody;
    public float m_Speed = 5f;
    public bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        characterController = gameObject.GetComponent<CharacterController>();
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Rigidbody.velocity.y == 0)
        {
            isGrounded = true;
        }
        //Store user input as a movement vector
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * 500, 0, Input.GetAxis("Vertical") * Time.deltaTime * 500);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            m_Rigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            isGrounded = false;
        }
        m_Rigidbody.AddForce(m_Input);

        ////Apply the movement vector to the current position, which is
        ////multiplied by deltaTime and speed for a smooth MovePosition
        //m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
