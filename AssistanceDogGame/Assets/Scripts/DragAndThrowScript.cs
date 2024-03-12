using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndThrowScript : MonoBehaviour
{
    private bool _followPointer;
    private Vector3 _startPos;
    [SerializeField, Range(0f, 10f)]
    private float _power;
    private Rigidbody2D _rigidBody2D;
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _startPos = transform.position;
    }
    void Update()
    {
        if (_followPointer)
        {
            var mousePosition = Input.mousePosition;
            var worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
            var followPoint = new Vector3(Mathf.Clamp(worldPoint.x, -3.5f, 0f), Mathf.Clamp(worldPoint.y, -3.9f, 0f), 0);
            transform.position = followPoint;
        }
    }

    private void Fire()
    {
        FetchGameEventsManager.StartGameMethod();
        var direction = (_startPos - transform.position);
        _rigidBody2D.gravityScale = 1;
        _rigidBody2D.AddForce(direction * _power, ForceMode2D.Impulse);

    }

    private void OnMouseDown()
    {
        _followPointer = true;
    }

    private void OnMouseUp()
    {
        _followPointer = false;
        Fire();
    }
}
