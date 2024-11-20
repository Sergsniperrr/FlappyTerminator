using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Rocket _rocket;

    private void Update()
    {
        if (_input.IsShootKeyPress)
        {
            _rocket.enabled = true;
            _rocket.Launch(transform);
        }
    }
}
