using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] Text _text;

    private int _score;

    private void OnEnable()
    {
        _score = 0;
        StartCoroutine(ScoreCount());
    }

    private void OnDisable()
    {
        StopCoroutine(ScoreCount());
    }

    public IEnumerator ScoreCount()
    {
        var time = new WaitForSeconds(1);
        
        while (gameObject.activeSelf)
        {
            _score++;
            _text.text = _score.ToString();
            yield return time;
        }
    }
}
