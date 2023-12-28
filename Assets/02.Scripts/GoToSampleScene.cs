using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSampleScene : MonoBehaviour
{
    public void LoadSampleScene()
    {
        // 씬 이름을 사용하여 씬 로드
        SceneManager.LoadScene("SampleScene"); 
    }
}

