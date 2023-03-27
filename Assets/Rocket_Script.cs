using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Script : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * 500, 0, Input.GetAxis("Vertical") * Time.deltaTime * 500);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Rigidbody.AddRelativeForce(new Vector3(0, 500, 0), ForceMode.Impulse);
        }
        m_Rigidbody.AddTorque(m_Input);
    }
}
