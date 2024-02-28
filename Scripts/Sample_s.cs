using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_s : MonoBehaviour
{
    [SerializeField] ConWinData_s test;
    int state;
    // Start is called before the first frame update
    void Start()
    {
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state++;
            if (state >= 5)
            {
                state = 0;
            }
        }
    }

    public void OnClicked()
    {
        ConfirmWindow_s.SetWindow("ConWinDatas/ConWinData" + state, () => Debug.Log("SampleEnd"));
    }
}
