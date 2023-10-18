using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KleioSim.MVPFrame.Samples
{
    public class UserDataView : View
    {
        public Text hpTotal;
        public Text mpTotal;

        public Button run;
    }

    class MyClass
    {
        //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        //static void OnBeforeSplashScreen()
        //{
        //    Debug.Log("Before SplashScreen is shown and before the first scene is loaded.");
        //}

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void OnBeforeSceneLoad()
        {
            View.view2present = new Dictionary<Type, Type>()
            {
                { typeof(UserDataView), typeof(UserDataPresent) },
                { typeof(HPDetailView), typeof(HPDetailPresent) },
                { typeof(MPDetailView), typeof(MPDetailPresent) }
            };
        }

        //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        //static void OnAfterSceneLoad()
        //{
        //    Debug.Log("First scene loaded: After Awake is called.");
        //}

        //[RuntimeInitializeOnLoadMethod]
        //static void OnRuntimeInitialized()
        //{
        //    View.view2present = new Dictionary<Type, Type>()
        //    {
        //        { typeof(HP), typeof(HP_Present) }
        //    };
        //}
    }
}
