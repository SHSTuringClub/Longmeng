using System;

namespace JTDD
{
    public class RoundModel
    {
        public RoundModel() { }
        private int code;
        public int Code
        {
            set { code = value; }
            get { return code; }
        }
        private string name;
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        private string note;
        public string Note
        {
            set { note = value; }
            get { return note; }
        }
        private int timeelapse;
        public int TimeElapse
        {
            set { timeelapse = value; }
            get { return timeelapse; }
        }
        private int type;
        public int Type
        {
            set { type = value; }
            get { return type; }
        }
        private Boolean typegroup;
        public Boolean TypeGroup
        {
            set { typegroup = value; }
            get { return typegroup; }
        }
        private string[] groupname;
        public string[] GroupName
        {
            set { groupname = value; }
            get { return groupname; }
        }
        private int groupnum;
        public int GroupNum
        {
            set { groupnum = value; }
            get { return groupnum; }
        }
        private int[] groupscoreR;
        public int[] GroupScoreR
        {
            set { groupscoreR = value; }
            get { return groupscoreR; }
        }
        private int[] groupscoreW;
        public int[] GroupScoreW
        {
            set { groupscoreW = value; }
            get { return groupscoreW; }
        }
        private int scoreR;
        public int ScoreR
        {
            set { scoreR = value; }
            get { return scoreR; }
        }
        private int scoreW;
        public int ScoreW
        {
            set { scoreW = value; }
            get { return scoreW; }
        }
    }
}
