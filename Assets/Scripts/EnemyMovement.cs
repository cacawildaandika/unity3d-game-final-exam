using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterController controller;
    int moveTo = 1;
    public float maxDistance;
    public float minDistance;
    public float movementSpeed = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if(moveTo == 1)
        {
            Vector3 move = new Vector3(0, 0, -5);
            controller.Move(move * Time.deltaTime * movementSpeed);

            if (controller.transform.position.z < maxDistance)
            {
                moveTo = 0;
                controller.transform.Rotate(new Vector3(0f, 180f, 0f));
            }
        }
        else
        {
            Vector3 move = new Vector3(0, 0, 5);
            controller.Move(move * Time.deltaTime * movementSpeed);

            if (controller.transform.position.z > minDistance)
            {
                moveTo = 1;
                controller.transform.Rotate(new Vector3(0f, 180f, 0f));
            }
        }
    }
}
