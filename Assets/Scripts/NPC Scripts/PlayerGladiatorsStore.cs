using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGladiatorsStore : MonoBehaviour
{
    public int counterSamnites;
    public int counterThraex;
    public int counterMyrmilo;
    public int counterRetiarius;
    public bool hasPlayerInteractedBefore;
    public bool introQuestionsAnsweredBefore;
    public bool advancedQuestionsAnsweredBefore;

    private void Start()
    {
        counterSamnites = 0;
        counterThraex = 0;
        counterMyrmilo = 0;
        counterRetiarius = 0;
        hasPlayerInteractedBefore = false;
        introQuestionsAnsweredBefore = false; 
        advancedQuestionsAnsweredBefore = false;
    }
}
