using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 2f;

    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    private SpriteRenderer spriteRenderer;
    private Vector2 moveInput;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        // 방향에 따른 스프라이트 변경 (우선순위: 수직 > 수평)
        if (moveY > 0)
            spriteRenderer.sprite = spriteUp;
        else if (moveY < 0)
            spriteRenderer.sprite = spriteDown;
        else if (moveX > 0)
            spriteRenderer.sprite = spriteRight;
        else if (moveX < 0)
            spriteRenderer.sprite = spriteLeft;
    }

    void FixedUpdate()
    {
        transform.Translate(moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}