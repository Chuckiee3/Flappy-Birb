using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BGResizer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private bool _xOnly;
    private void Awake()
    {
        ResizeSpriteToScreen();
    }

    public void ResizeSpriteToScreen() {
        if (_spriteRenderer == null)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        transform.localScale = Vector3.one;
     
        var width = _spriteRenderer.sprite.bounds.size.x;
        var height = _spriteRenderer.sprite.bounds.size.y;
     
        //Called once in awake 
        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        var scale = transform.localScale;
        scale.x = worldScreenWidth / width ;
        if(!_xOnly)
            scale.y = worldScreenHeight / height;
        transform.localScale = scale;
    }
}
