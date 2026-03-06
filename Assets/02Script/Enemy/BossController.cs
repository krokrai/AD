using System;
using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject GuidLine;
    [SerializeField] LayerMask layerMaskTarget;
    [SerializeField] GameObject gameClearMenu;

    BossSO state;
    BeamObject beam;

    public event Action<float> OnBossHealthChanged;

    WaitForSeconds _3Delay = new WaitForSeconds(3);


    float patternOneCoolTime;
    float patternCoolDown;
    bool isPatternRunning;
    float health;
    float _time;
    Color _color;

    private void Awake()
    {
        health = 1000;
        //state 초기화 필요
        GuidLine.SetActive(false);
        _color = new Color(1, 0.39f, 0.45f, 0.40f);
        isPatternRunning = false;
    }

    private void Start()
    {
        beam = GuidLine.GetComponent<BeamObject>();
        beam.InitState(layerMaskTarget);
        patternOneCoolTime = 8f;
        PatternOne();
    }

    private void Update()
    {
        patternCoolDown += Time.deltaTime;
        if (patternCoolDown > patternOneCoolTime && !isPatternRunning)
        {
            isPatternRunning = true;
            PatternOne();
        }
    }

    private void PatternOne()
    {
        GuidLine.SetActive(true);
        _color.a = 0.4f;
        GuidLine.GetComponent<SpriteRenderer>().color = _color;
        StartCoroutine(PatterOneExe());
    }

    IEnumerator PatterOneExe()
    {
        GuidLine.transform.position = target.transform.position;
        while (_time < 3f)
        {
            _time += Time.deltaTime;
            _color.a = _time / 3;
            GuidLine.GetComponent<SpriteRenderer>().color = _color;
            GuidLine.transform.position = new Vector3(Vector3.Lerp(GuidLine.transform.position, target.transform.position, 0.005f).x, 2);
            yield return null;
        }

        beam.canDamage = true;

        yield return _3Delay;

        beam.canDamage = false;
        GuidLine.SetActive (false);
        isPatternRunning = false;
        _time = 0;
        patternCoolDown = 0;
        yield break;
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        OnBossHealthChanged?.Invoke(health / 1000);
        if ( health < 0)
        {
            gameClearMenu.SetActive(true);
        }
        
    }
}
