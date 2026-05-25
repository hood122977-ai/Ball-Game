using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = transform.position - collision.gameObject.transform.position;
        direction = direction.normalized * 1000;
        collision.gameObject.GetComponent<Rigidbody>().AddForce(direction);
    }

    float delta = -0.3f;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        float newXposition = transform.localPosition.x + delta;
        transform.localPosition = new Vector3(newXposition,
            transform.localPosition.y,
            transform.localPosition.z);
        if (transform.localPosition.x < -13.5)
        {
            delta = 0.3f;
        }
        else if (transform.localPosition.x > 13.5)
        {
            delta = -0.3f;
        }
    }
}
