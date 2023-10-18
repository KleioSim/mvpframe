namespace KleioSim.MVPFrame.Samples
{
    public class MPDetailPresent : Present.Template<MPDetailView, UserDataModel>
    {
        protected override void Refresh()
        {
            view.mp1.text = (model.userData.mp1).ToString();
            view.mp2.text = (model.userData.mp2).ToString();
        }
    }
}
