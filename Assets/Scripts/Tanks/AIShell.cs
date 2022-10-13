using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShell : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    private Rigidbody _rigidbody;

    public float speed = 0f;
    private float _ySpeed = 0f;

    private float _force = 10f;
    private float _mass = 100f;
    private float _drag = 1f;

    private float _gravity = -9.8f;
    private float _gravityAcceleration;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "tank")
        {
            GameObject exp = Instantiate(_explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        transform.transform.forward = _rigidbody.velocity;
    }
}
