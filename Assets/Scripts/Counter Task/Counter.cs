using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Counter : MonoBehaviour
{
    private const float Delay = .5f;
    private Text _counterField;

    private bool _isStarted = false;
    private int _value = 0;

    private IEnumerator _coroutine;

    private void Awake()
    {
        _counterField = GetComponent<Text>();
        _coroutine = CounterRoutine();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SwitchState();
    }

    private void SwitchState()
    {
        if (_isStarted)
        {
            _isStarted = false;
            StopCoroutine(_coroutine);
        }
        else
        {
            _isStarted = true;
            StartCoroutine(_coroutine);
        }
    }

    private IEnumerator CounterRoutine()
    {
        var wait = new WaitForSeconds(Delay);

        while (_isStarted)
        {
            yield return wait;

            _value++;
            _counterField.text = _value.ToString();
        }
    }
}
