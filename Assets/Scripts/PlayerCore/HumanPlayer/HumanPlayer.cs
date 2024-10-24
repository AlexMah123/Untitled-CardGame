using GameCore;
using GameCore.SaveSystem.Data;
using LevelCore.LevelManager;
using PlayerCore.Upgrades.UpgradeFactory;

namespace PlayerCore.HumanPlayer
{
    public class HumanPlayer : Player
    {
        public override void LoadComponents()
        {
            base.LoadComponents();
            
            ActiveLoadoutComponent.InitializeComponent(this, GameManager.Instance.AIPlayer, currentStats);
        }

        #region SaveSystem Override
        protected override void LoadPlayerData(GameData data)
        {
            //load from LevelDataManager
            var humanPlayerData = LevelDataManager.Instance.currentSelectedLevelSO.humanFPlayer;

            baseStatsConfig = humanPlayerData.baseStatsConfig;
        
            //load stats upgrade from save file
            upgradeStats = new PlayerStats
            {
                health = data.upgradedPlayerStats.health,
                damage = data.upgradedPlayerStats.damage,
                cardSlots = data.upgradedPlayerStats.cardSlots,
                energy = data.upgradedPlayerStats.energy
            };

            //load cardUpgrades from save file
            foreach (UpgradeType upgradeType in data.playerEquippedUpgrades)
            {
                ActiveLoadoutComponent.AddUpgradeToLoadout(upgradeType);
            }
        }
        #endregion

    }
}
