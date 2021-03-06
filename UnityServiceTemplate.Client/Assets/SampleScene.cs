﻿using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Tonari.UnityServiceTemplate;

public class SampleScene : MonoBehaviour
{
    public Button GoodMorning;
    public Button GoodAfternoon;
    public Button GoodEvening;

    private void Start()
    {
        var client = new UnityServiceTemplateClient("localhost", 50051);
        client.AddTo(this);

        GoodMorning.OnClickAsObservable()
            .SelectMany(_ => client.SendRequestAsync(GoodMorning.GetComponentInChildren<Text>().text).ToObservable())
            .Subscribe()
            .AddTo(this);
        GoodAfternoon.OnClickAsObservable()
            .SelectMany(_ => client.SendRequestAsync(GoodAfternoon.GetComponentInChildren<Text>().text).ToObservable())
            .Subscribe()
            .AddTo(this);
        GoodEvening.OnClickAsObservable()
            .SelectMany(_ => client.SendRequestAsync(GoodEvening.GetComponentInChildren<Text>().text).ToObservable())
            .Subscribe()
            .AddTo(this);

        client.OnReceiveResponseAsObservable()
            .Subscribe(x => Debug.unityLogger.Log(x))
            .AddTo(this);
    }
}