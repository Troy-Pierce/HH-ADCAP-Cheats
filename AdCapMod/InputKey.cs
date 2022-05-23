using HHTools.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using AdCap;
using UniRx;

namespace AdCapMod
{
    class InputKey : MonoBehaviour
    {
        bool UnlimitedBooster = false;
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                this.repeatDelay = Time.time + 0.5f;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                UnlimitedBooster = !UnlimitedBooster;
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                GameController.Instance.TimeWarpService.ApplyTimeWarp((60 * 60)*24, false);
                //GameController.Instance.game.PlanetData
                //GameController.Instance.GlobalPlayerData.inventory.AddItem("time_warp_express", 2, false, false);
                //GameController.Instance.NavigationService.CreateModal<PopupModal>(NavModals.POPUP, false).WireData("Added Item", null, "", PopupModal.PopupOptions.OK, "Ok", "", true);
            }

            if (UnlimitedBooster)
            {
                if (GameController.Instance.game.PlanetData.hasBooster)
                {
                    ProfitBoosterView booster = MainUIController.instance.venturesPanel.profitBooster;
                    if (booster.Booster.Value.CurrentState.Value == ProfitBoosterState.Recharging)
                    {
                        booster.Booster.Value.CurrentDuration.Value = 0d ;
                        booster.Booster.Value.Deploy();
                    }else if(booster.Booster.Value.CurrentState.Value == ProfitBoosterState.Active)
                    {
                        if(booster.Booster.Value.CurrentTime.Value > (double)booster.Booster.Value.setup.fightBackEffect)
                        {
                            booster.Booster.Value.CurrentTime.Value = booster.Booster.Value.CurrentTime.Value - (double)booster.Booster.Value.setup.fightBackEffect;
                        }
                    }
                }
            }
        }
        private float repeatDelay;
    }
}
