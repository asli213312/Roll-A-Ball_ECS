using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    private GameObject _player;
    
    private void OnValidate()
    {
        if (_player == null) _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float totalXPosition = offset.x + _player.transform.position.x;
        float totalYPosition = offset.y + _player.transform.position.y;
        float totalZPosition = offset.z + _player.transform.position.z;
        transform.position = new Vector3(totalXPosition, totalYPosition, totalZPosition);
    }
}
