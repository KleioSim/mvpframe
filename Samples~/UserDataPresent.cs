using System;
using UnityEngine;

namespace KleioSim.MVPFrame.Samples
{
    public class UserDataPresent : Present.Template<UserDataView, UserDataModel>
    {
        void Start()
        {
            model = UnityEngine.Object.FindObjectOfType<UserDataModel>();

            view.run.onClick.AddListener(() =>
            {
                model.userData.hp1 += 10;
                model.userData.hp2 += 10;

                model.userData.mp1++;
                model.userData.mp2++;

                this.isDirty = true;
            });
        }

        protected override void Refresh()
        {
            view.hpTotal.text = (model.userData.hp1 + model.userData.hp2).ToString();
            view.mpTotal.text = (model.userData.mp1 + model.userData.mp2).ToString();
        }
    }
}
