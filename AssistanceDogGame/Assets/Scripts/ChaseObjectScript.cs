using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseObjectScript : MonoBehaviour
{
    [SerializeField] 
    private GameObject _objectToChase;
    [SerializeField]
    private GameObject[] _distractions;
    private Rigidbody2D _rigidBody2D;
    private bool _chasing;
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _objectToChase = GameObject.FindGameObjectWithTag("Chaseable");
        FetchGameEventsManager.Started += StartChase;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (_chasing)
        {
            _rigidBody2D.velocity = new Vector2(Mathf.Clamp(_rigidBody2D.velocity.x + 0.1f, 0f, 8f), 0);
        }

        if (transform.position.x >= _objectToChase.transform.position.x)
        {
            StopChase();
        }
    }

    private void DecideWhatToChase()
    {
        if (Random.value < 0.5f)
        {
            return;
        }
        _objectToChase = _distractions[Random.Range(0, _distractions.Length)];
    }

    private void StartChase()
    {
        DecideWhatToChase();
        _chasing = true;
    }

    private void StopChase()
    {
        _chasing = false;
        _rigidBody2D.velocity = Vector2.zero;
    }
}
