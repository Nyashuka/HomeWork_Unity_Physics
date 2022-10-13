using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShell : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    private void Start()
    {
        
    }

    private void Update()
    {
        transform.Translate(0, _speed * 0.5f * Time.deltaTime, _speed * Time.deltaTime);
    }
}
