using System.Collections;
using UnityEngine;

namespace YarLiong.Controller
{
    public abstract class AbstractSceneController : MonoBehaviour, IController
    {
        void Awake()
        {
            MainGameLogic.Instance.RegisterSceneController(this);
        }

        public virtual IEnumerator Init()
        {
            yield return null;
        }
    }
}