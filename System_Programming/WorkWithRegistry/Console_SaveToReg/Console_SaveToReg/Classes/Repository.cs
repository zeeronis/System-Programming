using Microsoft.Win32;

namespace Console_SaveToReg.Classes
{
    public static class Repository
    {
        public static void SetValueToReg(string keyName, object value)
        {
            using (RegistryKey hkSoftware = Registry.CurrentUser.OpenSubKey("Software", true))
            {
                using (RegistryKey hkTest = hkSoftware.CreateSubKey("TestWriteToReg", true))
                {
                    hkTest.SetValue(keyName, value);
                }
            }
        }
        public static object GetKeyValueReg(string keyName)
        {
            object returnValue = null;
            using (RegistryKey hkSoftware = Registry.CurrentUser.OpenSubKey("Software", true))
            {
                using (RegistryKey hkTest = hkSoftware.OpenSubKey("TestWriteToReg", true))
                {
                    if (hkTest != null)
                    {
                        returnValue = hkTest.GetValue(keyName);
                    }
                }
            }
            return returnValue;
        }
    }
}
