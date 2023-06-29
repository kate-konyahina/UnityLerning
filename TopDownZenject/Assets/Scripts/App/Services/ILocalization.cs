using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownZenject
{
    public interface ILocalization 
    {
        string Translate(string key, params object[] args);
    }
}
