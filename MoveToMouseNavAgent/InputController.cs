using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    private static readonly string MOVEACTION_NAME = "MoveClick"; <== Change me!
    private PlayerClickToMove _playerMoveHandler;
    private PlayerInput _playerInput;
    private InputActionAsset _inputActions;
    private InputAction _moveAction;
    
    private void OnEnable()
    {
        _EnablePlayerInput();
        _moveAction.performed +=_=> _Move();
    }

    private void _EnablePlayerInput()
    {
        _playerInput = gameObject.GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions[MOVEACTION_NAME];
        _playerMoveHandler = gameObject.GetComponent<PlayerClickToMove>();
    }

    private void _Move()
    {
        if (_DoRayCast(Input.mousePosition, out RaycastHit hit))
        {
            _playerMoveHandler.MoveToMouse(hit);
        }
        else
        {
            Debug.Log("No valid target for Move");
        }
    }

    private bool _DoRayCast(Vector3 mousePosition, out RaycastHit hit)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        return Physics.Raycast(ray, out hit);
    }
}
