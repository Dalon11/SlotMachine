using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SlotMachine
{
    public class SlotMachineView : AbstractSlotMachineView
    {
        private AbstractDataModel dataModel;

        [SerializeField] private Text textPlayerMoney;
        [SerializeField] private Text textPlayerBet;
        [SerializeField] private Text textPlayerWin;

        private void Start()
        {
            TextPlayerMoney(dataModel.PlayerMoney);
            TextPlayerBet(dataModel.PlayerBet);
        }
        public void ButtonBet(int count)=> dataModel.PlayerBet += count;
        public void ButtonMenu(int indexScene) => SceneManager.LoadScene(indexScene);

        private void TextPlayerMoney(int count) => textPlayerMoney.text = count.ToString();
        private void TextPlayerBet(int count) => textPlayerBet.text = count.ToString();
        private void TextPlayerWin(int count) => textPlayerWin.text = count.ToString();

        public override void WinView(int count)=>TextPlayerWin(count);        
        public override void LoseView()=> TextPlayerWin(0);

        public override void Init(AbstractDataModel dataModel)
        {
            this.dataModel = dataModel;
            dataModel.onChangePlayerMoneyText += TextPlayerMoney;
            dataModel.onChangePlayerBetText += TextPlayerBet;
        }
        private void OnDestroy()
        {
            dataModel.onChangePlayerMoneyText -= TextPlayerMoney;
            dataModel.onChangePlayerBetText -= TextPlayerBet;
        }

    }
}