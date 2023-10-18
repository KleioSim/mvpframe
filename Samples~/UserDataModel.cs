using UnityEngine;

namespace KleioSim.MVPFrame.Samples
{
    public class UserDataModel : MonoBehaviour
    {
        public UserData userData;

        void Awake()
        {
            userData = new UserData();
        }
    }

    public class UserData
    {
        public int hp1 { get; set; }
        public int hp2 { get; set; }

        public int mp1 { get; set; }
        public int mp2 { get; set; }
    }
}
