using System;
using TMPro;
using UnityEngine;

public class Cell : MonoBehaviour
{
    Vector2Int id;
    bool _isMine;

    Action<int, int> onClick;

    bool _isShowed;

    SpriteRenderer spriteRenderer;

   TMP_Text textm;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textm = GetComponentInChildren<TMP_Text>();
    }

    public void Init(Vector2Int id, bool isMine, Action<int, int> onClick) {
        this.id = id;
        this._isMine = isMine;  
        this.onClick = onClick;
        this._isShowed = false;
        textm.text = "";
    }

    public bool IsShowed { get { return _isShowed; } set { _isShowed = value; } }

    public bool IsMine { get { return _isMine; } }

    public Sprite sprite { set { spriteRenderer.sprite = value; } }

    public String texto { set { textm.text= value; } }


    void OnMouseDown() {

        onClick(id.x, id.y);
    
    }
}
