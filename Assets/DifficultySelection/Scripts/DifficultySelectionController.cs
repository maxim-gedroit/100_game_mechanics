using System;
using TMPro;
using UnityEngine;

public class DifficultySelectionController : MonoBehaviour
{
   public static event Action<int> OnDiff;
   [SerializeField] private TMP_Text _text;
   private int diff;
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.M))
      {
         diff++;
         
         if (diff == 11)
            diff = 10;
         
         SetLabel(diff);
         OnDiff?.Invoke(diff);
      }
      if (Input.GetKeyDown(KeyCode.L))
      {
         diff--;
         
         if (diff == 0)
            diff = 1;
         
         SetLabel(diff);
         OnDiff?.Invoke(diff);
      }
   }

   private void SetLabel(int i)
   {
      _text.text = $"Difficulty {i} | More - M | Less - L";
   }
}
