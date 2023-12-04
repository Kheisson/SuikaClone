using UnityEngine;
namespace Services
{
    public static class LoggerService
    {
        #region --- Public Methods ---
        
        public static void Log(string message, params object[] args)
        {
            Debug.Log(FormatMessage(message, "green", args));
        }

        public static void LogError(string message, params object[] args)
        {
            Debug.LogError(FormatMessage(message, "red", args));
        }

        public static void LogWarning(string message, params object[] args)
        {
            Debug.LogWarning(FormatMessage(message, "yellow", args));
        }

        public static void LogCustom(string message, string color, params object[] args)
        {
            Debug.Log(FormatMessage(message, color, args));
        }

        public static void LogObject(string message, UnityEngine.Object context)
        {
            Debug.Log(FormatMessage(message, "green"), context);
        }
        
        #endregion
        
        
        #region --- Private Methods ---

        private static string FormatMessage(string message, string color, params object[] args)
        {
            return $"<color={color}>{string.Format(message, args)}</color>";
        }
        
        #endregion
    }
}