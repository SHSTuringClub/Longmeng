using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTDD
{
    class ExerciseModel
    {
        public ExerciseModel() { }
        private int id;
        private Boolean avail;
        private int fir_type;
        private int sec_type;
        private string stem;
        private string key;
        private string ca;
        private string cb;
        private string cc;
        private string cd;
        private int scorer;
        private int scorew;
        public int ScoreR
        {
            set { scorer = value; }
            get { return scorer; }
        }
        public int ScoreW
        {
            set { scorew = value; }
            get { return scorew; }
        }
        public int ID
        {
            get
            {
                return id;
            }
            set { id = value; }
        }
        public Boolean Avail
        {
            get { return avail; }
            set { avail = value; }
        }
        public int Fir_type
        {
            get { return fir_type; }
            set { fir_type = value; }
        }
        public int Sec_type
        {
            get { return sec_type; }
            set { sec_type = value; }
        }
        public String Stem
        {
            get { return stem; }
            set { stem = value; }
        }
        public String Ca
        {
            get { return ca; }
            set { ca = value; }
        }
        public String Key
        {
            get { return key; }
            set { key = value; }
        }
        public string Cb
        {
            get { return cb; }
            set { cb = value; }
        }
        public string Cc
        {
            get { return cc; }
            set { cc = value; }
        }
        public string Cd
        {
            get { return cd; }
            set { cd = value; }
        }
    }
}
