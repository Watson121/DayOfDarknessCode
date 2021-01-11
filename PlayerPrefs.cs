using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefs
{

    public enum Fonts { 
        TypewritingFont,
        Calibri,
        ComicSans,
        Verdana,
        Tahoma,
        CenturyGothic,
        Trebuchet
    };

    private static bool uppercase = true;
    private static bool spaces = true;
    private static bool specialCharacters = true;
    private static Fonts gameFont= Fonts.TypewritingFont;

    public static bool Uppercase {

        //Allowing uppercase or not

        get
        {
            return uppercase;
        }

        set
        {
            uppercase = value;
        }
    }

    public static bool Spaces
    {

        //Allowing spaces or not

        get
        {
            return spaces;
        }
        set
        {
            spaces = value;
        }
    }

    public static bool SpecialCharacters
    {
        //Allowing special characters or not

        get
        {
            return specialCharacters;
        }

        set
        {
            specialCharacters = value;
        }
    }

    public static Fonts GameFont
    {
        //Changing fonts

        get
        {
            return gameFont;
        }

        set
        {
            gameFont = value;
        }
    
    }



}
