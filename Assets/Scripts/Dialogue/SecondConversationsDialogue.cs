using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondConversationsDialogue : MonoBehaviour
{
    public GameObject fadeInTransition;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

    public bool skipped = false;

    public bool dialogueFinished = false;
    public string nextSceneName = "23-GuessTheVampire";

    public float typingSpeed = 0.03f;

    public GameObject characters;

    public bool louTalked;
    public bool archieTalked;
    public bool quintonTalked;
    public bool zekeTalked;
    public bool missEvelynTalked;

    public GameObject eloiseNeutral;
    public GameObject eloiseSuspicious;
    public GameObject louNeutral;
    public GameObject louLookingOff;
    public GameObject louNervous;
    public GameObject archieNeutral;
    public GameObject archieSurprised;
    public GameObject archieDarken;
    public GameObject quintonNeutral;
    public GameObject quintonShocked;
    public GameObject zekeNeutral;
    public GameObject zekeNervous;
    public GameObject missEvelyn;

    // second convo clues

    public ClueData clue10;
    public ClueData clue11;
    public ClueData clue12;
    public ClueData clue13;
    public ClueData clue14;


    // Start is called before the first frame update
    void Start()
    {
        fadeInTransition.SetActive(true);
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
        if (ClueManager.Instance != null && ClueManager.Instance.IsInventoryOpen)
            return;

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
        fadeInTransition.SetActive(false);
        yield return new WaitForSeconds(1);
        enableText();

        yield return StartCoroutine(currentDialogue("", "Eloise sneaks her way back into the meeting room. Everyone was still hanging around in the same spot they were at previously."));
        yield return StartCoroutine(currentDialogue("", "They were on edge, the thick air still hung as people took nervous glances at each other."));
        yield return StartCoroutine(currentDialogue("", "This is a good chance to question everyone once more as they continue to isolate from each other."));

        StartCoroutine(continueStory());
    }

    IEnumerator continueStory()
    {
        disableText();

        characters.SetActive(true);


        yield return new WaitUntil(() => louTalked && archieTalked && quintonTalked && zekeTalked && missEvelynTalked);

        characters.SetActive(false);

        enableText();

        eloiseSuspicious.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "<i>The missing funds… the blood packets… the lies… Mei uncovered something before she died.</i>"));
        yield return StartCoroutine(currentDialogue("Eloise", "<i>One of you is hiding the truth.</i>"));
        dialogueFinished = true;
        yield return StartCoroutine(currentDialogue("", "<i>And I think I finally know who the vampire is.</i>"));
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

        yield return StartCoroutine(currentDialogue("", "Lou was absentmindedly fidgeting with her left hand."));
        eloiseNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "Did something happen with your hand?"));
        eloiseNeutral.SetActive(false);
        louNervous.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "Oh."));
        louNervous.SetActive(false);
        yield return StartCoroutine(currentDialogue("", "Eloise notices a nasty mark on her palm before Lou quickly pulls down her sleeve."));
        louLookingOff.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "It’s nothing too serious. I just hurt my wrist while playing basketball the other day."));
        louNeutral.SetActive(true);
        louLookingOff.SetActive(false);
        yield return StartCoroutine(currentDialogue("Lou", "So what did you want to talk about?"));
        eloiseNeutral.SetActive(true);
        louNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "You said you saw Mei earlier, right?"));
        eloiseNeutral.SetActive(false);
        louNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "This again? We exchanged glances and nothing more."));
        eloiseNeutral.SetActive(true);
        louNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Are you sure there was nothing else? No one else you saw?"));
        eloiseNeutral.SetActive(false);
        louNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "Now that you mention it, I did see Archie walk past me at some point. I don’t think he even noticed me."));
        yield return StartCoroutine(currentDialogue("Lou", "I thought he was desperate to go confess his love to Mei or something alone since he was in such a hurry. But maybe I was wrong…"));
        eloiseNeutral.SetActive(true);
        louNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "<i>Odd to bring up Archie suddenly, but I’ll keep that in mind.</i>"));

        ClueManager.Instance.UnlockClue(clue11); // lou clue

        eloiseNeutral.SetActive(false);
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
        yield return StartCoroutine(currentDialogue("Eloise", "I found this love letter you wrote to Mei."));
        eloiseNeutral.SetActive(false);
        archieSurprised.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", "W-where did you get that?"));
        eloiseSuspicious.SetActive(true);
        archieSurprised.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "It was in the storage room, care to explain why it was there?"));
        eloiseSuspicious.SetActive(false);
        archieDarken.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", "I… I don’t know."));
        eloiseNeutral.SetActive(true);
        archieDarken.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "You seemed angry with her."));
        eloiseNeutral.SetActive(false);
        archieDarken.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", "I saw her with Quinton sometime last week. I got upset and I said things I didn’t mean. But I never hurt her I swear!"));
        yield return StartCoroutine(currentDialogue("Archie", "It was probably Quinton who killed her anyway…"));
        eloiseNeutral.SetActive(true);
        archieDarken.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Does anyone else know about the letter or your crush on Mei?"));
        eloiseNeutral.SetActive(false);
        archieNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", "Not that I know of. I never told anyone."));
        archieNeutral.SetActive(false);
        archieDarken.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", "Can we just move on from this? I really don’t want to talk about it right now."));
        eloiseSuspicious.SetActive(true);
        archieDarken.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "<i>He was quick to shut that conversation down…</i>"));

        ClueManager.Instance.UnlockClue(clue13); // archie clue

        eloiseSuspicious.SetActive(false);
        archieTalked = true;

        characters.SetActive(true);
        disableText();

        Debug.Log("Finished Archie's conversation");
    }

    public IEnumerator quintonConversation()
    {
        characters.SetActive(false);
        enableText();

        quintonNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", "Hey Eloise, need something again?"));
        eloiseNeutral.SetActive(true);
        quintonNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "I took a look at the storage room and found these records and a letter."));
        eloiseNeutral.SetActive(false);
        quintonNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", "The missing transfer records? Why would they be in the storage room? I was sure Mei had them in her agenda earlier."));
        yield return StartCoroutine(currentDialogue("Quinton", "And this letter… Is that a love letter to Mei from Archie? For a love letter he seemed pretty angry—"));
        quintonNeutral.SetActive(false);
        quintonShocked.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", "Wait, why am I mentioned in here? Is that why he was giving me a weird look earlier?"));
        eloiseNeutral.SetActive(true);
        quintonShocked.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "What do you mean?"));
        eloiseNeutral.SetActive(false);
        quintonNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", "Before the meeting, Miss Evelyn told me to go fetch something in another classroom and I quickly passed by Archie in the east corridor."));
        yield return StartCoroutine(currentDialogue("Quinton", "He looked at me like I wronged him in some way but I just ignored it."));
        eloiseSuspicious.SetActive(true);
        quintonNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "<i>Archie never mentioned seeing him in the hall before… strange.</i>"));
        eloiseSuspicious.SetActive(false);

        ClueManager.Instance.UnlockClue(clue12); // quinton clue

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
        yield return StartCoroutine(currentDialogue("Eloise", "Hey, look at this."));
        eloiseNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("", "Eloise slides the records from the storage room in front of Zeke."));
        zekeNervous.SetActive(true);
        yield return StartCoroutine(currentDialogue("Zeke", "Ah… These are…"));
        eloiseSuspicious.SetActive(true);
        zekeNervous.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "I find it hard to believe something like this would go unnoticed, especially by someone like you."));
        eloiseSuspicious.SetActive(false);
        zekeNervous.SetActive(true);
        yield return StartCoroutine(currentDialogue("Zeke", "I-I…"));
        eloiseSuspicious.SetActive(true);
        zekeNervous.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Spill."));
        eloiseSuspicious.SetActive(false);
        zekeNervous.SetActive(true);
        yield return StartCoroutine(currentDialogue("Zeke", "A-alright I’ll admit it… I told Mei about the transfers a few weeks ago."));
        zekeNervous.SetActive(false);
        zekeNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Zeke", "I’ve been busy as of late so I couldn’t investigate this on my own, so I asked for her help."));
        yield return StartCoroutine(currentDialogue("Zeke", "I followed up with her earlier today and she said she was going to settle it tonight… whatever that meant."));
        eloiseSuspicious.SetActive(true);
        zekeNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Why didn’t you say anything before?"));
        eloiseSuspicious.SetActive(false);
        zekeNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Zeke", "I was one of the last people to talk to her. I… I was scared people were going to think that I did it."));
        eloiseSuspicious.SetActive(true);
        zekeNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "<i>As if hiding this wouldn’t make you even more suspious…</i>"));
        eloiseSuspicious.SetActive(false);
        zekeNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Zeke", "I-If anything, Archie was probably the one who murdered Mei. Weirdly enough, he’s been hovering around her recently so I bet he has something to do with it."));
        zekeNeutral.SetActive(false);

        ClueManager.Instance.UnlockClue(clue14); // zeke clue

        zekeTalked = true;

        characters.SetActive(true);
        disableText();

        Debug.Log("Finished Zeke's conversation");
    }

    public IEnumerator missEvelynConversation()
    {
        characters.SetActive(false);
        enableText();

        eloiseNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "…"));
        eloiseNeutral.SetActive(false);
        missEvelyn.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "…"));
        missEvelyn.SetActive(false);
        eloiseNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "I wanted to ask… was everyone here before the meeting started?"));
        eloiseNeutral.SetActive(false);
        missEvelyn.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "Mostly. Lou and Archie were a little late."));
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "However, I asked Quinton to get me something from another classroom. He came in later after everyone settled in."));
        missEvelyn.SetActive(false);
        eloiseNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "Did you know about the missing funds?"));
        eloiseNeutral.SetActive(false);
        missEvelyn.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "No… Zeke's in charge of approving the funds."));
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "He's been distracted lately though, less on top of things than usual. I've had to remind him about deadlines twice this month alone."));
        eloiseNeutral.SetActive(true);
        missEvelyn.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Did anyone have a reason to keep Mei quiet?"));
        eloiseNeutral.SetActive(false);
        missEvelyn.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "Mei had been asking questions about the council accounts for weeks. Sharp girl. Whatever she found, she kept it to herself."));
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "Quinton had been spending a lot of time with her lately too. Checking numbers, he said. I didn't think much of it at the time."));
        eloiseSuspicious.SetActive(true);
        missEvelyn.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "<i>Oh, I’m sure you didn’t…</i>"));
        eloiseSuspicious.SetActive(false);

        ClueManager.Instance.UnlockClue(clue10); // miss evelyn clue

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
        louNeutral.SetActive(false);
        louLookingOff.SetActive(false);
        louNervous.SetActive(false);
        archieNeutral.SetActive(false);
        archieSurprised.SetActive(false);
        archieDarken.SetActive(false);
        quintonNeutral.SetActive(false);
        quintonShocked.SetActive(false);
        zekeNeutral.SetActive(false);
        zekeNervous.SetActive(false);
        missEvelyn.SetActive(false);
    }
}