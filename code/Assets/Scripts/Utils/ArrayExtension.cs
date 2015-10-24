using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class ArrayExtension {
    public static T GetRandomElement<T>(this T[] arr) {
        return arr[Random.Range(0, arr.Length)];
    }
    public static object GetRandomElement(this System.Array arr) {
        return arr.GetValue(Random.Range(0, arr.Length));
    }    
}

