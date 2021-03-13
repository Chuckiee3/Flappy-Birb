using TMPro;
using UnityEngine;

public class DebugCanvas : MonoBehaviour
{
    private PlayerMicControl _playerMicControl;
    public TextMeshProUGUI tmp;
    void Start()
    {
        _playerMicControl = FindObjectOfType<PlayerMicControl>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = _playerMicControl.GetDB().ToString("F4");
    }
}
