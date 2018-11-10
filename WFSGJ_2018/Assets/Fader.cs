using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public delegate void FadeAction();

    public static Fader Instance { get; private set; }

    public Transform dots;

    Image _fader;
    Coroutine _fadeCoroutine;
    bool _active;

    public bool IsActive { get { return _active; } }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance.gameObject);
        _fader = GetComponent<Image>();
        var color = new Color(1, 1, 1, 0);
        _fader.color = color;
        if (dots) dots.gameObject.SetActive(false);
    }

    public void StartBuffering(float bufferingTime = 2, FadeAction fadeActions = null)
    {
        StartCoroutine(Buffering(bufferingTime, fadeActions));
    }

    IEnumerator Buffering(float bufferingTime, FadeAction fadeActions)
    {
        _active = true;

        float t = 0;
        var startValue = _fader.color.a;
        while (t < 1)
        {
            t += Time.deltaTime / 0.25f;
            var color = new Color(0, 0, 0, Mathf.Lerp(startValue, 1, t));
            Debug.Log(color);
            _fader.color = color;
            Debug.Log(color);
            yield return null;
        }

        if (dots) dots.gameObject.SetActive(true);
        for (int i = 0; i < (int)(bufferingTime / 0.1f); i++)
        {
            yield return new WaitForSeconds(0.1f);
            var eulear = dots.eulerAngles;
            eulear.z -= 29;
            dots.eulerAngles = eulear;
        }
        if (dots) dots.gameObject.SetActive(false);


        if (fadeActions != null)
        {
            fadeActions();
        }


        t = 0;
        startValue = 1;
        while (t < 1)
        {
            t += Time.deltaTime / 0.25f;
            var color = new Color(0, 0, 0, Mathf.Lerp(startValue, 0, t));
            _fader.color = color;
            yield return null;
        }

        _active = false;
    }
}
