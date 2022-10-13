using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShell : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    public float Speed => _speed;
    private void Start()
    {
        
    }

    private void Update()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
    }
}
