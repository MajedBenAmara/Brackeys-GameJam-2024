using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator _anim;

    private PlayerMovement _playerMovement;
    private Vector2 _topLeft, _topRight, _bottomLeft, _bottomRight;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _playerMovement = PlayerManager.instance.PlayerMovement;
        _topLeft = Vector2.up + Vector2.left;
        _topRight = Vector2.up + Vector2.right;
        _bottomLeft = Vector2.down + Vector2.left;
        _bottomRight = Vector2.down + Vector2.right;

    }


    private void Update()
    {
        ManageDirectionalAnimation();
    }

    private void ManageDirectionalAnimation()
    {

        if (_playerMovement.InputAxis == Vector2.up)
            _anim.Play("top");

        if (_playerMovement.InputAxis == Vector2.down)
            _anim.Play("bottom");

        if (_playerMovement.InputAxis == Vector2.right)
            _anim.Play("right");

        if (_playerMovement.InputAxis == Vector2.left)
            _anim.Play("left");

        if (_playerMovement.InputAxis == _topLeft.normalized)
        {
            _anim.Play("top_left");
        }

        if (_playerMovement.InputAxis == _topRight.normalized)
        {
            _anim.Play("top_right");

        }

        if (_playerMovement.InputAxis == _bottomLeft.normalized)
        {
            _anim.Play("bottom_left");

        }

        if (_playerMovement.InputAxis == _bottomRight.normalized)
        {
            _anim.Play("bottom_right");
        }


    }
}
