using System;
using System.Collections.Generic;

namespace JTDD
{
    class CenterExchange
    {
        public static SettingModel mainsetting = new SettingModel();
        public static string SettingLoadingReal = "";
        public static string SubTitle = "";
        public static String[,] Competition = new String[10, 2];
        public static String[,] TypeD = new String[20, 2];
        public static List<ExerciseModel> mainExer = new List<ExerciseModel>();
        public static int totExer = 0;
        public static int OutputMode = 0;
        public static int Real_Round = 0;
        public static int CloseFlag = 0;
        public static int ClassCur = 0;
        public static int ExerCur = -1;
        public static int NoUse = 0;
        public static int CountDownStandard = 0;
        public static int CountDownReal = 0;
        public static int ScoreR = 0;
        public static int ScoreW = 0;
        public static Boolean FirstRun = true;
        public static string HalfStem = "";
        public static int ClassCurR3 = 0;
        public static int ClassCurR4 = 0;
        public static Boolean Final = false;
        public class ActData
        {
            public static int[] panelColor = new int[5];
            public static String[] ClassLabel = new String[5];
            public static int[] ClassScore = new int[5];
        }
    }    
}
