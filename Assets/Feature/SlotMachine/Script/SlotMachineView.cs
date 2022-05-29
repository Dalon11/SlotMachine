using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace SlotMachine
{
    public class SlotMachineView : AbstractSlotMachineView
    {
        [Header("Поля текста.")]
        [SerializeField] private TextMeshProUGUI textPlayerMoney;
        [SerializeField] private TextMeshProUGUI textPlayerBet;
        [SerializeField] private TextMeshProUGUI textCheckLine;
        [SerializeField] private TextMeshProUGUI[] textPlayerWin;
        [Space]
        [SerializeField] private GameObject panelWin;
        [SerializeField] private GameObject panelGameOver;
        [SerializeField] private GameObject panelGameButton;
        [Space]
        [Header("Линии выигрыша.")]
        [SerializeField] private GameObject[] checkLines;

        private AbstractDataModel dataModel;
        private AbstractSlotMachineModel model;

        private void Start()
        {
            TextPlayerMoney(dataModel.PlayerMoney);
            TextPlayerBet(dataModel.PlayerBet);
            TextCheckLine(model.CountLine);
        }

        public void ButtonLine(int countLine) => model.CountLine += countLine;
        public void ButtonBet(int countBet) => dataModel.PlayerBet += countBet;
        public void ButtonMenu(int indexScene) => SceneManager.LoadScene(indexScene);

        private void TextPlayerMoney(int countMoney) => textPlayerMoney.text = countMoney.ToString();
        private void TextPlayerBet(int countBet) => textPlayerBet.text = countBet.ToString();
        private void TextPlayerWin(int countWin)
        {
            foreach (var text in textPlayerWin)
                text.text = countWin.ToString();
        }       
        private void TextCheckLine(int countLine) 
        {
            textCheckLine.text = countLine.ToString();
            SetCheckLines(countLine);
        } 

        private void SetCheckLines(int countLine)
        {
            foreach (var line in checkLines)
                line.SetActive(false);
            for (int i = 0; i < countLine; i++)
                checkLines[i].SetActive(true);
        }
        public override void WinView(int count)
        {
            panelWin.SetActive(true);
            panelGameButton.SetActive(false);
            TextPlayerWin(count);
        }
        public override void LoseView()
        {
            TextPlayerWin(0);
            Debug.Log(dataModel.IsGameOver);
            if (dataModel.IsGameOver)
                GameOver();
        }
        public void GameOver()
        {           
                panelGameOver.SetActive(true);
            panelGameButton.SetActive(false);
        }

        public override void Init(AbstractDataModel dataModel, AbstractSlotMachineModel model)
        {
            this.dataModel = dataModel;
            this.model = model;
            model.onChangeCountLine += TextCheckLine;
            dataModel.onChangePlayerMoneyText += TextPlayerMoney;
            dataModel.onChangePlayerBetText += TextPlayerBet;

        }
        private void OnDestroy()
        {
            model.onChangeCountLine -= TextCheckLine;
            dataModel.onChangePlayerMoneyText -= TextPlayerMoney;
            dataModel.onChangePlayerBetText -= TextPlayerBet;
        }

    }
}