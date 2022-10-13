using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    public float speed = 0f;
    private float _ySpeed = 0f;

    private float _force = 10f;
    private float _mass = 100f;
    private float _drag = 1f;

    private float _gravity = -9.8f;
    private float _gravityAcceleration;

    //private float acceleration;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "tank")
        {
            GameObject exp = Instantiate(_explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        speed += _force / _mass;

        _gravityAcceleration = _gravity / _mass;
    }

  
    private void LateUpdate()
    {
        speed *= (1 - Time.deltaTime * _drag);
        _ySpeed += _gravityAcceleration * Time.deltaTime;

        transform.Translate(0, _ySpeed, speed * Time.deltaTime);
    }
}
