using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
using HHTools.Navigation;

namespace AdCapMod
{
    public class Program
    {
        public Program()
        {
            GameObject _keyInput = new GameObject();
            _keyInput.AddComponent<InputKey>();
            GameObject.DontDestroyOnLoad(_keyInput);
            GameController.Instance.NavigationService.CreateModal<PopupModal>(NavModals.POPUP, false).WireData("Mods Loaded", null, "", PopupModal.PopupOptions.OK, "ok", "", true);
        }

    }
}
