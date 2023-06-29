using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TopDownZenject
{    public interface ICharacterMove
    {
        Vector3 GetCurrentPosition();

        void MoveTo(Vector3 pos);
    }
}

