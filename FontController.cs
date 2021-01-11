using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FontController : MonoBehaviour
{

    #region TEXT MESH PRO COMPS

    //public TextMeshProUGUI requiredWordText;            //Required Word Text Component
    //public TextMeshProUGUI playerInputWordText;         //Player Input Text Component

    public List<TextMeshProUGUI> fontsToChange;


    #endregion

    #region Font Assets

    public TMP_FontAsset typewritingFont;   //Typewriting Font
    public TMP_FontAsset calibri;           //Calibri Font
    public TMP_FontAsset comicSans;         //Comic Sans Font  
    public TMP_FontAsset verdana;           //Verdana Font
    public TMP_FontAsset tahoma;            //Tahoma Font
    public TMP_FontAsset centuryGothic;     //Century Gothic Font
    public TMP_FontAsset trebuchet;         //Trebuchet Font

    private TMP_FontAsset newFont;          //New Font To Update to

    PlayerPrefs.Fonts fonts = PlayerPrefs.GameFont;        //Current Font Selected

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        UpdateFont();
    }

    void UpdateFont()
    {
        switch (fonts)
        {
            case PlayerPrefs.Fonts.TypewritingFont:
                newFont = typewritingFont;
                break;
            case PlayerPrefs.Fonts.Calibri:
                newFont = calibri;
                break;
            case PlayerPrefs.Fonts.ComicSans:
                newFont = comicSans;
                break;
            case PlayerPrefs.Fonts.Verdana:
                newFont = verdana;
                break;
            case PlayerPrefs.Fonts.Tahoma:
                newFont = tahoma;
                break;
            case PlayerPrefs.Fonts.CenturyGothic:
                newFont = centuryGothic;
                break;
            case PlayerPrefs.Fonts.Trebuchet:
                newFont = trebuchet;
                break;
            default:
                newFont = typewritingFont;
                break;
        }

        for(int i = 0; i < fontsToChange.Count; i++)
        {
            fontsToChange[i].font = newFont;
        }


    }


}
