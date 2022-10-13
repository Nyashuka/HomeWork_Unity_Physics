using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 100.0f;

    [SerializeField] private Transform _transGun;
    [SerializeField] private Transform _gun;
    [SerializeField] private Transform _bullet;

    private void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);
        //transform.Translate(0, 0, _speed * Time.deltaTime);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);

        if (Input.GetKey(KeyCode.E))
        {
            _transGun.RotateAround(_transGun.position, _transGun.right, -2);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            _transGun.RotateAround(_transGun.position, _transGun.right, 2);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(_bullet, _gun.position, _gun.rotation);
        }

    }
}
