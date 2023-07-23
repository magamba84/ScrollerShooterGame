using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float characterSize = 0.1f;
    [SerializeField] private Transform leftBorder;
    [SerializeField] private Transform rightBorder;
    [SerializeField] private Transform topBorder;
    [SerializeField] private Transform bottomBorder;
    private bool isActive = false;

    public void SetActive(bool active)
    {
        isActive = active;
    }

    private void Update()
    {
        if (!isActive)
            return;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0f) * moveSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, leftBorder.position.x + characterSize, rightBorder.position.x - characterSize);
        newPosition.y = Mathf.Clamp(newPosition.y, bottomBorder.position.y, topBorder.position.y);

        transform.position = newPosition;
    }
}
