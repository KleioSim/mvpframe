namespace KleioSim.MVPFrame.Samples
{
    public class HPDetailPresent : Present.Template<HPDetailView, UserDataModel>
    {
        protected override void Refresh()
        {
            view.hp1.text = model.userData.hp1.ToString();
            view.hp2.text = model.userData.hp2.ToString();
        }
    }
}
