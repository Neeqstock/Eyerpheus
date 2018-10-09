using Eyerpheus;
using Eyerpheus.Controllers.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFeyerpheus.Controllers.External;
using XInput.Wrapper;

namespace WPFeyerpheus.Chests
{
    class ExternalControllersChest
    {
        #region Singleton
        private static ExternalControllersChest chest = new ExternalControllersChest();
        public static ExternalControllersChest getChest()
        {
            return chest;
        }
        #endregion

        private GamepadController gamepadController = new GamepadController();
        public GamepadController GamepadController
        {
            get
            {
                return gamepadController;
            }

            set
            {
                gamepadController = value;
            }
        }
    }
}
