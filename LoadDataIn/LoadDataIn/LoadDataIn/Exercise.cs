using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDataIn
{
    public class Exercise
    {
        public Exercise() { }
        private string id;
        private string stem;
        private string key;
        private string typed;
        private string choiceA;
        private string choiceB;
        private string choiceC;
        private string choiceD;
        private string stdType;
        private string scoreR;
        private string scoreW;
        private Boolean avail;
        public string ScoreR
        {
            get { return scoreR; }
            set { scoreR = value; }
        }
        public string ScoreW
        {
            get { return scoreW; }
            set { scoreW = value; }
        }
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Stem
        {
            get { return stem; }
            set { stem = value; }
        }
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        public string Typed
        {
            get { return typed; }
            set { typed = value; }
        }
        public string ChoiceA
        {
            get { return choiceA; }
            set { choiceA = value; }
        }
        public string ChoiceB
        {
            get { return choiceB; }
            set { choiceB = value; }
        }
        public string ChoiceC
        {
            get { return choiceC; }
            set { choiceC = value; }
        }
        public string ChoiceD
        {
            get { return choiceD; }
            set { choiceD = value; }
        }
        public string StdType
        {
            get { return stdType; }
            set { stdType = value; }
        }
        public Boolean Avail
        {
            get { return avail; }
            set { avail = value; }
        }
    }
}
