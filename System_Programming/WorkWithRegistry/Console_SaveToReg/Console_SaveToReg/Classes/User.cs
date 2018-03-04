using System;

namespace Console_SaveToReg.Classes
{
    public struct User
    {
        private string Name_;
        public string Name
        {
            get { return Name_; }
            set
            {
                Name_ = value;
                Repository.SetValueToReg(Enum.GetName(typeof(userTypes), userTypes.Name), value);
            }
        }

        public string Surname_;
        public string Surname
        {
            get { return Surname_; }
            set
            {
                Surname_ = value;
                Repository.SetValueToReg(Enum.GetName(typeof(userTypes), userTypes.Surname), value);
            }
        }

        public string Patronymic_;
        public string Patronymic
        {
            get { return Patronymic_; }
            set
            { Patronymic_ = value;
                Repository.SetValueToReg(Enum.GetName(typeof(userTypes), userTypes.Patronymic), value);
            }
        }

        public UserGender Gender_;
        public UserGender Gender
        {
            get { return Gender_; }
            set
            {
                Gender_ = value;
                Repository.SetValueToReg(Enum.GetName(typeof(userTypes), userTypes.Gender), (int)value);
            }
        }

        public ConsoleColor ForegroundColor_;
        public ConsoleColor ForegroundColor
        {
            get { return ForegroundColor_; }
            set
            { ForegroundColor_ = value;
                Repository.SetValueToReg(Enum.GetName(typeof(userTypes), userTypes.ForegroundColor), (int)value);
            }
        }

        public ConsoleColor BackgroundColor_;
        public ConsoleColor BackgroundColor
        {
            get { return BackgroundColor_; }
            set
            {
                BackgroundColor_ = value;
                Repository.SetValueToReg(Enum.GetName(typeof(userTypes), userTypes.BackgroundColor), (int)value);
            }
        }


        public void LoadDataFromReg()
        {
            object value;
            if ((value = Repository.GetKeyValueReg(GetStringOfuserType(userTypes.Name))) != null)
            {
                Name = (string)value;
            }

            if ((value = Repository.GetKeyValueReg(GetStringOfuserType(userTypes.Surname))) != null)
            {
                Surname = (string)value;
            }
            if ((value = Repository.GetKeyValueReg(GetStringOfuserType(userTypes.Patronymic))) != null)

            {
                Patronymic = (string)value;
            }

            if ((value = Repository.GetKeyValueReg(GetStringOfuserType(userTypes.Gender))) != null)
            {
                Gender = (UserGender)value;
            }
            else
            {
                Gender = UserGender.None;
            }

            if ((value = Repository.GetKeyValueReg(GetStringOfuserType(userTypes.ForegroundColor))) != null)
            {
                ForegroundColor = (ConsoleColor)value;
            }
            else
            {
                ForegroundColor = Console.ForegroundColor;
            }

            if ((value = Repository.GetKeyValueReg(GetStringOfuserType(userTypes.BackgroundColor))) != null)
            {
                BackgroundColor = (ConsoleColor)value;
            }
            else
            {
                BackgroundColor = Console.BackgroundColor;
            }

        }

        private string GetStringOfuserType(userTypes type)
        {
            return Enum.GetName(typeof(userTypes), type);
        }
    }
    public enum userTypes
    {
        Name,
        Surname,
        Patronymic,
        Gender,
        ForegroundColor,
        BackgroundColor
    }

    public enum UserGender
    {
        None = 0,
        Male = 1,
        Female = 2
    }
}
