using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] Image heart1;
    [SerializeField] Image heart2;
    [SerializeField] Image heart3;

    [SerializeField] Sprite heartFull;
    [SerializeField] Sprite heartEmpty;
    [SerializeField] Sprite heartHalf;
    [SerializeField] Image _fadeScreen;
    [SerializeField] float fadeSpeed;

    [SerializeField] Text gemText;

    public bool isturningBlack, isturningfromBlack;

    
    // Start is called before the first frame update
    void Start()
    {
        gemUpdate();
        isturningfromBlack= true;
    }
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        FadeScreen();
    }

    private void FadeScreen()
    {
        if (isturningBlack)
        {
            _fadeScreen.color = new Color(_fadeScreen.color.r, _fadeScreen.color.g, _fadeScreen.color.b, Mathf.MoveTowards(_fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (_fadeScreen.color.a == 1f)
            {
                isturningBlack = false;
            }
        }

        if (isturningfromBlack)
        {
            _fadeScreen.color = new Color(_fadeScreen.color.r, _fadeScreen.color.g, _fadeScreen.color.b, Mathf.MoveTowards(_fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (_fadeScreen.color.a == 0f)
            {
                isturningfromBlack = false;
            }
        }
    }

    public void heartcountDisplay()
    {
        switch (HealthSystem.instance.currentHealth)
        {
            case 6:

                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                break;


            case 5:

                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                break;


            case 4:

                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                break;


            case 3:

                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;
                break;


            case 2:

                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;


            case 1:

                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;


            case 0:

                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;


            default:

                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
        }

        

    }
    public void gemUpdate()
    {
        gemText.text =LevelManager.instance.gemsCollected.ToString();
    }

    public void fadeScreen()
    {
        isturningBlack = true;
        isturningfromBlack = false;
    }

    public void unfadeScrren()
    {
        isturningfromBlack = true;
        isturningBlack = false;
    }
}
