using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KleioSim.MVPFrame
{
    public abstract class Present : MonoBehaviour
    {
        public bool isDirty;

        private object model;
        private object view;

        protected abstract void Refresh();

        protected virtual void OnEnable()
        {
            isDirty = true;
        }

        protected virtual void Update()
        {
            if (!isDirty)
            {
                return;
            }

            var parent = GetParentPresent(this.transform);
            if (parent != null && parent.isDirty)
            {
                return;
            }

            UpdateForce();
        }

        void UpdateForce()
        {
            Refresh();
            isDirty = false;

            foreach (var child in IteratorChildren(this.transform))
            {
                child.model = model;
                child.UpdateForce();
            }
        }

        private Present GetParentPresent(Transform transform)
        {
            if(transform.parent == null)
            {
                return null;
            }

            var present = transform.parent.GetComponent<Present>();
            if(present != null)
            {
                return present;
            }

            return GetParentPresent(transform.parent);
        }

        private IEnumerable<Present> IteratorChildren(Transform transform)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                if (!child.gameObject.activeInHierarchy)
                {
                    continue;
                }

                Debug.Log($"IteratorChildren {child} {i}");
                var childUIView = child.GetComponent<Present>();
                if (childUIView != null)
                {
                    yield return childUIView;
                }
                else
                {
                    foreach (var nextUIView in IteratorChildren(child))
                    {
                        yield return nextUIView;
                    }
                }
            }
        }

        public abstract class Template<TVIew, TModel> : Present
            where TVIew:class 
            where TModel:class
        {
            protected new TVIew view { get => base.view as TVIew; set => base.view = value; }
            protected new TModel model { get => base.model as TModel; set => base.model = value; }
        }
    }

}