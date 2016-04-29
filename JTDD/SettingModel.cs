using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTDD
{
    public class SettingModel
    {
        public SettingModel(){}
        private string name;
        private int type;
        private int field;
        private int grade;
        private int classnum;
        private string attclass;
        private int round;
        private int basescore;
        private List<RoundModel> rounddata = new List<RoundModel>();
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Field
        {
            get { return field; }
            set { field = value; }
        }
        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }
        public int ClassNum
        {
            get { return classnum; }
            set { classnum = value; }
        }
        public int Round
        {
            get { return round; }
            set { round = value; }
        }
        public string Attclass
        {
            get { return attclass; }
            set { attclass = value; }
        }
        public List<RoundModel> RoundData
        {
            get { return rounddata; }
            set { rounddata = value; }
        }
        public int BaseScore
        {
            get { return basescore; }
            set { basescore = value; }
        }
    }
}

