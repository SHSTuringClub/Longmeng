
using System;

namespace JTDD
{
    class UICore
    {
        public static string[] ans;
        public static int[] ans2;
        public static int[] classnum = new int[5];
        public static int[] SplitString(String str, int t)
        {
            int length = str.Length;
            //int RHand = 0;
            int q = 0;
            String strtq = str;
            ans = new String[5];
            ans2 = new int[5];
            int t2 = 0;
            while (strtq.Contains("|") == true)
            {
                t2 = strtq.IndexOf('|');
                String t3 = strtq.Substring(0, t2);
                ans[q] = t3;
                q++;
                strtq = strtq.Remove(0, t2 + 1);
            }
            if (strtq != "")
            {
                ans[q] = strtq;
            }
            for (int i = 0; i <= q; i++)
            {
                ans2[i] = Convert.ToInt32(ans[i]);
            }
            return ans2;
        }
        public static void InitSubTitle()
        {
            string st = "";
            st = Const.Comptype[CenterExchange.mainsetting.Type] + Const.CompGrade[CenterExchange.mainsetting.Grade] + Const.No + Const.RoundCode[CenterExchange.mainsetting.Field] +
                Const.RoundD;
            // Todo:Confirm Vaild
            CenterExchange.SubTitle = st;
            if (CenterExchange.FirstRun==true) {
                for (int i = 0; i < 5; i++)
                {
                    CenterExchange.ActData.ClassScore[i] = CenterExchange.mainsetting.BaseScore;
                }
                CenterExchange.FirstRun = false;
            }
            
            if (CenterExchange.mainsetting.Type == 1)
            {
                int q = 0;
                classnum = SplitString(CenterExchange.mainsetting.Attclass, 0);
                if(CenterExchange.mainsetting.Grade == 1)
                {
                    for(int j = 0; j < 5; j++)
                    {
                        CenterExchange.ActData.ClassLabel[j] = Const.Senior1C[classnum[j]];
                    }
                } else
                {
                    for (int j = 0; j < 5; j++)
                    {
                        CenterExchange.ActData.ClassLabel[j] = Const.Senior2C[classnum[j]];
                    }
                }
            }
        }
    }
}
