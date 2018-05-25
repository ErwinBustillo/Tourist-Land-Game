using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Quest
{
    Null,
    BigBen,
    MrBlack,
    PhoneBox,
    EiffelMan,
    Chaman
}

public class QuestManager : MonoBehaviour {

    public static QuestManager Instance { get; private set; }

    [SerializeField]
    Quest[] quests;

    

    Dictionary<Quest, bool> questStates = new Dictionary<Quest, bool>();

    public void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        questStates.Add(Quest.Null, true);
        foreach (Quest quest in quests)
        {
            questStates.Add(quest, false);
        }
    }

    public void CompleteTask(Quest quest)
    {
        questStates[quest] = true;
    }

    public bool CheckQuestState(Quest quest)
    {
        return questStates[quest];
    }
}
