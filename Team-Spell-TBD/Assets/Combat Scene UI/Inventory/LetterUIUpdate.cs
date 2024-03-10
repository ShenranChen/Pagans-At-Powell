using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LetterUIUpdate : MonoBehaviour
{
    public LettersSO playerLetterInv;
    public TextMeshProUGUI[] letterTexts; // Assign your UI Text elements for each letter here in the Inspector

    public void RefreshUI()
    {
        UpdateLetterUI();
    }

    void UpdateLetterUI()
    {
        letterTexts[0].text = playerLetterInv.A.ToString();
        letterTexts[1].text = playerLetterInv.B.ToString();
        letterTexts[2].text = playerLetterInv.C.ToString();
        letterTexts[3].text = playerLetterInv.D.ToString();
        letterTexts[4].text = playerLetterInv.E.ToString();
        letterTexts[5].text = playerLetterInv.F.ToString();
        letterTexts[6].text = playerLetterInv.G.ToString();
        letterTexts[7].text = playerLetterInv.H.ToString();
        letterTexts[8].text = playerLetterInv.I.ToString();
        letterTexts[9].text = playerLetterInv.J.ToString();
        letterTexts[10].text = playerLetterInv.K.ToString();
        letterTexts[11].text = playerLetterInv.L.ToString();
        letterTexts[12].text = playerLetterInv.M.ToString();
        letterTexts[13].text = playerLetterInv.N.ToString();
        letterTexts[14].text = playerLetterInv.O.ToString();
        letterTexts[15].text = playerLetterInv.P.ToString();
        letterTexts[16].text = playerLetterInv.Q.ToString();
        letterTexts[17].text = playerLetterInv.R.ToString();
        letterTexts[18].text = playerLetterInv.S.ToString();
        letterTexts[19].text = playerLetterInv.T.ToString();
        letterTexts[20].text = playerLetterInv.U.ToString();
        letterTexts[21].text = playerLetterInv.V.ToString();
        letterTexts[22].text = playerLetterInv.W.ToString();
        letterTexts[23].text = playerLetterInv.X.ToString();
        letterTexts[24].text = playerLetterInv.Y.ToString();
        letterTexts[25].text = playerLetterInv.Z.ToString();
    }
}