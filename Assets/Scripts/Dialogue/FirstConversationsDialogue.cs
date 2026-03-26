using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstConversationsDialogue : MonoBehaviour
{

    public GameObject fadeTransition;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

    public bool skipped = false;

    public bool dialogueFinished = false;
    public string nextSceneName = "17-OutsideStorageRoom";

    public float typingSpeed = 0.03f;

    public GameObject characters;

    public bool louTalked;
    public bool archieTalked;
    public bool quintonTalked;
    public bool zekeTalked;
    public bool missEvelynTalked;


    public GameObject eloiseNeutral;
    public GameObject eloiseSuspicious;
    public GameObject eloiseUpset;
    public GameObject louNeutral;
    public GameObject louLookingOff;
    public GameObject louNervous;
    public GameObject archieNeutral;
    public GameObject archieSurprised;
    public GameObject quintonNeutral;
    public GameObject quintonShocked;
    public GameObject zekeNeutral;
    public GameObject zekeNervous;
    public GameObject missEvelynNeutral;
    public GameObject missEvelynStern;

    // first convo clues

    public ClueData clue4; 
    public ClueData clue5;
    public ClueData clue6; 
    public ClueData clue7; 
    public ClueData clue8;



    // Start is called before the first frame update
    void Start()
    {
        fadeTransition.SetActive(true);
        disableText();

        characters.SetActive(false);

        louTalked = false;
        archieTalked = false;
        quintonTalked = false;
        zekeTalked = false;
        missEvelynTalked = false;

        disableSprites();


        StartCoroutine(DialogueStart());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.name == "Lou")
                {
                    Debug.Log("You Clicked Lou");
                    StartCoroutine(louConversation());
                }
                else if (hit.collider.gameObject.name == "Archie")
                {
                    Debug.Log("You Clicked Archie");
                    StartCoroutine(archieConversation());
                }
                else if (hit.collider.gameObject.name == "Quinton")
                {
                    Debug.Log("You Clicked Quinton");
                    StartCoroutine(quintonConversation());
                }
                else if (hit.collider.gameObject.name == "Zeke")
                {
                    Debug.Log("You Clicked Zeke");
                    StartCoroutine(zekeConversation());
                }
                else if (hit.collider.gameObject.name == "MissEvelyn")
                {
                    Debug.Log("You Clicked Miss Evelyn");
                    StartCoroutine(missEvelynConversation());
                }
            }
        }
    }

    IEnumerator DialogueStart()
    {
        yield return new WaitForSeconds(2);
        fadeTransition.SetActive(false);
        yield return new WaitForSeconds(1);
        enableText();

        yield return StartCoroutine(currentDialogue("", "When Eloise enters back into the meeting room, everyone turned their heads towards the door."));
        yield return StartCoroutine(currentDialogue("", "It seemed like the meeting already started."));
        missEvelynNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "You're late."));
        eloiseUpset.SetActive(true);
        missEvelynNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Mei... Mei was murdered."));
        eloiseUpset.SetActive(false);
        yield return StartCoroutine(currentDialogue("", "The room froze."));
        yield return StartCoroutine(currentDialogue("", "A beat passes before the room explodes."));
        louNervous.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "Wait… like actually murdered?"));
        louNervous.SetActive(false);
        quintonShocked.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", "That’s not funny, Eloise."));
        quintonShocked.SetActive(false);
        archieSurprised.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", "This can’t be real…"));
        archieSurprised.SetActive(false);
        zekeNervous.SetActive(true);
        yield return StartCoroutine(currentDialogue("Zeke", "Are you serious?"));
        zekeNervous.SetActive(false);
        missEvelynStern.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "Everyone, quiet."));
        missEvelynStern.SetActive(false);
        yield return StartCoroutine(currentDialogue("", "The room went still once more."));
        missEvelynNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "I’ll call the authorities about the situation. Everyone will remain here while I do so."));
        missEvelynNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("", "Everyone nervously shifts where they are, not one of them wanting to break the tense silence."));
        yield return StartCoroutine(currentDialogue("", "Maybe this is a good time to talk to them one-on-one and get information."));

        StartCoroutine(continueStory());

        //***Load next scene after player talks to all characters***
    }

    IEnumerator continueStory()
    {
        disableText();

        characters.SetActive(true);


        yield return new WaitUntil(() => louTalked && archieTalked && quintonTalked && zekeTalked && missEvelynTalked);

        characters.SetActive(false);

        enableText();

        eloiseSuspicious.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "<i>Someone's lying. I don’t have enough information to go off of.</i>"));
        yield return StartCoroutine(currentDialogue("Eloise", "<i>I need to go to the storage room mentioned on Quinton's note. There has to be something there.</i>"));
        eloiseSuspicious.SetActive(false);
        dialogueFinished = true;
        yield return StartCoroutine(currentDialogue("", "Eloise sneaks out of the meeting room and heads straight to the storage room, hoping to find answers."));
    }

    IEnumerator currentDialogue(string name, string dialogue)
    {
        TMP_Text mainTMP = mainText.GetComponent<TMP_Text>();
        TMP_Text nameTMP = charName.GetComponent<TMP_Text>();

        nameTMP.text = name;
        mainTMP.text = "";

        skipped = false;

        for (int i = 0; i < dialogue.Length; i++)
        {
            if (skipped)
            {
                mainTMP.text = dialogue;
                break;
            }

            mainTMP.text += dialogue[i];
            yield return new WaitForSeconds(typingSpeed);
        }

        skipped = false;

        while (!skipped)
        {
            yield return null;
        }

        skipped = false;
        Debug.Log("Skipped dialogue");

        if (dialogueFinished)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    //Character Conversations

    public IEnumerator louConversation()
    {
        characters.SetActive(false);
        enableText();

        eloiseNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "What were you up to before the meeting?"));
        eloiseNeutral.SetActive(false);
        louNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "I was in the west corridor putting some stuff away in my locker."));
        eloiseSuspicious.SetActive(true);
        louNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "<i>Hm... That's close to where the bathroom is.</i>"));
        eloiseSuspicious.SetActive(false);
        louNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "Before you ask, I did see Mei. We briefly exchanged glances."));
        eloiseNeutral.SetActive(true);
        louNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "What did she look like?"));
        eloiseNeutral.SetActive(false);
        louNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "Focused. Determined, like she'd already made up her mind about something."));
        yield return StartCoroutine(currentDialogue("Lou", "She was holding some sort of agenda close to her chest, like she didn't want anyone to see it."));
        eloiseNeutral.SetActive(true);
        louNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Did she say anything to you?"));
        eloiseNeutral.SetActive(false);
        louLookingOff.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "No. She just walked past."));

        louLookingOff.SetActive(false);


        ClueManager.Instance.UnlockClue(clue5); // lou clue

        louTalked = true;



        characters.SetActive(true);
        disableText();

        Debug.Log("Finished Lou's conversation");
    }

    public IEnumerator archieConversation()
    {
        characters.SetActive(false);
        enableText();

        eloiseNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "Where were you before the meeting?"));
        eloiseNeutral.SetActive(false);
        archieNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", "East corridor by myself. I know how that looks."));
        yield return StartCoroutine(currentDialogue("Archie", "Doesn’t help that I lost track of time and came late."));
        eloiseNeutral.SetActive(true);
        archieNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "When did you last speak to Mei?"));
        eloiseNeutral.SetActive(false);
        archieNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", " Yesterday. I said some things I shouldn't have. I've been trying to clear my head ever since."));
        yield return StartCoroutine(currentDialogue("Archie", "I just… can’t believe this happened."));
        eloiseNeutral.SetActive(true);
        archieNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Yeah... me too."));

        eloiseNeutral.SetActive(false);

        ClueManager.Instance.UnlockClue(clue8); // unlocked archie clue

        archieTalked = true;


        characters.SetActive(true);
        disableText();

        Debug.Log("Finished Archie's conversation");
    }

    public IEnumerator quintonConversation()
    {
        characters.SetActive(false);
        enableText();

        eloiseSuspicious.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "Where were you before the meeting?"));
        eloiseSuspicious.SetActive(false);
        quintonShocked.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", "Wait, wait. Slow down!"));
        quintonShocked.SetActive(false);
        quintonNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", "I met her earlier this week."));
        yield return StartCoroutine(currentDialogue("Quinton", "But it was just to check some numbers on the council’s accounts. Something wasn’t adding up."));
        eloiseSuspicious.SetActive(true);
        quintonNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Oh come on, Quinton."));
        eloiseSuspicious.SetActive(false);
        quintonNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", "She started acting weird with me. I feel like she found something out that she shouldn’t have, and told me she wasn’t going to confront it herself. That’s all."));
        eloiseNeutral.SetActive(true);
        quintonNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Confront who?"));
        eloiseNeutral.SetActive(false);
        quintonNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", "She didn’t tell me."));


        quintonNeutral.SetActive(false);

        ClueManager.Instance.UnlockClue(clue7); // quinton clue

        quintonTalked = true;

        characters.SetActive(true);
        disableText();

        Debug.Log("Finished Quinton's conversation");
    }

    public IEnumerator zekeConversation()
    {
        characters.SetActive(false);
        enableText();

        eloiseNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "So you’re in charge of the funds aren't you?"));
        eloiseNeutral.SetActive(false);
        zekeNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Zeke", "Y-yes… I manage the approvals."));
        eloiseSuspicious.SetActive(true);
        zekeNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Seems like you were trying to cover your tracks."));
        eloiseSuspicious.SetActive(false);
        zekeNervous.SetActive(true);
        yield return StartCoroutine(currentDialogue("Zeke", "I… I didn’t mean to. I thought the notes were fine… I didn’t realize they were unusual."));
        eloiseSuspicious.SetActive(true);
        zekeNervous.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "<i>He’s not normally this nervous… Something is definitely up.</i>"));
        eloiseSuspicious.SetActive(false);

        ClueManager.Instance.UnlockClue(clue6); // unlocked archie clue

        zekeTalked = true;

        characters.SetActive(true);
        disableText();

        Debug.Log("Finished Zeke's conversation");
    }

    public IEnumerator missEvelynConversation()
    {
        characters.SetActive(false);
        enableText();

        missEvelynNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "What did you mean when you said Mei was murdered?"));
        eloiseUpset.SetActive(true);
        missEvelynNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "T-There was blood splattered everywhere and she wasn’t moving."));
        yield return StartCoroutine(currentDialogue("Eloise", "I saw bite marks on her neck… I think someone here did this to her. I think someone here is a vampire."));
        eloiseUpset.SetActive(false);
        missEvelynStern.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "A vampire? Don’t jump to dramatic conclusions, Eloise. This is serious."));
        eloiseSuspicious.SetActive(true);
        missEvelynStern.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "I am serious!"));
        eloiseSuspicious.SetActive(false);
        missEvelynStern.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "Vampires. The fictional creatures who sucks human blood, the ones that are afraid of garlic, the ones that burn from the sun and silver."));
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "You do know how ridiculous you sound, right?"));
        eloiseSuspicious.SetActive(true);
        missEvelynStern.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Whatever. Don’t believe me for all I care. I’ll figure out who did this on my own."));
        eloiseSuspicious.SetActive(false);
        missEvelynNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "Normally, I’d advise you to refrain from doing such a thing and wait for the authorities to arrive."));
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "However, something tells me you will do it anyways. Please do not be rash."));
        missEvelynNeutral.SetActive(false);

        ClueManager.Instance.UnlockClue(clue4); // unlocked archie clue

        missEvelynTalked = true;

        characters.SetActive(true);
        disableText();

        Debug.Log("Finished Miss Evelyn's conversation");
    }

    //Enable + Disable

    private void enableText()
    {
        textBox.SetActive(true);
        mainText.SetActive(true);
    }

    private void disableText()
    {
        textBox.SetActive(false);
        mainText.SetActive(false);
    }

    private void disableSprites()
    {
        eloiseNeutral.SetActive(false);
        eloiseSuspicious.SetActive(false);
        eloiseUpset.SetActive(false);
        louNeutral.SetActive(false);
        louLookingOff.SetActive(false);
        louNervous.SetActive(false);
        archieNeutral.SetActive(false);
        archieSurprised.SetActive(false);
        quintonNeutral.SetActive(false);
        quintonShocked.SetActive(false);
        zekeNeutral.SetActive(false);
        zekeNervous.SetActive(false);
        missEvelynNeutral.SetActive(false);
        missEvelynStern.SetActive(false);
    }
}
