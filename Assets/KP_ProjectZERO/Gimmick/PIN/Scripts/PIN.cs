using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PIN : MonoBehaviour {
   public Sprite[] numbers;

   public Image[] images;

   private int[] nows = {0, 0, 0, 0};

   public void CangeNumber(int n) {
       nows[n] += 1;

       if(nows[n] >= numbers.Length) {
           nows[n] = 0;
       }

       images[n].sprite = numbers[nows[n]];
   }
}