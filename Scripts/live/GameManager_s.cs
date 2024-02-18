using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_s : MonoBehaviour
{
    [SerializeField, TextArea(0, 6)] string[] ThemeStr;
    InputText_s InputText;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        InputText = GetComponent<InputText_s>();
        InputText.SetThemeText(ThemeStr[index]);
    }

    // Update is called once per frame
    void Update()
    {
        if (InputText.GetIsEnd())
        {
            index++;
            if (index >= ThemeStr.Length)
            {
                index = 0;
            }
            InputText.SetThemeText(ThemeStr[index]);
            InputText.SetIsEnd(false);
            return;
            
        }

        InputText.CheckCorrect();
    }
}
