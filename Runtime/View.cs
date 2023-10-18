using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace KleioSim.MVPFrame
{
    public class View : MonoBehaviour
    {
        public static Dictionary<Type, Type> view2present;

        public static void SetAssembly(Assembly assembly)
        {
            //assembly.GetTypes().Where(x=>x.BaseType == typeof(PresentTemplate))
        }

        protected virtual void Awake()
        {
            var thisType = this.GetType();

            var present = this.gameObject.AddComponent(view2present[thisType]);

            view2present[thisType].GetProperty("view", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(present, this);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
