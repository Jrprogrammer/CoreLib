﻿namespace CoreLib {
    public class GameManagers {

        public static Manager GetMainManager() {
            if (CoreLib.Manager == null) {
                CoreLib.Logger.LogError("Could not retrieve Manager instance, has it been instantiated yet?");
                throw new System.NullReferenceException();
            }
            return CoreLib.Manager;

        }

        public static TManager GetManager<TManager>() where TManager : ManagerBase {
            Manager mainManager = GetMainManager();
            foreach (var subManager in mainManager.allManagers) {
                if (subManager.GetType() == typeof(TManager)) {
                    return (TManager) subManager;
                }
            }

            CoreLib.Logger.LogError($"Could not retrieve manager of type {typeof(TManager).ToString()}");
            throw new System.Exception();
        }

    }
}
