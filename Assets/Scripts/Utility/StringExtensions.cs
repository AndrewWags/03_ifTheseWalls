using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class StringExtensions
{
    public static string Timestamped(this string str)
    {
        return System.DateTime.Now.ToString() + " : " + str;
    }
            
}

