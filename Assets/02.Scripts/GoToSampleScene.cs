using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSampleScene : MonoBehaviour
{
    public void LoadSampleScene()
    {
        // �� �̸��� ����Ͽ� �� �ε�
        SceneManager.LoadScene("SampleScene"); 
    }
}

