using UnityEngine;

public class CubeColorController : MonoBehaviour
{
    [SerializeField] private float _colorChangeTime = 3f;
    [SerializeField] private float _delayAfterChangedColor = 2f;

    private Color _currentColor;
    private Color _newColor;
    private float _currentTime;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _currentColor = _renderer.material.color;
        GenerateNewColor();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _colorChangeTime && _currentTime <= _delayAfterChangedColor + _colorChangeTime)
        {
            return;
        }

        var progressTime = _currentTime / _colorChangeTime;
        var currentColor = Color.Lerp(_currentColor, _newColor, progressTime);
        _renderer.material.color = currentColor;
        
        if (_currentTime >= _colorChangeTime)
        {
            _currentTime = 0f;
            GenerateNewColor();
        }
    }

    private void GenerateNewColor()
    {
        _currentColor = _renderer.material.color;
        _newColor = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
    }
}
