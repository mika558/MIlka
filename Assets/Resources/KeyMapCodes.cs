using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class KeyMapCodes : MonoBehaviour
{
    public Dictionary<string, KeyCode> keyMapCodes = new Dictionary<string, KeyCode>()
    {
        {"slimecatRight", KeyCode.L },
        {"slimecatLeft", KeyCode.J },
        {"slimecatJump", KeyCode.I },
        {"slimecatInteractOne", KeyCode.O },
        {"slimecatInteractTwo", KeyCode.U },

        {"golemRight", KeyCode.D },
        {"golemLeft", KeyCode.A },
        {"golemJump", KeyCode.W },
        {"golemInteractOne", KeyCode.E },
        {"golemInteractTwo", KeyCode.Q }
    };
}
