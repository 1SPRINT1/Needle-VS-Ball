using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using UnityEngine.UI;

public class LoadAReset : MonoBehaviour
{
    public Text _VivodStage;
    public void Start()
    {
        _VivodStage.text = YandexGame.savesData.SceneScoreNice.ToString();
    }
}
