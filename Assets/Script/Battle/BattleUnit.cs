using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleUnit : MonoBehaviour
{
    // [SerializeField] PokemonBase _base;
    // [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;
    [SerializeField] Vector3 initialPosition;

    Image image;
    Vector3 originPos;
    Color originColor;

    public Pokemon Pokemon { get; set; }

    void Awake()
    {
        image = GetComponent<Image>();
        originColor = image.color;
        originPos = initialPosition;
    }

    void Start()
    {
    }

    public void Setup(Pokemon pokemon)
    {
        Pokemon = pokemon;
        Debug.Log($"{pokemon.Base.PokemonName} HP:{pokemon.HP}: {originPos.y}");

        image.transform.localPosition = originPos;

        // var newPos = new Vector3(originPos.x, originPos.y + 150f);
        // originPos = newPos;

        if (isPlayerUnit)
        {
            image.sprite = Pokemon.Base.BackSprite;
        }
        else
        {
            image.sprite = Pokemon.Base.FrontSprite;
        }

        GetComponent<Image>().SetNativeSize();
        transform.localScale = new Vector3(3, 3, 3);
        image.color = originColor;
        PlayEnterAnimation();
    }

    public void PlayEnterAnimation()
    {
        if (isPlayerUnit)
        {
            image.transform.localPosition = new Vector3(-500f, originPos.y);
        }
        else
        {
            image.transform.localPosition = new Vector3(500f, originPos.y);
        }
        image.transform.DOLocalMoveX(originPos.x, 1f);
    }

    public void PlayAttackAnimation()
    {
        var sequence = DOTween.Sequence();
        if (isPlayerUnit)
        {
            sequence.Append(image.transform.DOLocalMoveX(originPos.x + 50f, 0.25f));
        }
        else
        {
            sequence.Append(image.transform.DOLocalMoveX(originPos.x - 50f, 0.25f));
        }
        sequence.Append(image.transform.DOLocalMoveX(originPos.x, 0.25f));
    }

    public void PlayHitAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.DOColor(Color.gray, 0.1f));
        sequence.Append(image.DOColor(originColor, 0.1f));
        // sequence.Append(image.DOColor(Color.gray, 0.1f));
        // sequence.Append(image.DOColor(originColor, 0.1f));
    }

    public void PlayFaintAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.transform.DOLocalMoveY(originPos.y - 150f, 0.5f));
        sequence.Join(image.DOFade(0f, 0.5f));
    }

    public IEnumerator PlayCaptureAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.DOFade(0, 0.5f));
        sequence.Join(transform.DOLocalMoveY(originPos.y + 50f, 0.5f));
        sequence.Join(transform.DOScale(new Vector3(0.3f, 0.3f, 1f), 0.5f));
        yield return sequence.WaitForCompletion();
    }

    public IEnumerator PlayBreakOutAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.DOFade(1, 0.5f));
        sequence.Join(transform.DOLocalMoveY(originPos.y, 0.5f));
        sequence.Join(transform.DOScale(new Vector3(3f, 3f, 3f), 0.5f));
        yield return sequence.WaitForCompletion();
    }
}
