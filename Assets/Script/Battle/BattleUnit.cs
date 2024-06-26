using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] PokemonBase _base;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;

    Image image;
    Vector3 originPos;
    Color originColor;

    public Pokemon Pokemon { get; set; }

    void Awake()
    {
        image = GetComponent<Image>();
        originPos = image.transform.localPosition;
        originColor = image.color;
    }

    public void Setup()
    {
        Pokemon = new Pokemon(_base, level);

        if (isPlayerUnit)
        {
            image.sprite = Pokemon.Base.BackSprite;
        }
        else
        {
            image.sprite = Pokemon.Base.FrontSprite;
        }

        GetComponent<Image>().SetNativeSize();
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
